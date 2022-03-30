namespace ParseTree.Solution;

public class MinusOperator : Operator
{
    public MinusOperator(INode? parent)
    {
        Parent = parent;
        Value = '-';
    }

    public override double GetValue()
    {
        return LeftSon.GetValue() - RightSon.GetValue();
    }
}