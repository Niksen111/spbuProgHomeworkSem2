namespace MapFilterFold;

/// <summary>
/// Contains 3 generic functions.
/// </summary>
public static class MyClass
{
    /// <summary>
    /// Transforms each item in the list according to a given rule
    /// </summary>
    /// <param name="list">Convertable list.</param>
    /// <param name="func">The rule.</param>
    /// <returns>Converted list.</returns>
    public static List<T2> Map<T1, T2>(List<T1> list, Func<T1, T2> func)
    {
        var newList = new List<T2>();
        foreach (var element in list)
        {
            newList.Add(func(element));
        }

        return newList;
    }

    /// <summary>
    /// Leaves items in the list that match the rule.
    /// </summary>
    /// <param name="list">convertable list.</param>
    /// <param name="predicate">the rule.</param>
    /// <returns>converted list.</returns>
    public static List<T> Filter<T>(List<T> list, Predicate<T> predicate)
    {
        var newList = new List<T>();
        foreach (var element in list)
        {
            if (predicate(element))
            {
                newList.Add(element);
            }
        }

        return newList;
    }
    
    /// <param name="list">convertable list.</param>
    /// <param name="lastAcc">accumulated value.</param>
    /// <param name="func">function that converts a list.</param>
    /// <returns>the accumulated value obtained after the entire list pass.</returns>
    public static T2 Fold<T1, T2>(List<T1> list, T2 lastAcc, Func<T2, T1, T2> func)
    {
        if (list.Count == 0)
        {
            return lastAcc;
        }
        T2 acc = lastAcc;
        
        foreach (var element in list)
        {
            acc = func(acc, element);
        }
        
        return acc;
    }
}