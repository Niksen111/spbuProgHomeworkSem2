namespace ParseTree.Solution;

public class MultiplyOperator : Operator
{
    public MultiplyOperator(INode? parent)
    {
        Parent = parent;
        Value = '*';
    }
    
    public override double GetValue()
    {
        return LeftSon.GetValue() * RightSon.GetValue();
    }
}