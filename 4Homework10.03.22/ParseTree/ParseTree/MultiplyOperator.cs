namespace ParseTree;

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