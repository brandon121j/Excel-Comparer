using System.Runtime.InteropServices;

namespace Excel_Comparer.Common;

public static class Window
{
    // Handles Form drag functionality
    public const int WM_NCLBUTTONDOWN = 0xA1;

    public const int HT_CAPTION = 0x2;

    // Handles drag functionality
    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);

    // Handles drag functionality
    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();

    // Handles rounding corners of Form
    [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
    public static extern IntPtr CreateRoundRectRgn
    (
        int nLeftRect,
        int nTopRect,
        int nRightRect,
        int nBottomRect,
        int nWidthEllipse,
        int nHeightEllipse
    );
}