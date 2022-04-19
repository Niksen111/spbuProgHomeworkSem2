namespace MapFilterFold;

/// <summary>
/// Contains 3 generic functions.
/// </summary>
/// <typeparam name="T">type of parameters</typeparam>
public static class MyClass<T>
{
    /// <summary>
    /// Transforms each item in the list according to a given rule
    /// </summary>
    /// <param name="list">Convertable list.</param>
    /// <param name="func">The rule.</param>
    /// <returns>Converted list.</returns>
    public static List<T> Map(List<T> list, Func<T, T> func) => list.Select(func).ToList();

    /// <summary>
    /// Leaves items in the list that match the rule.
    /// </summary>
    /// <param name="list">convertable list.</param>
    /// <param name="predicate">the rule.</param>
    /// <returns>converted list.</returns>
    public static List<T> Filter(List<T> list, Predicate<T> predicate) => list.FindAll(predicate);
    
    /// <param name="list">convertable list.</param>
    /// <param name="lastAcc">accumulated value.</param>
    /// <param name="func">function that converts a list.</param>
    /// <returns>the accumulated value obtained after the entire list pass.</returns>
    public static T Fold(List<T> list, T lastAcc, Func<T, T, T> func)
    {
        var currentElem = list.GetEnumerator();
        if (!currentElem.MoveNext())
        {
            return lastAcc;
        }
        T acc = func(lastAcc, currentElem.Current);
        while (currentElem.MoveNext())
        {
            acc = func(acc, currentElem.Current);
        }
        currentElem.Dispose();
        return acc;
    }
}