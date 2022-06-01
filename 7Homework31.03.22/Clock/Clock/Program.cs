namespace Clock;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
        //FileInfo fileInfo = new FileInfo("../../../clock1.png");
        //Console.WriteLine(fileInfo.FullName);
    }
}