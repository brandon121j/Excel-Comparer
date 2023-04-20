using Excel_Comparer.Common;
using Excel_Comparer.Custom_Controls;
using Excel_Comparer.Properties;

namespace Excel_Comparer;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        Region = Region.FromHrgn(Window.CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        WindowState = FormWindowState.Normal;
    }

    private void ExitBT_Click(object sender, EventArgs e) => Close();

    private void ExitBT_MouseEnter(object sender, EventArgs e) => exitBT.Image = Resources.macOS_hovered_red_32;

    private void ExitBT_MouseLeave(object sender, EventArgs e) => exitBT.Image = Resources.macOS_close_red_32;

    private void MinimizeBT_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

    private void MinimizeBT_MouseEnter(object sender, EventArgs e) => minimizeBT.Image = Resources.macOS_minimize_hovered_32;

    private void MinimizeBT_MouseLeave(object sender, EventArgs e) => minimizeBT.Image = Resources.macOS_minimize_32;

    private void GenerateBT_Click(object sender, EventArgs e)
    {
        if (!ExcelData.ValidExcelCriteria())
            return;

        MenuSelector((Button)sender);
    }

    private void Import1BT_Click(object sender, EventArgs e) => MenuSelector((Button)sender);

    private void HeaderPN_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Left) return;

        Window.ReleaseCapture();
        _ = Window.SendMessage(Handle, Window.WM_NCLBUTTONDOWN, Window.HT_CAPTION, 0);
    }

    private void Import2BT_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(ExcelData.ExcelFile1)) MenuSelector((Button)sender);
    }

    private void CriteriaBT_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(ExcelData.ExcelFile1) && !string.IsNullOrEmpty(ExcelData.ExcelFile2))
            MenuSelector((Button)sender);
    }

    private void MenuSelector(Control button)
    {
        if (GenerateComparisonControl.GeneratingComparison) return;

        Dictionary<Button, UserControl> pages = new()
        {
            { import1BT, importFile1Control }, { import2BT, importFile2Control },
            { criteriaBT, compareCriteriaControl }, { generateBT, generateComparisonControl }
        };

        selectedPN.Height = button.Height;
        selectedPN.Top = button.Top;

        foreach (var page in pages) page.Value.Visible = page.Key == button;
    }
}