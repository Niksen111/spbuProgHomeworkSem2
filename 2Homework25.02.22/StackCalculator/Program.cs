
namespace StackCalculator
{
    interface IStack
    {
        void Push(int number);

        int Pop { get; }
        
        int Top { get; }
        
        bool IsEmpty { get; }
        
    }

    public class StackOnPointers : IStack
    {
        private class StackElement
        {
            public StackElement()
            {
                Next = new StackElement();
            }

            public int Value;
            public StackElement Next;
        }

        public StackOnPointers()
        {
            this = new StackElement();
        }


    }
}
