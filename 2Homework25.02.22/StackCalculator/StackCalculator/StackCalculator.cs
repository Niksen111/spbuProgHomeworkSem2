namespace StackCalculator;

/// <summary>
/// calculates expressions in prefix form
/// </summary>
public class StackCalculator
{
    /// <summary>
    /// accepts the stack with which it will make calculations
    /// </summary>
    public StackCalculator(IStack stack)
    {
        _myStack = stack;
    }
    
    private readonly IStack _myStack;
    
    
    /// <summary>
    /// Takes an expression in reverse Polish notation.
    /// Returns null if the expression contains any error.
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public float? CalculateExpression(string expression)
    {
        var expressionFixed = expression.Split();
        foreach (var piece in expressionFixed)
        {
            if (int.TryParse(piece, out int number))
            {
                _myStack.Push(number);
            }
            else if (piece.Length == 1)
            {
                float? resultOfOperation = Calculate(piece[0]);
                if (resultOfOperation == null)
                {
                    return null;
                }
                _myStack.Push((float) resultOfOperation);
            }
            else return null;
        }

        float? result = _myStack.Pop();
        if (result == null || !_myStack.IsEmpty)
        {
            return null;
        }
        return result;
    }

    private float? Calculate(char operation)
    {
        float? variable1 = _myStack.Pop();
        float? variable2 = _myStack.Pop();
        if (variable1 == null || variable2 == null)
        {
            return null;
        }
        switch (operation)
        {
            case '+':
                return variable1 + variable2;
            case '-':
                return variable2 - variable1;
            case '*':
                return variable1 * variable2;
            case '/':
                if (Math.Abs((float) variable1) < 0.0001)
                {
                    return null;
                }
                return variable2 / variable1;
            default:
                return null;
        }
    }
}