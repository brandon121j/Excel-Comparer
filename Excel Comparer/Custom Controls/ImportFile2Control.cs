using System.ComponentModel;
using Excel_Comparer.Common;
using Excel_Comparer.Properties;

namespace Excel_Comparer.Custom_Controls;

public partial class ImportFile2Control : UserControl
{
    private BackgroundWorker? _bw;

    public ImportFile2Control() => InitializeComponent();

    private static string ExcelNameGrabber() => string.IsNullOrEmpty(ExcelData.ExcelFile2) ? "" : Path.GetFileName(ExcelData.ExcelFile2);

    private void ImportPB_Click(object sender, EventArgs e)
    {
        using OpenFileDialog file2 = new()
        {
            Title = @"Choose Excel File",
            Filter = @"Excel Files|*.xls;*.xlsx;*.xlsm;",
            InitialDirectory = ExcelData.DocumentPath,
            RestoreDirectory = false,
            Multiselect = false
        };
        if (file2.ShowDialog() == DialogResult.OK)
        {
            DoWork(file2.FileName);
        }
        else
        {
            loadingPB.Visible = false;
            fileLB.Text = ExcelNameGrabber();
        }
    }

    private void ImportFile2Control_VisibleChanged(object sender, EventArgs e)
    {
        if (!Visible) return;

        importPB.Image = string.IsNullOrEmpty(ExcelData.ExcelFile2)
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

    private static void ImportFile(string file2)
    {
        ExcelData.ExcelFile2 = file2;
        ExcelData.Excel2Columns = ExcelData.ColumnFetcher(file2);
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

    private void Panel1_DragEnter(object sender, DragEventArgs e) => e.Effect = e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop, false)
        ? DragDropEffects.All
        : DragDropEffects.None;

    private void ImportFile2Control_DragEnter(object sender, DragEventArgs e) => e.Effect = e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop, false)
        ? DragDropEffects.All
        : DragDropEffects.None;

    private void ImportFile2Control_DragDrop(object sender, DragEventArgs e)
    {
        var droppedFile = e.Data?.GetData(DataFormats.FileDrop) as string[];

        var fileName = Path.GetFullPath(droppedFile?[0] ?? string.Empty);

        if (Path.GetExtension(fileName) == ".xlsx")
            DoWork(fileName);
    }

    private void Panel1_DragDrop(object sender, DragEventArgs e)
    {
        var droppedFile = (string[])e.Data.GetData(DataFormats.FileDrop);

        var fileName = Path.GetFullPath(droppedFile?[0] ?? string.Empty);

        if (Path.GetExtension(fileName) == ".xlsx")
            DoWork(fileName);
    }
}