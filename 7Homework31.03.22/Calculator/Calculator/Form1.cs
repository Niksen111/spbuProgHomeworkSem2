namespace Calculator;

public partial class Form1 : Form
{
    private MyCalculator _myCalculator;

    public Form1()
    {
        InitializeComponent();
        _myCalculator = new MyCalculator();
        textBox1.Text = "0";
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
        textBox1.Text = _myCalculator.MakeAction('!');
    }

    private void button2_Click(object sender, EventArgs e)
    {
        textBox1.Text = _myCalculator.MakeAction('0');

    }

    private void button3_Click(object sender, EventArgs e)
    {
        textBox1.Text = _myCalculator.MakeAction(',');

    }

    private void button4_Click(object sender, EventArgs e)
    {
        textBox1.Text = _myCalculator.MakeAction('=');

    }

    private void button5_Click(object sender, EventArgs e)
    {
        textBox1.Text = _myCalculator.MakeAction('1');

    }

    private void button6_Click(object sender, EventArgs e)
    {
        textBox1.Text = _myCalculator.MakeAction('2');

    }

    private void button7_Click(object sender, EventArgs e)
    {
        textBox1.Text = _myCalculator.MakeAction('3');

    }

    private void button8_Click(object sender, EventArgs e)
    {
        textBox1.Text = _myCalculator.MakeAction('+');

    }

    private void button9_Click(object sender, EventArgs e)
    {
        textBox1.Text = _myCalculator.MakeAction('4');

    }

    private void button10_Click(object sender, EventArgs e)
    {
        textBox1.Text = _myCalculator.MakeAction('5');

    }

    private void button11_Click(object sender, EventArgs e)
    {
        textBox1.Text = _myCalculator.MakeAction('6');

    }

    private void button12_Click(object sender, EventArgs e)
    {
        textBox1.Text = _myCalculator.MakeAction('-');

    }

    private void button13_Click(object sender, EventArgs e)
    {
        textBox1.Text = _myCalculator.MakeAction('7');

    }

    private void button14_Click(object sender, EventArgs e)
    {
        textBox1.Text = _myCalculator.MakeAction('8');

    }

    private void button15_Click(object sender, EventArgs e)
    {
        textBox1.Text = _myCalculator.MakeAction('9');

    }

    private void button16_Click(object sender, EventArgs e)
    {
        textBox1.Text = _myCalculator.MakeAction('*');

    }

    private void button19_Click(object sender, EventArgs e)
    {
        textBox1.Text = _myCalculator.MakeAction('C');
     
    }

    private void button20_Click(object sender, EventArgs e)
    {
        textBox1.Text = _myCalculator.MakeAction('/');
    }
}
