namespace StackCalculator;

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