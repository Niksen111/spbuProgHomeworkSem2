namespace ParseTree.Solution;

public class Operand : INode
{
    public Operand(INode? parent, double value)
    {
        _parent = parent;
        _value = value;
    }
    
    private readonly INode? _parent;
    private readonly double _value;
    public bool AreGuardian => false;
    public double GetValue() => _value;

    public void PrintYourself()
    {
        Console.WriteLine("{0} ", _value);
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