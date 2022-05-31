namespace ParseTree;

public interface INode
{
    float GetValue();
    
    public void PrintYourself();
    
    public INode Add(string element);
    
    public bool AreGuardian { get; }
}