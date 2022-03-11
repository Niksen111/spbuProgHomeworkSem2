
namespace StackCalculator
{
    interface IStack
    {
        void Push(float number);

        float? Pop();
        
        float? Top { get; }
        
        bool IsEmpty { get; }

    }

    public class ListStack : IStack
    {
        private class StackElement
        {
            public float Value;
            public StackElement? Next;
        }

        private StackElement? _head;

        public void Push(float number)
        {
            var newElement = new StackElement();
            newElement.Value = number;
            newElement.Next = _head;
            _head = newElement;
        }

        public float? Pop()
        {
            float? value = _head?.Value;
            if (_head != null) 
                _head = _head.Next;
            return value;
        }

        public float? Top => _head?.Value;
        
        public bool IsEmpty => _head == null;
    }

    public class ArrayStack : IStack
    {
        public ArrayStack()
        {
            _myArray = new float[10];
            _length = 10;
        }

        private float[] _myArray;
        private int _length;
        private int _filled;

        public void Push(float number)
        {
            if (_filled == _length)
            {
                Array.Resize(ref _myArray, _length * 2);
                _length *= 2;
            }

            _myArray[_filled] = number;
            ++_filled;
        }

        public float? Pop()
        {
            if (_filled == 0)
            {
                return null;
            }

            --_filled;
            return _myArray[_filled];
        }
        
        public float? Top => _filled == 0 ? null : _myArray[_filled - 1];
        
        public bool IsEmpty => _filled == 0; 
    }

    public class StackCalculator
    {
        public enum TypesOfStacks
        {
            ArrayStack,
            ListStack
        }

        /// <summary>
        /// 1 for ArrayStack
        /// 2 for ListStack
        /// </summary>
        /// <param name="typeOfStack"></param>
        public StackCalculator(TypesOfStacks typeOfStack = TypesOfStacks.ArrayStack)
        {
            _myStack = new ArrayStack();

            if (typeOfStack == TypesOfStacks.ListStack)
            {
                _myStack = new ListStack();
            }
        }
        private IStack _myStack;

        /// <summary>
        /// 1 for ArrayStack
        /// 2 for ListStack
        /// </summary>
        /// <param name="typeOfStack"></param>
        public void ChangeStack(TypesOfStacks typeOfStack)
        {
            if (typeOfStack == TypesOfStacks.ArrayStack)
            {
                _myStack = new ArrayStack();
                return;
            }

            if (typeOfStack == TypesOfStacks.ListStack)
            {
                _myStack = new ListStack();
            }
        }
        
        /// <summary>
        /// Takes an expression in reverse Polish notation.
        /// Returns null if the expression contains any error.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public float? CalculateExpression(string expression)
        {
            var expressionFixed = expression.Split();
            int number;
            foreach (var piece in expressionFixed)
            {
                if (int.TryParse(piece, out number))
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
                    return variable1 - variable2;
                case '*':
                    return variable1 * variable2;
                case '/':
                    if (Math.Abs((float) variable2) < 0.0001)
                    {
                        return null;
                    }
                    return variable1 / variable2;
                default:
                    return null;
            }
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            var x = new StackCalculator();
            x.ChangeStack(StackCalculator.TypesOfStacks.ListStack);
            
            return;
        }
    }
}
