namespace ParseTree;

/// <summary>
/// Node corresponding to the division operation.
/// </summary>
public class DivideOperator : Operator
{
    public DivideOperator(INode? parent)
    {
        Parent = parent;
        Value = '/';
    }

    public override float GetValue()
    {
        if (Math.Abs(RightSon.GetValue()) < 0.000001)
        {
            throw new DivideByZeroException();
        }
        return LeftSon.GetValue() / RightSon.GetValue();
    }
}