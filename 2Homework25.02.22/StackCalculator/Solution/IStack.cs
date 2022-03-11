namespace StackCalculator.Solution;

interface IStack
{
    void Push(float number);

    float? Pop();
    
    float? Top { get; }
    
    bool IsEmpty { get; }

}