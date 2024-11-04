using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

public class RoundedTextBox : TextBox
{
    private int borderRadius = 20;

    public int BorderRadius
    {
        get { return borderRadius; }
        set { borderRadius = value; Invalidate(); }
    }

    public RoundedTextBox()
    {
        // Aktifkan double buffering untuk mengurangi flickering
        this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
        this.BorderStyle = BorderStyle.None; // Hapus border default
        this.BackColor = Color.Purple; // Set background color
        this.ForeColor = Color.White; // Set text color
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        // Tidak menggambar background di sini
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        // Menggambar path rounded
        using (GraphicsPath path = CreateRoundPath())
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Menggambar background dalam warna Purple
            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }
        }

        // Menggambar teks
        Rectangle textArea = new Rectangle(0, 0, Width, Height);
        TextRenderer.DrawText(e.Graphics, this.Text, this.Font, textArea, this.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
    }

    private GraphicsPath CreateRoundPath()
    {
        GraphicsPath path = new GraphicsPath();
        path.StartFigure();
        path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
        path.AddArc(Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
        path.AddArc(Width - borderRadius, Height - borderRadius, borderRadius, borderRadius, 0, 90);
        path.AddArc(0, Height - borderRadius, borderRadius, borderRadius, 90, 90);
        path.CloseFigure();
        this.Region = new Region(path); // Set region untuk membatasi area
        return path;
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Invalidate();
    }

    protected override void OnTextChanged(EventArgs e)
    {
        base.OnTextChanged(e);
        Invalidate();
    }
}

