using System.Drawing.Drawing2D;

namespace Excel_Comparer.Common;

public class CircularButton : Button
{
    protected override void OnPaint(PaintEventArgs pevent)
    {
        GraphicsPath gp = new();
        gp.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);

        Region = new Region(gp);

        base.OnPaint(pevent);
    }
}