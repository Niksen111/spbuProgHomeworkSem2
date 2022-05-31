namespace ParseTree;

public class MinusOperator : Operator
{
    public MinusOperator(INode? parent)
    {
        Parent = parent;
        Value = '-';
    }

    public override float GetValue()
    {
        return LeftSon.GetValue() - RightSon.GetValue();
    }
}