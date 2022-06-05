namespace ParseTree;

/// <summary>
/// Node corresponding to the subtraction operation/
/// </summary>
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