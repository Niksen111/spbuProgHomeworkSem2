
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

        public float? Top { get => _head?.Value; }
        
        public bool IsEmpty { get => _head == null; }
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
        
        public float? Top { get => _filled == 0 ? null : _myArray[_filled - 1]; }
        
        public bool IsEmpty { get => _filled == 0; }
    }

    public class StackCalculator
    {
        public StackCalculator()
        {
            _myStack = new ListStack();
        }
        private IStack _myStack;
        
        /// <summary>
        /// 1 for ListStack
        /// 2 for ArrayStack
        /// </summary>
        /// <param name="numberOfStack"></param>
        public void ChangeStack(int numberOfStack)
        {
            if (numberOfStack == 1)
            {
                _myStack = new ListStack();
                return;
            }

            if (numberOfStack == 2)
            {
                _myStack = new ArrayStack();
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
            return 0;
        }
    }
}
