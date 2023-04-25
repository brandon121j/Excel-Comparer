using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Text;
using ClosedXML.Excel;

namespace Excel_Comparer.Common;

public class Compare
{
    public delegate void WorkCompleteEventHandler(object sender, RunWorkerCompletedEventArgs e);

    private readonly BackgroundWorker _bw;

    public Compare()
    {
        _bw = new BackgroundWorker
        {
            WorkerSupportsCancellation = true,
            WorkerReportsProgress = true
        };

        _bw.RunWorkerCompleted += BW_RunWorkerCompleted;
        _bw.DoWork += BW_DoWork;
        _bw.ProgressChanged += BW_ProgressChanged;
    }

    public (string, string) PrimaryKeys { get; set; }

    public static bool ComparisonCompleted { get; set; } = false;

    public event ProgressChangedEventHandler? ProgressChanged;

    protected void RaiseProgressChangedEvent(ProgressChangedEventArgs e) => ProgressChanged?.Invoke(this, e);

    public event WorkCompleteEventHandler? WorkComplete;

    protected void RaiseWorkCompleteEvent(RunWorkerCompletedEventArgs e) => WorkComplete?.Invoke(this, e);

    public void Cancel() => _bw?.CancelAsync();

    private void BW_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e) => RaiseWorkCompleteEvent(e);

    private void BW_ProgressChanged(object? sender, ProgressChangedEventArgs e) => RaiseProgressChangedEvent(e);

    public void BeginComparison() => _bw.RunWorkerAsync();

    private void BW_DoWork(object? sender, DoWorkEventArgs e)
    {
        _bw.ReportProgress(0, "Fetching Excel Data");

        var excelCriteria = ExcelData.GetCompareCriteria();
        var excel1Col = excelCriteria.Keys.ToList();
        var excel2Col = excelCriteria.Values.ToList();

        if (ExcelData.ExcelFile1 == null || ExcelData.ExcelFile2 == null) return;

        var excel1DT = DataFetcher(ExcelData.ExcelFile1, "Excel1", SelectedColumns(excelCriteria.Keys.ToList()));
        var excel2DT = DataFetcher(ExcelData.ExcelFile2, "Excel2", SelectedColumns(excelCriteria.Values.ToList()));
        var excelOG = DataFetcher(ExcelData.ExcelFile1);


        List<string> differences = new();

        if (_bw.CancellationPending)
        {
            e.Cancel = true;
            return;
        }

        _bw.ReportProgress(25, "Comparing Excel Data");

        var (excel1PK, excel2Pk) = PrimaryKeys;

        foreach (DataRow row in excel1DT.Rows)
        {
            if (_bw.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            var excel1Record = excel1PK.Equals("None") ? row[excel1Col.FirstOrDefault()].ToString() : row[excel1PK];
            var excel2Select = excel2Pk.Equals("None") ? $"[{excel2Col.FirstOrDefault()}] like '{excel1Record}'" : $"[{excel2Pk}] like '{excel1Record}'";

            var excel2Rows = excel2DT.Select(excel2Select);

            if (excel2Rows.Length > 0)
            {
                var hasChanged = excel2Rows[0].ItemArray
                    .Where((val, i) => !val.Equals(row[i])).ToList();

                if (hasChanged.Count == 0)
                {
                    differences.Add("NO CHANGE");
                }
                else
                {
                    StringBuilder sb = new();

                    for (var d = 0; d < excel2Rows[0].ItemArray.Length; d++)
                    {
                        if (!hasChanged.Contains(excel2Rows[0][excel2Col[d]].ToString())) continue;

                        sb.Append($"{excel1Col[d].Trim()}: {excel2Rows[0][excel2Col[d]]}, ");
                    }

                    differences.Add($"UPDATED: {sb.ToString().TrimEnd().TrimEnd(',')}");
                }
            }
            else
            {
                differences.Add("DELETED");
            }
        }

        _bw.ReportProgress(75, "Returning Results");

        e.Result = ConvertToExcel(excelOG, differences);

        _bw.ReportProgress(100, "Comparison Complete!");

        _bw.Dispose();
    }


    private static XLWorkbook ConvertToExcel(DataTable dt, IReadOnlyList<string> differences)
    {
        XLWorkbook workbook = new();

        var worksheet = workbook.Worksheets.Add(dt);

        var table = worksheet.Tables.FirstOrDefault();

        var diffCol = worksheet.LastColumnUsed().ColumnNumber() + 1;

        var lastRow = worksheet.LastRowUsed().RowNumber();

        table.InsertColumnsAfter(1);

        worksheet.Cell(1, diffCol).Value = "Differences";

        for (int i = 2, x = 0; i < lastRow + 1; i++, x++)
        {
            worksheet.Cell(i, diffCol).Value = differences[x];

            worksheet.Range(worksheet.Cell(i, 1), worksheet.Cell(i, diffCol)).Style.Fill.BackgroundColor = differences[x].Split()[0] switch
            {
                "UPDATED:" => XLColor.Yellow,
                "NO" => XLColor.Green,
                "DELETED" => XLColor.Red,
                _ => worksheet.Range(worksheet.Cell(i, 1), worksheet.Cell(i, diffCol)).Style.Fill.BackgroundColor
            };
        }


        table.Theme = new XLTableTheme("None");

        worksheet.Columns().AdjustToContents();

        return workbook;
    }

    private static DataTable DataFetcher(string currentWB, string name, string selection = "*")
    {
        DataTable dataTable;

        try
        {
            var connection = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={currentWB};Extended Properties=\'Excel 12.0 Xml;HDR=YES;\';";

            using OleDbConnection excelConn = new(connection);

            excelConn.Open();

            var dtSchema = excelConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            var worksheet = dtSchema.Rows[0]["TABLE_NAME"].ToString();

            using OleDbCommand command = new($"SELECT {selection} FROM [{worksheet}]", excelConn);

            using OleDbDataAdapter adapter = new() { SelectCommand = command };

            using DataSet dataSet = new();

            adapter.Fill(dataSet, name);

            dataTable = dataSet.Tables[0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }

        return ConvertToStrings(dataTable);
    }

    private static DataTable DataFetcher(string currentWB)
    {
        DataTable dataTable;

        try
        {
            var connection = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={currentWB};Extended Properties=\'Excel 12.0 Xml;HDR=YES;\';";

            using OleDbConnection excelConn = new(connection);

            excelConn.Open();

            var dtSchema = excelConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            var worksheet = dtSchema.Rows[0]["TABLE_NAME"].ToString();

            using OleDbCommand command = new($"SELECT * FROM [{worksheet}]", excelConn);

            using OleDbDataAdapter adapter = new() { SelectCommand = command };

            using DataSet dataSet = new();

            adapter.Fill(dataSet, "Comparison");

            dataTable = dataSet.Tables[0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }

        return dataTable;
    }

    private static string SelectedColumns(List<string> columns)
    {
        StringBuilder sb = new();

        columns.ForEach(c => sb.Append($"[{c}],"));

        sb.Length--;

        return sb.ToString().TrimEnd(',');
    }

    public static DataTable ConvertToStrings(DataTable dt)
    {
        var newDataTable = dt.Clone();

        foreach (DataColumn column in newDataTable.Columns)
            column.DataType = typeof(string);

        newDataTable.Load(dt.CreateDataReader());

        foreach (DataRow row in newDataTable.Rows)
        foreach (DataColumn column in newDataTable.Columns)
            row[column] = DateTime.TryParse(row[column].ToString(), out var dateTime) ? dateTime.ToString("MM/dd/yyyy").Trim() : row[column].ToString()?.Trim().Replace("'", "");

        return newDataTable;
    }
}