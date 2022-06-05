namespace ParseTree;

/// <summary>
/// A type of node that stores an operand.
/// </summary>
public class Operand : INode
{
    public Operand(INode? parent, float value)
    {
        _parent = parent;
        _value = value;
    }
    
    private readonly INode? _parent;
    private readonly float _value;
    public bool AreGuardian => false;
    public float GetValue() => _value;

    public void PrintYourself()
    {
        Console.WriteLine($"{_value} ");
    }

    public INode Add(string element)
    {
        if (_parent == null)
        {
            throw new ExpressionProcessingException();
        }

        return _parent.Add(element);
    }
}