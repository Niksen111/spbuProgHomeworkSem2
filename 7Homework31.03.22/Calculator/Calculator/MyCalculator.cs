

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
        _firstNumber = "+0";
        _secondNumber = "+0";
    }

    private string Operate()
    {
        switch (_operation)
        {
            case '+':
                return (float.Parse(_firstNumber) + float.Parse(_secondNumber) >= 0 ? "+" : "") 
                    + (float.Parse(_firstNumber) + float.Parse(_secondNumber)).ToString();
            case '-':
                return (float.Parse(_firstNumber) - float.Parse(_secondNumber) >= 0 ? "+" : "")
                    + (float.Parse(_firstNumber) - float.Parse(_secondNumber)).ToString();
            case '*':
                return (float.Parse(_firstNumber) * float.Parse(_secondNumber) >= 0 ? "+" : "")
                    + (float.Parse(_firstNumber) * float.Parse(_secondNumber)).ToString();
            case '/':
                if (float.Parse(_secondNumber) < 0.000000001 && _secondNumber[0] == '+')
                {
                    throw new DivideByZeroException();
                }
                return (float.Parse(_firstNumber) / float.Parse(_secondNumber) >= 0 ? "+" : "")
                    + (float.Parse(_firstNumber) / float.Parse(_secondNumber)).ToString();
            default:
                throw new InvalidOperationException();
        }

    }

    public string MakeAction(char action)
    {
        if (action == 'C')
        {
            _firstNumber = "+0";
            _secondNumber = "+0";
            _operation = '\0';
            _state = 1;
            return "0";
        }
        switch (_state)
        {
            case 1:
                if (new List<char> { '+', '-', '*', '/' }.Contains(action))
                {
                    _operation = action;
                    _state = 3;
                    return "0";
                }
                else if (action >= '0' && action <= '9')
                {
                    if (_firstNumber.Length > 18)
                    {
                        return float.Parse(_firstNumber).ToString();
                    }
                    if (!(_firstNumber.Length == 2 && action == '0'))
                    {
                        _firstNumber += action;
                        return float.Parse(_firstNumber).ToString();
                    }
                }
                else if (action == ',')
                {
                    _state = 2;
                    _firstNumber += action;
                }
                else if (action == '!')
                {
                    // ---------------
                    _firstNumber = _firstNumber.Replace(_firstNumber[0], _firstNumber[0] == '+' ? '-' : '+');
                    return float.Parse(_firstNumber).ToString();
                }
                else if (action == '=')
                {
                    _state = 5;
                }

                return float.Parse(_firstNumber).ToString();

            case 2:
                if (new List<char> { '+', '-', '*', '/' }.Contains(action))
                {
                    _operation = action;
                    _state = 3;
                    return "0";
                }
                else if (action >= '0' && action <= '9')
                {
                    if (_firstNumber.Length > 18)
                    {
                        return float.Parse(_firstNumber).ToString();
                    }
                    if (!(_firstNumber.Length == 2 && action == '0'))
                    {
                        _firstNumber += action;
                        return float.Parse(_firstNumber).ToString();
                    }
                }
                else if (action == '!')
                {
                    // ---------------
                    _firstNumber = _firstNumber.Replace(_firstNumber[0], _firstNumber[0] == '+' ? '-' : '+');
                    return float.Parse(_firstNumber).ToString();
                }
                else if (action == '=')
                {
                    _state = 5;
                }

                return float.Parse(_firstNumber).ToString();

            case 3:
                if (new List<char> { '+', '-', '*', '/' }.Contains(action))
                {
                    try
                    {
                        _firstNumber = Operate();
                    }
                    catch(DivideByZeroException exeption)
                    {
                        _firstNumber = "+0";
                        _state = 1;
                        _secondNumber = "+0";
                        _operation = '\0';
                        return "Divided by zero :(";
                    }
                    _secondNumber = "+0";
                    _operation = action;
                    return float.Parse(_secondNumber).ToString();
                }
                else if (action >= '0' && action <= '9')
                {
                    if (_secondNumber.Length > 18)
                    {
                        return float.Parse(_secondNumber).ToString();
                    }
                    if (!(_secondNumber.Length == 2 && action == '0'))
                    {
                        _secondNumber += action;
                        return float.Parse(_secondNumber).ToString();
                    }
                }
                else if (action == ',')
                {
                    _state = 4;
                    _secondNumber += action;
                }
                else if (action == '!')
                {
                    // ---------------
                    _secondNumber = _secondNumber.Replace(_secondNumber[0], _secondNumber[0] == '+' ? '-' : '+');
                    return float.Parse(_secondNumber).ToString();
                }
                else if (action == '=')
                {
                    _state = 5;
                    try
                    {
                        _firstNumber = Operate();
                    }
                    catch (DivideByZeroException exeption)
                    {
                        _firstNumber = "+0";
                        _state = 1;
                        _secondNumber = "+0";
                        _operation = '\0';
                        return "Divided by zero :(";
                    }
                    _secondNumber = "+0";
                    return float.Parse(_firstNumber).ToString();
                }

                return float.Parse(_secondNumber).ToString();

            case 4:
                if (new List<char> { '+', '-', '*', '/' }.Contains(action))
                {
                    try
                    {
                        _firstNumber = Operate();
                    }
                    catch (DivideByZeroException exeption)
                    {
                        _firstNumber = "+0";
                        _state = 1;
                        _secondNumber = "+0";
                        _operation = '\0';
                        return "Divided by zero :(";
                    }
                    _secondNumber = "+0";
                    _operation = action;
                    _state = 3;
                    return float.Parse(_secondNumber).ToString();
                }
                else if (action >= '0' && action <= '9')
                {
                    if (_secondNumber.Length > 18)
                    {
                        return float.Parse(_secondNumber).ToString();
                    }
                    if (!(_secondNumber.Length == 2 && action == '0'))
                    {
                        _secondNumber += action;
                        return float.Parse(_secondNumber).ToString();
                    }
                }
                else if (action == '!')
                {
                    // ---------------
                    _secondNumber = _secondNumber.Replace(_secondNumber[0], _secondNumber[0] == '+' ? '-' : '+');
                    return float.Parse(_secondNumber).ToString();
                }
                else if (action == '=')
                {
                    _state = 5;
                    try
                    {
                        _firstNumber = Operate();
                    }
                    catch (DivideByZeroException exeption)
                    {
                        _firstNumber = "+0";
                        _state = 1;
                        _secondNumber = "+0";
                        _operation = '\0';
                        return "Divided by zero :(";
                    }
                    _secondNumber = "+0";
                    return float.Parse(_firstNumber).ToString();
                }

                return float.Parse(_secondNumber).ToString();

            case 5:
                if (new List<char> { '+', '-', '*', '/' }.Contains(action))
                {
                    _operation = action;
                    _state = 3;
                    return "0";
                }
                else if (action == '!')
                {
                    // ---------------
                    _firstNumber = _firstNumber.Replace(_firstNumber[0], _firstNumber[0] == '+' ? '-' : '+');
                    return float.Parse(_firstNumber).ToString();
                }
                else if (action >= '0' && action <= '9')
                {
                    _firstNumber = "+" + action;
                    _state = 1;
                    return float.Parse(_firstNumber).ToString();
                }
                else if (action == ',')
                {
                    _firstNumber = "+0,";
                    _state = 2;
                    return "0,";
                }

                return float.Parse(_firstNumber).ToString();

            default:
                return float.Parse(_firstNumber).ToString();
        }
    }
}

