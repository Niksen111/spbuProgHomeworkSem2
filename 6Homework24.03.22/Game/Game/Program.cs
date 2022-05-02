namespace Game;

public class Program
{
    public static void Main(string[] args)
    {
        var file = File.ReadAllLines("../../../Map.txt");
        foreach (var line in file)
        {
            Console.WriteLine(line);
        }
        Console.SetCursorPosition(20, 5);

        
        var eventLoop = new EventLoop();
        var game = new Game();
        eventLoop.UpHandler += game.Up!;
        eventLoop.DownHandler += game.Down!;
        eventLoop.LeftHandler += game.Left!;
        eventLoop.RightHandler += game.Right!;
        
        eventLoop.Run();
    }
}