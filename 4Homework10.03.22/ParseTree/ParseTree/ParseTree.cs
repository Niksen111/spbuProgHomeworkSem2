namespace ParseTree;

public class ParseTree
{
    public ParseTree(string expression)
    {
        RebuildTree(expression);
    }

    private INode Head;
    private INode CurrentNode;
    private float _result;
    public double GetResult => _result;
    public void RebuildTree(string expression)
    {
        
    }

    public void PrintTree()
    {
        Head.PrintYourself();
    }

    private void CalculateTree()
    {
        _result = Head.GetValue();
    }
}