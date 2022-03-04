using System;
using System.Text;

namespace BWT
{
    internal class Program
    {
        private static void Swap(ref int firstVariable, ref int secondVariable)
        {
            firstVariable ^= secondVariable;
            secondVariable ^= firstVariable;
            firstVariable ^= secondVariable;
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
                        Swap(ref arrayIndexes[j], ref arrayIndexes[j + 1]);
                    }
                }
            }
        }

        private static void SortLines(int[] arrayIndexes, string line, int shift, int start, int end)
        {
            if (start >= end)
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
        private static string BWT(string line, ref int index)
        {
            int[] arrayIndexes = new int[line.Length];
            for (int i = 0; i < line.Length; ++i)
            {
                arrayIndexes[i] = i;
            }
            SortLines(arrayIndexes, line, 0, 0, line.Length - 1);
            char[] result = new char[line.Length];
            for (int i = 0; i < line.Length; ++i)
            {
                if (arrayIndexes[i] == 0)
                {
                    index = i;
                }

                result[i] = line[(arrayIndexes[i] + line.Length - 1) % line.Length];
            }
            return new string(result);
        }

        private static string InverseBWT(string line, ref int index)
        {
            // int[] characterOffset = new int[line.Length];
            // for (int i = 0; i < line.Length; ++i)
            // {
            //     characterOffset[i] = i;
            // }
            // InsertionSort(characterOffset, line, 0, 0, line.Length - 1);
            // int[] arrayIndexes = new int[line.Length];
            // Array.Copy(characterOffset, arrayIndexes, line.Length);
            // int[] buffer = new int[line.Length];
            // for (int i = 0; i < line.Length; ++i)
            // {
            //     for (int j = 0; j < line.Length; ++j)
            //     {
            //         buffer[i] = arrayIndexes[characterOffset[i]];
            //     }
            //     Array.Copy(arrayIndexes, buffer, line.Length);
            // }
            return line;
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
            string1 = BWT(string1, ref index1);
            string2 = BWT(string2, ref index2);
            string3 = BWT(string3, ref index3);
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
            string1 = InverseBWT(string1, ref index1);
            string2 = InverseBWT(string2, ref index2);
            string3 = InverseBWT(string3, ref index3);
            return String.Compare(string1, string1Answer) == 0
                   && String.Compare(string2, string2Answer) == 0
                   && String.Compare(string3, string3Answer) == 0
                   && index1 != -1 && index2 != -1 && index3 != -1;
        }
        
        public static int Main(string[] args)
        {
            // || !TestInverseBWT()
            if (!TestBWT() )
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
            BWT(input, ref key);
            if (key == -1)
            {
                Console.WriteLine("BTW failed");
                return -1;
            }
            Console.WriteLine("The string after BWT: {0}", input);
            Console.WriteLine("The key: {0}", key);
            input = InverseBWT(input, ref key);
            if (key == -1)
            {
                Console.WriteLine("Inverse BWT failed");
                return -1;
            }
            Console.WriteLine("The string after Inverse BWT: {0}", input);
            return 0;
        }
    }
}