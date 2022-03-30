namespace ParseTree.Solution;

public interface INode
{
    double GetValue();
    
    public void PrintYourself();
    
    public INode Add(string element);
    
    public bool AreGuardian { get; }
}