namespace UniqueList;

public class UniqueList : MyList
{
    public override void Add(int value)
    {
        ListElement position = Head;
        for (int i = 0; i < length; ++i)
        {
            position = position.Next!;
            if (position.Value == value)
            {
                throw new AddingExistingValueException();
            }
        }
        base.Add(value);
    }

    public override void Insert(int value, int index)
    {
        ListElement position = Head;
        for (int i = 0; i < length; ++i)
        {
            position = position.Next!;
            if (position.Value == value)
            {
                throw new AddingExistingValueException();
            }
        }
        base.Insert(value, index);
    }
}