namespace UniqueList;

/// <summary>
/// List of int elements
/// </summary>
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

    /// <summary>
    /// Describing how many elements are in the List.
    /// </summary>
    public int Length => _length;

    /// <summary>
    /// Adds the given element to the end of this list.
    /// </summary>
    public virtual void Add(int value)
    {
        ++_length;
        var newListElement = new ListElement(value, null);
        _lastElement.Next = newListElement;
        _lastElement = newListElement;
    }
    
    /// <summary>
    /// Inserts an element into this list at a given index.
    /// </summary>
    public virtual void Insert(int value, int index)
    {
        if (index > _length || index < 0)
        {
            throw new IndexOutOfRangeException();
        }
        
        ++_length;
        var position = _head;
        for (int i = 0; i < index; ++i)
        {
            position = position.Next!;
        }

        var newListElement = new ListElement(value, position.Next);
        position.Next = newListElement;
    }

    /// <summary>
    /// Sets or Gets the element at the given index.
    /// </summary>
    public virtual int this[int index]
    {
        get
        {
            if (index >= _length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
        
            var position = _head;
            for (int i = 0; i < index; ++i)
            {
                if (position.Next != null)
                {
                    position = position.Next;
                }
            }
        
            return position.Next!.Value;
        }
        set
        {
            if (index >= _length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            var position = _head;
            for (int i = 0; i < index + 1; ++i)
            {
                position = position.Next!;
            }

            position.Value = value;
        }
    }

    /// <summary>
    /// Removes the element at the given index.
    /// </summary>
    /// <returns>removed element</returns>
    public int Remove(int index)
    {
        if (index >= _length || index < 0)
        {
            throw new RemoveNonExistentElementException();
        }
        
        --_length;
        var position = _head;
        for (int i = 0; i < index; ++i)
        {
            position = position.Next!;
        }

        int value = position.Next!.Value;
        position.Next = position.Next.Next;
        return value;
    }
}