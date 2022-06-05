namespace UniqueList;

/// <summary>
/// A list of integer variables that does not store repeating values.
/// </summary>
public class UniqueList : MyList
{
    /// <summary>
    /// Adds the item to the list if it is not in the list.
    /// </summary>
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

    /// <summary>
    /// Gets the element at the given index.
    /// Sets the element at the given index if the new value not contained in the list.
    /// </summary>
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
    
    /// <summary>
    /// Inserts an item into this list by the given index, if it was not contained in the list.
    /// </summary>
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