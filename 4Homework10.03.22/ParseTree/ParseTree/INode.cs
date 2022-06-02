namespace ParseTree;

/// <summary>
/// Node of the ParseTree.
/// </summary>
public interface INode
{
    /// <summary>
    /// Counts and returns the value of a given subtree.
    /// </summary>
    float GetValue();
    
    /// <summary>
    /// Prints a subtree of this node.
    /// </summary>
    public void PrintYourself();
    
    /// <summary>
    /// Adds an element to the tree.
    /// </summary>
    /// <returns></returns>
    public INode Add(string element);
    
    /// <summary>
    /// Returns true if the node is a guardian.
    /// </summary>
    public bool AreGuardian { get; }
}