
namespace UniqueList;

public class MyList
{
    protected class ListElement
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
        Head = new ListElement(0, null);
        LastElement = Head;
        length = 0;
    }
    
    protected readonly ListElement Head;
    protected ListElement LastElement;
    protected int length;
    public int Length => length;

    public virtual void Add(int value)
    {
        ++length;
        ListElement newListElement = new ListElement(value, null);
        LastElement.Next = newListElement;
        LastElement = newListElement;
    }
    
    public virtual void Insert(int value, int index)
    {
        if (index > Length || index < 0)
        {
            throw new IndexOutOfRangeException();
        }
        
        ++length;
        ListElement position = Head;
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
        ListElement position = Head;
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
            throw new RemoveNonExistentElementException();
        }
        
        --length;
        ListElement position = Head;
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
        
        ListElement position = Head;
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