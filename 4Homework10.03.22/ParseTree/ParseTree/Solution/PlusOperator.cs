namespace ParseTree.Solution;

public class PlusOperator : Operator
{
    public PlusOperator(INode? parent)
    {
        Parent = parent;
        Value = '+';
    }
    
    public override double GetValue()
    {
        return LeftSon.GetValue() + RightSon.GetValue();
    }
    
}