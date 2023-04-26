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
        Image image = Image.FromFile("../../../clock3.png");
        graphics.Clear(Color.White);
        var currentTime = DateTime.Now;
        graphics.DrawImage(image, 0, 0);
        graphics.DrawLine(Pens.Black, 150, 145, (int)(150 + 145 * Math.Sin(((double)currentTime.Second * 6) / 180 * Math.PI)), (int)(150 + 145 * Math.Cos((180.0d + currentTime.Second * 6) / 180 * Math.PI)));
        graphics.DrawLine(Pens.Black, 150, 145, (int)(150 + 100 * Math.Sin(((double)currentTime.Minute * 6) / 180 * Math.PI)), (int)(150 + 100 * Math.Cos((180.0d + currentTime.Minute * 6) / 180 * Math.PI)));
        graphics.DrawLine(Pens.Black, 150, 145, (int)(150 + 70 * Math.Sin(((double)(currentTime.Hour % 12) * 30) / 180 * Math.PI)), (int)(150 + 70 * Math.Cos((180.0d + (currentTime.Hour % 12) * 30) / 180 * Math.PI)));
    
    }
}