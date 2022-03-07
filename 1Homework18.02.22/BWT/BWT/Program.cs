using System;
using System.Text;

namespace BWT
{
    internal class Program
    {
        private static void Swap(ref int variable1, ref int variable2)
        {
            variable1 ^= variable2;
            variable2 ^= variable1;
            variable1 ^= variable2;
        }

        private static bool AreArraysEquals(int[] array1, int[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; ++i)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }
        
        // Using heap sorting sorts a segment of the array,
        // which is a list of indexes of the characters of the transmitted word
        // Shift - the index of the character in the words, by which the sorting is currently performed
        private static void HeapSort(int[] arrayIndexes, string line, int shift, int start, int end)
        {
            for (int i = start + 1; i <= end; ++i)
            {
                int j = i;
                while (j != start)
                {
                    int parent = j - start % 2 == 0 ? start + (j - start - 2) / 2 : start + (j - start - 1) / 2;
                    // Character Code Comparison
                    if (line[(arrayIndexes[parent] + shift) % line.Length] < line[(arrayIndexes[j] + shift) % line.Length])
                    {
                        Swap(ref arrayIndexes[parent], ref arrayIndexes[j]);
                        j = parent;
                    }
                    else
                    {
                        j = start;
                    }
                }
            }

            for (int i = end; i > start; --i)
            {
                Swap(ref arrayIndexes[start], ref arrayIndexes[i]);
                int j = start;
                while (start + (j - start) * 2 + 1 <= i - 1)
                {
                    if (start + (j - start) * 2 + 2 <= i - 1)
                    {
                        if (line[(arrayIndexes[start + (j - start) * 2 + 1] + shift) % line.Length] >=
                            line[(arrayIndexes[start + (j - start) * 2 + 2] + shift) % line.Length])
                        {
                            if (line[(arrayIndexes[j] + shift) % line.Length] <
                                line[(arrayIndexes[start + (j - start) * 2 + 1] + shift) % line.Length])
                            {
                                Swap(ref arrayIndexes[j], ref arrayIndexes[start + (j - start) * 2 + 1]);
                                j = start + (j - start) * 2 + 1;
                            }
                            else
                            {
                                j = i;
                            }
                        }
                        else
                        {
                            if (line[(arrayIndexes[j] + shift) % line.Length] <
                                line[(arrayIndexes[start + (j - start) * 2 + 2] + shift) % line.Length])
                            {
                                Swap(ref arrayIndexes[j], ref arrayIndexes[start + (j - start) * 2 + 2]);
                                j = start + (j - start) * 2 + 2;
                            }
                            else
                            {
                                j = i;
                            }
                        }
                    }
                    else
                    {
                        if (line[(arrayIndexes[j] + shift) % line.Length] < line[(arrayIndexes[start + (j - start) * 2 + 1] + shift) % line.Length])
                        {
                            Swap(ref arrayIndexes[j], ref arrayIndexes[start + (j - start) * 2 + 1]);
                        }

                        j = i;
                    }
                }
            }
        }

        private static void InsertionSort(int[] arrayIndexes, string line, int shift, int start, int end)
        {
            for (int i = start + 1; i <= end; ++i)
            {
                for (int j = i; j > start; --j)
                {
                    if (line[(arrayIndexes[j] + shift) % line.Length] <
                        line[(arrayIndexes[j - 1] + shift) % line.Length])
                    {
                        Swap(ref arrayIndexes[j], ref arrayIndexes[j - 1]);
                    }
                }
            }
        }

        private static void SortLines(int[] arrayIndexes, string line, int shift, int start, int end)
        {
            if (start >= end || shift >= line.Length)
            {
                return;
            }
            HeapSort(arrayIndexes, line, shift, start, end);
            char currentSymbol = line[(arrayIndexes[start] + shift) % line.Length];
            int begin = start;
            for (int i = start + 1; i <= end; ++i)
            {
                if (line[(arrayIndexes[i] + shift) % line.Length] != currentSymbol)
                {
                    SortLines(arrayIndexes, line, shift + 1, begin, i - 1);
                    currentSymbol = line[(arrayIndexes[i] + shift) % line.Length];
                    begin = i;
                }
            }
            SortLines(arrayIndexes, line, shift + 1, begin, end);
        }
        private static (string, int) BWT(string line)
        {
            int[] arrayIndexes = new int[line.Length];
            for (int i = 0; i < line.Length; ++i)
            {
                arrayIndexes[i] = i;
            }

            int key = 0;
            SortLines(arrayIndexes, line, 0, 0, line.Length - 1);
            char[] result = new char[line.Length];
            for (int i = 0; i < line.Length; ++i)
            {
                if (arrayIndexes[i] == 0)
                {
                    key = i;
                }

                result[i] = line[(arrayIndexes[i] + line.Length - 1) % line.Length];
            }
            return (new string(result), key);
        }

        private static string InverseBWT(string line, int key)
        {
            if (line == null || line.Length == 0)
            {
                return line;
            }
            int[] characterOffset = new int[line.Length];
            for (int i = 0; i < line.Length; ++i)
            {
                characterOffset[i] = i;
            }
            InsertionSort(characterOffset, line, 0, 0, line.Length - 1);
            char[] result = new char[line.Length];
            result[0] = line[characterOffset[key]];
            int lastIndex = characterOffset[key];
            for (int i = 1; i < line.Length; ++i)
            {
                result[i] = line[characterOffset[lastIndex]];
                lastIndex = characterOffset[lastIndex];
            }
            
            return new string(result);
        }

        private static bool TestHeapSort()
        {
            var line = "ABACABAAAA";
            var array1 = new int[10] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            var array2 = new int[10] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            var array1Answer = new int[10] {9, 8, 0, 4, 2, 6, 7, 5, 1, 3};
            var array2Answer = new int[10] {0, 1, 2, 3, 5, 4, 7, 8, 6, 9};
            HeapSort(array1, line, 0, 0, 9);
            HeapSort(array2, line, 2, 4, 9);
            return AreArraysEquals(array1, array1Answer) && AreArraysEquals(array2, array2Answer);
        }
        
        private static bool TestInsertionSort()
        {
            var line = "ABACABAAAA";
            var array1 = new int[10] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            var array2 = new int[10] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            var array1Answer = new int[10] {0, 2, 4, 6, 7, 8, 9, 1, 5, 3};
            var array2Answer = new int[10] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            InsertionSort(array1, line, 0, 0, 9);
            InsertionSort(array2, line, 2, 4, 9);
            return AreArraysEquals(array1, array1Answer) && AreArraysEquals(array2, array2Answer);
        }
        private static bool TestBWT()
        {
            var string1 = "ABACABA";
            var string1Answer = "BCABAAA";
            int index1 = 0;
            int index1Answer = 2;
            var string2 = "mississippi";
            var string2Answer = "pssmipissii";
            int index2 = 0;
            int index2Answer = 4;
            var string3 = "";
            var string3Answer = "";
            int index3 = 0;
            (string1, index1) = BWT(string1);
            (string2, index2) = BWT(string2);
            (string3, index3) = BWT(string3);
            return String.Compare(string1, string1Answer) == 0
                && String.Compare(string2, string2Answer) == 0
                && String.Compare(string3, string3Answer) == 0
                && index1 == index1Answer && index2 == index2Answer;
        }

        private static bool TestInverseBWT()
        {
            var string1Answer = "ABACABA";
            var string1 = "BCABAAA";
            int index1 = 2;
            var string2Answer = "mississippi";
            var string2 = "pssmipissii";
            int index2 = 4;
            var string3 = "";
            var string3Answer = "";
            int index3 = 0;
            string1 = InverseBWT(string1, index1);
            string2 = InverseBWT(string2, index2);
            string3 = InverseBWT(string3, index3);
            return String.Compare(string1, string1Answer) == 0
                   && String.Compare(string2, string2Answer) == 0
                   && String.Compare(string3, string3Answer) == 0;
        }
        
        public static int Main(string[] args)
        {
            if (!TestHeapSort() || !TestInsertionSort() || !TestBWT() || !TestInverseBWT())
            {
                Console.WriteLine("Tests failed");
                return -1;
            }
            Console.WriteLine("Enter a string without spaces:");
            var input = Console.ReadLine();
            if (input == null)
            {
                Console.WriteLine("Input error");
                return -1;
            }
            int key = 0;
            (input, key) = BWT(input);
            if (key == -1)
            {
                Console.WriteLine("BTW failed");
                return -1;
            }
            Console.WriteLine("The string after BWT: {0}", input);
            Console.WriteLine("The key: {0}", key);
            input = InverseBWT(input, key);
            Console.WriteLine("The string after Inverse BWT: {0}", input);
            return 0;
        }
    }
}