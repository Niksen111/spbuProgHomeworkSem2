namespace Sorter;

/// <summary>
/// SSorts and checks lists
/// </summary>
/// <typeparam name="T">comparison function</typeparam>
public static class Sorter<T>
{

    /// <summary>
    /// Sorts the list of objects by the given comparison function
    /// </summary>
    /// <param name="list">sortable list</param>
    /// <param name="comparer">comparison function</param>
    /// <returns>sorted list</returns>
    public static IList<T> SortByBubble(IList<T> list, IComparer<T> comparer)
    {
        for (int i = 0; i < list.Count; ++i)
        {
            for (int j = 0; j + i < list.Count - 1; ++j)
            {
                if (comparer.Compare(list[j], list[j + 1]) < 0)
                {
                    (list[j], list[j + 1]) = (list[j + 1], list[j]);
                }
            }
        }

        return list;
    }

    /// <summary>
    /// Checks if the list is sorted relative to the given comparison function
    /// </summary>
    /// <param name="list">checklist</param>
    /// <param name="comparer">comparison function</param>
    /// <returns>result of comparison</returns>
    public static bool AreListSorted(IList<T> list, IComparer<T> comparer)
    {
        for (int i = 0; i < list.Count - 1; ++i)
        {
            if (comparer.Compare(list[i], list[i + 1]) < 0)
            {
                return false;
            }
        }

        return true;
    }
}
