using System.Collections;

namespace UniqueList;

public class MyList
{
    private class ListElement
    {
        public ListElement(int value, ListElement? next, bool areGuardian)
        {
            Value = value;
            Next = next;
            AreGuardian = areGuardian;
        }
        public int Value { get; set; }
        public ListElement? Next { get; set; }
        public bool AreGuardian { get; set; }
    }

    public MyList()
    {
        Head = new ListElement(0, null, true);
        _length = 0;
    }
    
    private readonly ListElement Head;
    private int _length;
    public int Length => _length;

    public void Insert(int value, uint index)
    {
        if (index >= Length)
        {
            throw new IndexOutOfRangeException();
        }
        
        ++_length;
        ListElement position = Head;
        for (int i = 0; i < index; ++i)
        {
            position = position.Next;
        }

        ListElement newListElement = new ListElement(value, position.Next,false);
        position.Next = newListElement;
    }

    public void SetPosition(int value, uint index)
    {
        if (index >= Length)
        {
            throw new IndexOutOfRangeException();
        }
        ListElement position = Head;
        for (int i = 0; i < index + 1; ++i)
        {
            position = position.Next;
        }

        position.Value = value;
    }

    public int Remove(uint index)
    {
        if (index >= Length)
        {
            throw new IndexOutOfRangeException();
        }
        
        --_length;
        ListElement position = Head;
        for (int i = 0; i < index; ++i)
        {
            position = position.Next;
        }

        int value = position.Next.Value;
        position.Next = position.Next.Next;
        return value;
    }
}