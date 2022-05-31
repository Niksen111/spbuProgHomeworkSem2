namespace ParseTree;

public class PlusOperator : Operator
{
    public PlusOperator(INode? parent)
    {
        Parent = parent;
        Value = '+';
    }
    
    public override float GetValue()
    {
        return LeftSon.GetValue() + RightSon.GetValue();
    }
    
}