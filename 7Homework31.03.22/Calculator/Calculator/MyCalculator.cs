

namespace Calculator;

public class MyCalculator
{
    private int _state;
    private string _firstNumber;
    private string _secondNumber;
    private char _operation;

    public MyCalculator()
    {
        _state = 1;
    }

    private string Operate()
    {
        switch (_operation)
        {
            case '+':
                return (float.Parse(_firstNumber) + float.Parse(_secondNumber)).ToString();
            case '-':
                return (float.Parse(_firstNumber) - float.Parse(_secondNumber)).ToString();
            case '*':
                return (float.Parse(_firstNumber) * float.Parse(_secondNumber)).ToString();
            case '/':
                if (float.Parse(_secondNumber) < 0.000000001 && _secondNumber[0] == '+')
                {
                    throw new DivideByZeroException();
                }
                return (float.Parse(_firstNumber) / float.Parse(_secondNumber)).ToString();
            default:
                throw new DivideByZeroException();
        }

    }
}

