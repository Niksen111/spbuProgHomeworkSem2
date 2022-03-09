
namespace StackCalculator
{
    interface IStack
    {
        void Push(int number);

        int Pop { get; }
        
        int Top { get; }
        
        bool IsEmpty { get; }
    }

    public class StackOnPointers
    {
        
    }
}
