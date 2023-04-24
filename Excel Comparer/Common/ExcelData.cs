using System.Data;
using System.Data.OleDb;

namespace Excel_Comparer.Common;

public static class ExcelData
{
    private static readonly Dictionary<string, string> CompareCriteria = new();
    public static string DocumentPath => "C:\\Documents";

    public static string? ExcelFile1 { get; set; }
    public static string? ExcelFile2 { get; set; }

    public static List<string>? Excel1Columns { get; set; }
    public static List<string>? Excel2Columns { get; set; }

    public static bool DataChanged { get; set; } = true;

    public static bool ValidExcelCriteria() => CompareCriteria.Count > 0;

    public static Dictionary<string, string> GetCompareCriteria() => CompareCriteria;

    public static void SetCompareCriteria(string key, string value) => CompareCriteria[key] = value;

    public static void RemoveCompareCriteria(string key) => CompareCriteria.Remove(key);

    private static void ClearCompareCriteria() => CompareCriteria.Clear();

    public static List<string> ColumnFetcher(string path)
    {
        ClearCompareCriteria();

        DataChanged = true;

        var connection = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={path};Extended Properties=\'Excel 12.0 Xml;HDR=YES;\';";

        using OleDbConnection excelConn = new(connection);

        excelConn.Open();

        var dtSchema = excelConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

        var worksheet = dtSchema.Rows[0]["TABLE_NAME"].ToString();

        using OleDbCommand command = new($"SELECT * FROM [{worksheet}]", excelConn);

        using OleDbDataAdapter adapter = new() { SelectCommand = command };

        using DataSet dataSet = new();

        adapter.Fill(dataSet, "Comparison");

        excelConn.Close();

        var dataTable = dataSet.Tables[0];

        return (from DataColumn col in dataTable.Columns select col.ColumnName).ToList();
    }

    public static void ResetData()
    {
        if (!Compare.ComparisonCompleted) return;

        ExcelFile1 = ExcelFile2 = null;
        Excel1Columns?.Clear();
        Excel2Columns?.Clear();
        CompareCriteria?.Clear();
    }
}