using ClosedXML.Excel;

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

        using var workbook = new XLWorkbook(path);

        var worksheet = workbook.Worksheets.FirstOrDefault() ?? throw new Exception();

        return worksheet.ColumnsUsed().Select(col => col.FirstCellUsed().Value.ToString().Trim()).ToList();
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