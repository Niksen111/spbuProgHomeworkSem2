namespace ParseTree.Solution;

public class Guardian : INode
{
    public double GetValue() => 0;

    public bool AreGuardian => true;

    public void PrintYourself()
    {
        throw new TreeStructureException();
    }

    public INode Add(string element)
    {
        throw new ExpressionProcessingException();
    }
}