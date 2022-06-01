using System.Drawing;

namespace Clock;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

    }

    Graphics graphics;

    private void Form1_Paint(object sender, PaintEventArgs e)
    {

        graphics = CreateGraphics();
        graphics.Clear(Color.White);
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        var currentTime = DateTime.Now;
        graphics.Clear(Color.White);
        graphics.DrawEllipse(Pens.Black, 0, 0, 300, 300);
        graphics.DrawLine(Pens.Black, 150, 145, (int)(150 + 145 * Math.Sin(((double)currentTime.Second * 6) / 180 * Math.PI)), (int)(150 + 145 * Math.Cos((180.0d + currentTime.Second * 6) / 180 * Math.PI)));
        graphics.DrawLine(Pens.Black, 150, 145, (int)(150 + 130 * Math.Sin(((double)currentTime.Minute * 6) / 180 * Math.PI)), (int)(150 + 130 * Math.Cos((180.0d + currentTime.Minute * 6) / 180 * Math.PI)));
        graphics.DrawLine(Pens.Black, 150, 145, (int)(150 + 100 * Math.Sin(((double)(currentTime.Hour % 12) * 30) / 180 * Math.PI)), (int)(150 + 100 * Math.Cos((180.0d + (currentTime.Hour % 12) * 30) / 180 * Math.PI)));
    }
}