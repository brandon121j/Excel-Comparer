using System.ComponentModel;
using System.Diagnostics;
using ClosedXML.Excel;
using Excel_Comparer.Common;

namespace Excel_Comparer.Custom_Controls;

public partial class GenerateComparisonControl : UserControl
{
    private static string _excel1PK = "None";
    private static string _excel2PK = "None";

    private Compare? _compare;
    public GenerateComparisonControl() => InitializeComponent();

    public static bool GeneratingComparison { get; set; }

    private static string Excel1PK
    {
        get => _excel1PK;
        set => _excel1PK = value ?? "None";
    }

    private static string Excel2PK
    {
        get => _excel2PK;
        set => _excel2PK = value ?? "None";
    }

    private void GenerateComparisonControl_VisibleChanged(object sender, EventArgs e)
    {
        if (Visible) AddItemsToListView(ExcelData.GetCompareCriteria());
    }

    private void AddItemsToListView(Dictionary<string, string> items)
    {
        excel1LV.Items.Clear();
        excel2LV.Items.Clear();

        excel1LV.Items.Add("None");
        excel2LV.Items.Add("None");

        foreach (var item in items)
        {
            excel1LV.Items.Add(item.Key);
            excel2LV.Items.Add(item.Value);
        }
    }

    private void Excel1LV_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if (e.NewValue != CheckState.Checked) return;

        // uncheck all other items
        foreach (ListViewItem item in excel1LV.Items)
            if (item.Index != e.Index)
            {
                item.Checked = false;
            }
            else // if the item is being unchecked
            {
                // keep the item checked
                e.NewValue = CheckState.Checked;
                Excel1PK = item.Text;
            }
    }


    private void Excel2LV_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if (e.NewValue != CheckState.Checked) return;

        // uncheck all other items
        foreach (ListViewItem item in excel2LV.Items)
            if (item.Index != e.Index)
            {
                item.Checked = false;
            }
            else // if the item is being unchecked
            {
                // keep the item checked
                e.NewValue = CheckState.Checked;
                Excel2PK = item.Text;
            }
    }


    private void GenerateBT_Click(object sender, EventArgs e)
    {
        GeneratingComparison = true;
        loadingPN.Visible = true;
        headerLB.Text = @"Generating Comparison";
        loadingLB.Text = @"Loading...";

        _compare = new Compare
        {
            PrimaryKeys = (Excel1PK, Excel2PK)
        };

        _compare.ProgressChanged += BackgroundWorker_ProgressChanged;
        _compare.WorkComplete += BackgroundWorker_RunWorkerCompleted;
        _compare.BeginComparison();
    }

    private void BackgroundWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e) => loadingLB.Text = e.UserState?.ToString();

    private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        GeneratingComparison = false;
        headerLB.Text = @"Generate Comparison";
        loadingLB.Text = string.Empty;
        loadingPN.Visible = false;

        if (e.Result == null) return;

        using var workbook = e.Result as XLWorkbook;

        SaveFileDialog save = new()
        {
            RestoreDirectory = true,
            DefaultExt = "xlsx",
            Filter = @"Excel Files|*.xls;*.xlsx;"
        };
        if (save.ShowDialog() == DialogResult.OK)
        {
            workbook?.SaveAs(save.FileName);
            workbook?.Dispose();

            try
            {
                Task.Run(async () =>
                {
                    while (!File.Exists(save.FileName)) await Task.Delay(10);
                });

                Process.Start(@"C:\\Program Files\\Microsoft Office\\root\\Office16\\Excel.exe", save.FileName);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        _compare = null;
        Compare.ComparisonCompleted = true;
    }

    private void CancelBT_Click(object sender, EventArgs e) => _compare?.Cancel();
}