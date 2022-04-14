namespace MapFilterFold;

public class MyClass
{
    public List<T> Map<T>(List<T> list, Func<T, T> func) => (List<T>) list.Select(func);

    public List<T> Filter<T>(List<T> list, Predicate<T> predicate) => list.FindAll(predicate);

    public T Fold<T>(List<T> list, T lastAcc, Func<(T, T), T> func)
    {
        var currentElem = list.GetEnumerator();
        T acc = func((lastAcc, currentElem.Current));
        while (currentElem.MoveNext())
        {
            acc = func((acc, currentElem.Current));
        }
        currentElem.Dispose();
        return acc;
    }
}