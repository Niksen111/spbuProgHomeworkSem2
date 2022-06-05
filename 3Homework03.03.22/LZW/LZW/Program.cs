namespace LZW;

public class Program
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
        Console.WriteLine();
        ShowCommands();
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
                            float ratio = CompressorLZW.ZipFile(input[0]);
                            Console.WriteLine($"Compression ratio: {ratio}");
                            break;
                        case "-u":
                            CompressorLZW.UnzipFile(input[0]);
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
    }
} 