namespace ParseTree.Solution;

public abstract class Operator : INode
{
    protected char Value;
    protected INode? Parent;
    protected INode LeftSon = new Guardian();
    protected INode RightSon = new Guardian();
    public bool AreGuardian => false;


    public abstract double GetValue();

    public void PrintYourself()
    {
        Console.WriteLine("({0} ", Value);
        LeftSon.PrintYourself();
        RightSon.PrintYourself();
        Console.WriteLine(") ");
    }

    public INode Add(string line)
    {
        if (LeftSon.AreGuardian)
        {
            if (double.TryParse(line, out double number))
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
            if (double.TryParse(line, out double number))
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