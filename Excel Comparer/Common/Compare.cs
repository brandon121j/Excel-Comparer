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
    public (string, string) PrimaryKeys { get; set; }
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

    public static bool ComparisonCompleted { get; set; } = false;

    private static string Connection(string excelFile) => $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={excelFile};Extended Properties=\'Excel 12.0 Xml;HDR=YES;\';";

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

        var excel1DT = DataFetcher(ExcelData.ExcelFile1, SelectedColumns(excelCriteria.Keys.ToList()));
        var excel2DT = DataFetcher(ExcelData.ExcelFile2, SelectedColumns(excelCriteria.Values.ToList()), "Excel2");

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
            var excel1Record = excel1PK.Equals("None") ? row[excel1Col.FirstOrDefault()].ToString() : row[excel1PK];
            var excel2Select = excel2Pk.Equals("None") ? $"[{excel2Col.FirstOrDefault()}] like '{excel1Record}'" : $"[{excel2Pk}] like '{excel1Record}'";

            var excel2Rows = excel2DT.Select(excel2Select).ToList();

            if (excel2Rows.Count > 0)
            {
                var hasChanged = row.ItemArray
                    .Where((val, i) => !val.Equals(excel2Rows[0][excel2Col[i]])).ToList();


                if (hasChanged.Count == 0)
                {
                    differences.Add("NO CHANGE");
                }
                else
                {
                    StringBuilder sb = new();

                    for (var d = 0; d < hasChanged.Count; d++)
                    {
                        var column = excel2Col.FirstOrDefault(x => row[x].Equals(hasChanged[d]));

                        sb.Append($"{column}: {hasChanged[d]}, ");
                    }

                    differences.Add($"UPDATED: {sb}".TrimEnd().TrimEnd(','));
                }
            }
            else
            {
                differences.Add("DELETED");
            }
        }

        _bw.ReportProgress(75, "Returning Results");

        e.Result = ConvertToExcel(differences);

        _bw.ReportProgress(100, "Comparison Complete!");

        _bw.Dispose();
    }


    private static XLWorkbook ConvertToExcel(List<string> differences)
    {
        using XLWorkbook ogWorkbook = new(ExcelData.ExcelFile1);

        XLWorkbook workbook = new();

        ogWorkbook.Worksheets.FirstOrDefault()?.CopyTo(workbook, "Comparison");

        var worksheet = workbook.Worksheet("Comparison");

        worksheet.Style = null;

        var diffCol = worksheet.LastColumnUsed().ColumnNumber() + 1;

        var lastRow = worksheet.LastRowUsed().RowNumber();

        worksheet.Cell(1, diffCol).Value = "Differences";

        worksheet.Range(worksheet.Cell(1, 1), worksheet.Cell(lastRow, diffCol)).CreateTable();

        for (int i = 2, x = 0; i < lastRow + 1; i++, x++)
        {
            worksheet.Cell(i, diffCol).Value = differences[x];
            switch (differences[x].Split()[0])
            {
                case "UPDATED:":
                    worksheet.Range(worksheet.Cell(i, 1), worksheet.Cell(i, diffCol)).Style.Fill.BackgroundColor = XLColor.Yellow;
                    break;
                case "NO":
                    worksheet.Range(worksheet.Cell(i, 1), worksheet.Cell(i, diffCol)).Style.Fill.BackgroundColor = XLColor.Green;
                    break;
                case "DELETED":
                    worksheet.Range(worksheet.Cell(i, 1), worksheet.Cell(i, diffCol)).Style.Fill.BackgroundColor = XLColor.Red;
                    break;
            }
        }

        worksheet.Tables.FirstOrDefault().Theme = new XLTableTheme("None");

        worksheet.Columns().AdjustToContents();

        return workbook;
    }

    private static DataTable DataFetcher(string currentWB, string selection = "*", string name = "Excel1")
    {
        DataTable dataTable = new();

        try
        {
            using XLWorkbook workbook = new(currentWB);

            using OleDbConnection excelConn = new(Connection(currentWB));

            excelConn.Open();

            using OleDbCommand command = new($"SELECT {selection} FROM [{workbook.Worksheets.FirstOrDefault()}$]", excelConn);

            using OleDbDataAdapter adapter = new() { SelectCommand = command };

            using DataSet dataSet = new();

            adapter.Fill(dataSet, name);

            dataTable = dataSet.Tables[0];

            foreach (DataRow row in dataTable.Rows)
                foreach (DataColumn column in dataTable.Columns)
                    row[column] = row[column].ToString()?.Trim().Replace("'", "");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }

        return ConvertToStrings(dataTable);
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

        return newDataTable;
    }









}