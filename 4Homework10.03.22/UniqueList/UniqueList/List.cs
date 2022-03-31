
namespace UniqueList;

public class MyList
{
    private class ListElement
    {
        public ListElement(int value, ListElement? next)
        {
            Value = value;
            Next = next;
        }
        public int Value { get; set; }
        public ListElement? Next { get; set; }
    }

    public MyList()
    {
        _head = new ListElement(0, null);
        _lastElement = _head;
        _length = 0;
    }
    
    private readonly ListElement _head;
    private ListElement _lastElement;
    private int _length;
    public int Length => _length;

    public void Add(int value)
    {
        ++_length;
        ListElement newListElement = new ListElement(value, null);
        _lastElement.Next = newListElement;
        _lastElement = newListElement;
    }
    
    public void Insert(int value, int index)
    {
        if (index > Length || index < 0)
        {
            throw new IndexOutOfRangeException();
        }
        
        ++_length;
        ListElement position = _head;
        for (int i = 0; i < index; ++i)
        {
            position = position.Next!;
        }

        ListElement newListElement = new ListElement(value, position.Next);
        position.Next = newListElement;
    }

    public void SetPosition(int value, int index)
    {
        if (index >= Length || index < 0)
        {
            throw new IndexOutOfRangeException();
        }
        ListElement position = _head;
        for (int i = 0; i < index + 1; ++i)
        {
            position = position.Next!;
        }

        position.Value = value;
    }

    public int Remove(int index)
    {
        if (index >= Length || index < 0)
        {
            throw new IndexOutOfRangeException();
        }
        
        --_length;
        ListElement position = _head;
        for (int i = 0; i < index; ++i)
        {
            position = position.Next!;
        }

        int value = position.Next!.Value;
        position.Next = position.Next.Next;
        return value;
    }

    public int Get(int index)
    {
        if (index >= Length || index < 0)
        {
            throw new IndexOutOfRangeException();
        }
        
        ListElement position = _head;
        for (int i = 0; i < index; ++i)
        {
            if (position.Next != null)
            {
                position = position.Next;
            }
        }
        
        return position.Next!.Value;
    }
}