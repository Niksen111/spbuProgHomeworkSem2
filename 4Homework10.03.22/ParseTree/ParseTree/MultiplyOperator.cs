namespace ParseTree;

/// <summary>
/// Node corresponding to the multiplication operation.
/// </summary>
public class MultiplyOperator : Operator
{
    public MultiplyOperator(INode? parent)
    {
        Parent = parent;
        Value = '*';
    }
    
    public override float GetValue()
    {
        return LeftSon.GetValue() * RightSon.GetValue();
    }
}