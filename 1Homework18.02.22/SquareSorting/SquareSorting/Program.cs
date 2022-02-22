using System;

namespace SquareSorting
{
    internal class Program
    {
        private static bool AreArraySorted(int[] array)
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
        private static void Swap(ref int firstVariable, ref int secondVariable)
        {
            firstVariable ^= secondVariable;
            secondVariable ^= firstVariable;
            firstVariable ^= secondVariable;
        }
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
            int[] arrayTest1 = new[] { 5, 7, 4, -8, 1, 5 };
            int[] arrayTest2 = new[] { 0 };
            int[] arrayTest3 = new[] { -1, 2, 3, 4, 5 };

            return !AreArraySorted(arrayTest1) && AreArraySorted(arrayTest2)
                                               && AreArraySorted(arrayTest3);
        }
        private static bool TestSortByBubble()
        {
            int[] arrayTest1 = new int[] { 5, 7, 4, -8, 0, 5 };
            int[] arrayTest2 = new int[] { 0 };
            SortByBubble(arrayTest1);
            SortByBubble(arrayTest2);
            return AreArraySorted(arrayTest1) && AreArraySorted(arrayTest2);
        }
        
        public static int Main(string[] args)
        {
            if (!TestAreArraySorted() || !TestSortByBubble())
            {
                Console.WriteLine("Tests failed :(");
                return -1;
            }
            Console.WriteLine("Enter lenght of the array");
            int arrayLength = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the array separated by space");
            var arrayStrings = Console.ReadLine().Split(' ');
            int[] array = new int[arrayLength];
            for (int i = 0; i < arrayStrings.Length; ++i)
            {
                array[i] = Int32.Parse(arrayStrings[i]);
            }
            SortByBubble(array);
            Console.WriteLine("The array after sorting:");
            for (int i = 0; i < array.Length; ++i)
            {
                Console.Write("{0} ", array[i]);
            }
            return 0;
        }
    }
}