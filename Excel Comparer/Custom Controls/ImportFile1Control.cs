using System.ComponentModel;
using Excel_Comparer.Common;
using Excel_Comparer.Properties;

namespace Excel_Comparer.Custom_Controls;

public partial class ImportFile1Control : UserControl
{
    private BackgroundWorker? _bw;

    public ImportFile1Control() => InitializeComponent();

    private static string ExcelNameGrabber() => string.IsNullOrEmpty(ExcelData.ExcelFile1) ? "" : Path.GetFileName(ExcelData.ExcelFile1);

    private void ImportPB_Click(object sender, EventArgs e)
    {
        using OpenFileDialog file1 = new()
        {
            Title = @"Choose Excel File",
            Filter = @"Excel Files|*.xls;*.xlsx;*.xlsm;",
            InitialDirectory = ExcelData.DocumentPath,
            RestoreDirectory = false,
            Multiselect = false
        };
        if (file1.ShowDialog() == DialogResult.OK)
        {
            DoWork(file1.FileName);
        }
        else
        {
            loadingPB.Visible = false;
            fileLB.Text = ExcelNameGrabber();
        }
    }

    private void ImportFile1Control_VisibleChanged(object sender, EventArgs e)
    {
        if (!Visible) return;

        ExcelData.ResetData();

        importPB.Image = string.IsNullOrEmpty(ExcelData.ExcelFile1)
            ? Resources.icons8_add_file_96
            : Resources.icons8_happy_file_96;

        fileLB.Text = ExcelNameGrabber();
    }

    private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        loadingPB.Visible = false;
        importPB.Image = Resources.icons8_happy_file_96;
        fileLB.Text = ExcelNameGrabber();

        _bw?.Dispose();
    }

    private static void ImportFile(string file1)
    {
        ExcelData.ExcelFile1 = file1;
        ExcelData.Excel1Columns = ExcelData.ColumnFetcher(file1);
    }

    private void ImportFile1Control_DragEnter(object sender, DragEventArgs e) => e.Effect = e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop, false)
        ? DragDropEffects.All
        : DragDropEffects.None;

    private void Panel1_DragEnter(object sender, DragEventArgs e) => e.Effect = e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop, false)
        ? DragDropEffects.All
        : DragDropEffects.None;

    private void ImportFile1Control_DragDrop(object sender, DragEventArgs e)
    {
        var droppedFile = e.Data?.GetData(DataFormats.FileDrop) as string[];

        var fileName = Path.GetFullPath(droppedFile?[0] ?? string.Empty);

        if (Path.GetExtension(fileName) == ".xlsx")
            DoWork(fileName);
    }

    private void Panel1_DragDrop(object sender, DragEventArgs e)
    {
        var droppedFile = e.Data?.GetData(DataFormats.FileDrop) as string[];

        var fileName = Path.GetFullPath(droppedFile?[0] ?? string.Empty);

        if (Path.GetExtension(fileName) == ".xlsx")
            DoWork(fileName);
    }

    private void DoWork(string fileName)
    {
        loadingPB.Visible = true;
        fileLB.Text = @"Loading...";
        _bw = new BackgroundWorker();
        _bw.DoWork += (obj, e) => ImportFile(fileName);
        _bw.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
        _bw.RunWorkerAsync();
    }
}