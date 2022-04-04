using System;

namespace SquareSorting;
internal class Program
{
    /// <summary>
    /// Checks if an array is sorted
    /// </summary>
    /// <param name="array">the sortable array</param>
    /// <returns>true if the array is sorted</returns>
    private static bool IsArraySorted(int[] array)
    {
        for (int i = 0; i < array.Length - 1; ++i)
        {
            if (array[i] > array[i + 1])
            {
                return false;
            }
        }

        return true;
    }
    
    /// <summary>
    /// Swaps two integer elements
    /// </summary>
    /// <param name="firstVariable"></param>
    /// <param name="secondVariable"></param>
    private static void Swap(ref int firstVariable, ref int secondVariable)
    {
        firstVariable ^= secondVariable;
        secondVariable ^= firstVariable;
        firstVariable ^= secondVariable;
    }
    
    /// <summary>
    /// Sorts an array by Bubble sorting
    /// </summary>
    /// <param name="array">the sortable array</param>
    private static void SortByBubble(int[] array)
    {
        for (int i = 0; i < array.Length; ++i)
        {
            for (int j = 0; j < array.Length - 1 - i; ++j)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(ref array[j], ref array[j + 1]);
                }
            }
        }
    }

    private static bool TestAreArraySorted()
    {
        var arrayTest1 = new[] { 5, 7, 4, -8, 1, 5 };
        var arrayTest2 = new [] { 0 };
        var arrayTest3 = new[] { -1, 2, 3, 4, 5 };

        return !IsArraySorted(arrayTest1) && IsArraySorted(arrayTest2)
                                          && IsArraySorted(arrayTest3);
    }
    private static bool TestSortByBubble()
    {
        var arrayTest1 = new [] { 5, 7, 4, -8, 0, 5 };
        var arrayTest2 = new [] { 0 };
        SortByBubble(arrayTest1);
        SortByBubble(arrayTest2);
        return IsArraySorted(arrayTest1) && IsArraySorted(arrayTest2);
    }
    
    public static int Main(string[] args)
    {
        if (!TestAreArraySorted() || !TestSortByBubble())
        {
            Console.WriteLine("Tests failed :(");
            return -1;
        }
        Console.WriteLine("Enter length of the array");
        int arrayLength = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the array separated by space");
        var arrayStrings = Console.ReadLine().Split(' ');
        var array = new int[arrayLength];
        for (int i = 0; i < arrayStrings.Length; ++i)
        {
            array[i] = Int32.Parse(arrayStrings[i]);
        }
        SortByBubble(array);
        Console.WriteLine("The array after sorting:");
        foreach (var element in array)
        {
            Console.Write($"{element} ");
        }
        return 0;
    }
}