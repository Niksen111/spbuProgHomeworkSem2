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
        Console.WriteLine();
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
        // BitArray myArray = new BitArray(8);
        // myArray.Set(5, true);
        // myArray.Length = 9;
        // myArray.RightShift(1);
        // Console.WriteLine("{0}", myArray.Length);
        InteractWithUser();
    }
} 