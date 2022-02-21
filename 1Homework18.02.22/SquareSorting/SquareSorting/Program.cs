using System;

namespace SquareSorting
{
    internal class Program
    {
        public static bool AreArraySorted(int[] array)
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
        public static void Swap(ref int firstVariable, ref int secondVariable)
        {
            firstVariable ^= secondVariable;
            secondVariable ^= firstVariable;
            firstVariable ^= secondVariable;
        }
        public static void SortByBubble(int[] array)
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

        public static bool TestAreArraySorted()
        {
            int[] arrayTest1 = new[] { 5, 7, 4, -8, 1, 5 };
            int[] arrayTest2 = new[] { 0 };
            int[] arrayTest3 = new[] { -1, 2, 3, 4, 5 };

            return !AreArraySorted(arrayTest1) && AreArraySorted(arrayTest2)
                                               && AreArraySorted(arrayTest3);
        }
        public static bool TestSortByBubble()
        {
            int[] arrayTest1 = new int[] { 5, 7, 4, -8, 1, 5 };
            int[] arrayTest2 = new int[] { 0 };
            SortByBubble(arrayTest1);
            SortByBubble(arrayTest2);
            return AreArraySorted(arrayTest1) && AreArraySorted(arrayTest2);
        }
        
        public static void Main(string[] args)
        {
            if (!TestAreArraySorted() || !TestSortByBubble())
            {
                Console.WriteLine("Tests failed :(");
                return;
            }
            var inputString = Console.ReadLine();
            int arrayLength = int.Parse(inputString);
            int[] array = new int[arrayLength];
            
            SortByBubble(array);
            for (int i = 0; i < array.Length; ++i)
            {
                Console.Write("{0} ", array[i]);
            }
        }
    }
}