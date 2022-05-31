namespace StackCalculator;

/// <summary>
/// stack interface
/// </summary>
public interface IStack
{
    /// <summary>
    /// Pushes the number to the head of the stack
    /// </summary>
    /// <param name="number">the number</param>
    void Push(float number);
    
    /// <summary>
    /// Pop element from the head of the stack or null if the stack is empty
    /// </summary>
    float? Pop();
    
    /// <summary>
    /// Returns the element from the head of the stack or null if the stack is empty
    /// </summary>
    float? Top { get; }
    
    /// <summary>
    /// Returns true if the stack is empty
    /// </summary>
    bool IsEmpty { get; }
}