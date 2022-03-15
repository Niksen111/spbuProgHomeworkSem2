namespace LZW.Solution;

internal class Program
{
    private static void ShowCommands()
    {
        Console.WriteLine("    || Enter path of a file and:");
        Console.WriteLine("    ||   -c to zip the file");
        Console.WriteLine("    ||   -u to unzip the file");
        Console.WriteLine("    || Enter \"exit\" to exit");
    }
    private static void InteractWithUser()
    {
        Console.WriteLine("Hello!");
        ShowCommands();
        CompressorLZW compressor = new CompressorLZW();
        while (true)
        {
            Console.WriteLine("    || Enter \"help\" to show commands");
            Console.WriteLine();
            string? line = Console.ReadLine();
            Console.WriteLine();
            if (line == null)
            {
                continue;
            }
            string[] input = line.Split();
            switch (input.Length)
            {
                case 1:
                    switch (input[0])
                    {
                        case "help":
                            ShowCommands();
                            break;
                        case "exit":
                            Console.WriteLine("Goodbye!");
                            return;
                        default:
                            Console.WriteLine("    || IncorrectInput");
                            break;
                    }
                    break;
                case 2:
                    switch (input[1])
                    {
                        case "-c":
                            compressor.ZipFile(input[0]);
                            break;
                        case "-u":
                            compressor.UnzipFile(input[0]);
                            break;
                        default:
                            Console.WriteLine("    || IncorrectInput");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("    || IncorrectInput");
                    break;
            }
        }
    }
    
    public static void Main(string[] args)
    {
        InteractWithUser();
        //byte[] arrayBytes = File.ReadAllBytes("/home/niksen111/spbuProgHomeworkSem2/3Homework03.03.22/LZW/LZW/Tests/NewFile1.txt");
    }
} 