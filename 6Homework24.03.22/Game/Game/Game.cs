namespace Game;

public class Game
{
    public Game()
    {
        _currentPosition = (5, 20);
        _fieldSize = (12, 42);
    }
    
    private (int, int) _currentPosition;

    private (int, int) _lastMove;
    private readonly (int, int) _fieldSize;

    private void Move(int x, int y)
    {
        if (_currentPosition.Item2 + x <= 0 || _currentPosition.Item2 + x >= _fieldSize.Item2 
                                            || _currentPosition.Item1 + y < 0 ||
                                            _currentPosition.Item1 + y >= _fieldSize.Item1 - 1)
        {
            return;
        }
        Console.SetCursorPosition(_currentPosition.Item2 - _lastMove.Item1, _currentPosition.Item1 - _lastMove.Item2);
        Console.Write(' ');
        Console.SetCursorPosition(_currentPosition.Item2, _currentPosition.Item1);
        Console.Write(' ');
        Console.SetCursorPosition(_currentPosition.Item2 + x, _currentPosition.Item1 + y);
        _currentPosition.Item2 += x;
        _currentPosition.Item1 += y;
        _lastMove = (x, y);
        Console.Write('@');
    }

    public void Up(object sender, EventArgs args)
    {
        Move(0, -1);
    }

    public void Down(object sender, EventArgs args)
    {
        Move(0, 1);
    }
    
    public void Left(object sender, EventArgs args)
    {
        Move(-1, 0);
    }

    public void Right(object sender, EventArgs args)
    {
        Move(1, 0);
    }
}