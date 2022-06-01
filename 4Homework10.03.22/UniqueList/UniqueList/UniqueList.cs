namespace UniqueList;

public class UniqueList : MyList
{
    public override void Add(int value)
    {
        for (int i = 0; i < Length; ++i)
        {
            if (this[i] == value)
            {
                throw new AddingExistingValueException();
            }
        }
        base.Add(value);
    }

    public override void Insert(int value, int index)
    {
        for (int i = 0; i < Length; ++i)
        {
            if (this[i] == value)
            {
                throw new AddingExistingValueException();
            }
        }
        base.Insert(value, index);
    }

    public override int this[int index]
    {
        get => base[index];
        set
        {
            for (int i = 0; i < Length; ++i)
            {
                if (this[i] == value)
                {
                    throw new AddingExistingValueException();
                }
            }

            base[index] = value;
        }
    }
}