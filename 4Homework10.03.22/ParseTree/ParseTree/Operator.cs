namespace ParseTree;

/// <summary>
/// The type of node that stores the operation.
/// </summary>
public abstract class Operator : INode
{
    protected virtual char Value { get; set; }
    protected INode? Parent { get; set; }
    protected INode LeftSon { get; private set; } = new Guardian();
    protected INode RightSon { get; private set; } = new Guardian();
    public bool AreGuardian => false;


    public abstract float GetValue();

    public void PrintYourself()
    {
        Console.WriteLine($"({Value} ");
        LeftSon.PrintYourself();
        RightSon.PrintYourself();
        Console.WriteLine(") ");
    }

    public INode Add(string line)
    {
        if (LeftSon.AreGuardian)
        {
            if (float.TryParse(line, out float number))
            {
                LeftSon = new Operand(this, number);
                return this;
            }

            if (line.Length > 1)
            {
                throw new ExpressionProcessingException();
            }

            switch (line[0])
            {
                case '+':
                    LeftSon = new PlusOperator(this);
                    return LeftSon;
                case '-':
                    LeftSon = new MinusOperator(this);
                    return LeftSon;
                case '*':
                    LeftSon = new MultiplyOperator(this);
                    return LeftSon;
                case '/':
                    LeftSon = new DivideOperator(this);
                    return LeftSon;
                default:
                    throw new ExpressionProcessingException();
            }
        }
        if (RightSon.AreGuardian)
        {
            if (float.TryParse(line, out float number))
            {
                RightSon = new Operand(this, number);
                return this;
            }

            if (line.Length > 1)
            {
                throw new ExpressionProcessingException();
            }

            switch (line[0])
            {
                case '+':
                    RightSon = new PlusOperator(this);
                    return RightSon;
                case '-':
                    RightSon = new MinusOperator(this);
                    return RightSon;
                case '*':
                    RightSon = new MultiplyOperator(this);
                    return RightSon;
                case '/':
                    RightSon = new DivideOperator(this);
                    return RightSon;
                default:
                    throw new ExpressionProcessingException();
            }
        }

        if (Parent == null)
        {
            throw new ExpressionProcessingException();
        }

        return Parent.Add(line);
    }
}