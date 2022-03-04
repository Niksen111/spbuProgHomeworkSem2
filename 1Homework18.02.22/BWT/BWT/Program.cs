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
                while (j < i)
                {
                    if (i - j >= 2)
                    {
                        if (line[(arrayIndexes[j + 1] + shift) % line.Length] >=
                            line[(arrayIndexes[j + 2] + shift) % line.Length])
                        {
                            if (line[(arrayIndexes[j] + shift) % line.Length] <
                                line[(arrayIndexes[j + 1] + shift) % line.Length])
                            {
                                Swap(ref arrayIndexes[j], ref arrayIndexes[j + 1]);
                                ++j;
                            }
                            else
                            {
                                j = i;
                            }
                        }
                        else
                        {
                            if (line[(arrayIndexes[j] + shift) % line.Length] <
                                line[(arrayIndexes[j + 2] + shift) % line.Length])
                            {
                                Swap(ref arrayIndexes[j], ref arrayIndexes[j + 2]);
                                j += 2;
                            }
                            else
                            {
                                j = i;
                            }
                        }
                    }
                    else
                    {
                        if (line[(arrayIndexes[j] + shift) % line.Length] < line[(arrayIndexes[j + 1] + shift) % line.Length])
                        {
                            Swap(ref arrayIndexes[j], ref arrayIndexes[j + 1]);
                        }

                        j = i;
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
            return line;
        }

        private static bool TestBWT()
        {
            var string1 = "ABACABA";
            var string1Answer = "BCABAAA";
            int index1 = 0;
            int index1Answer = 3;
            var string2 = "mississippi";
            var string2Answer = "ipssmpissii";
            int index2 = 0;
            int index2Answer = 6;
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
            int index1 = 3;
            var string2Answer = "mississippi";
            var string2 = "ipssmpissii";
            int index2 = 6;
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
            var input = Console.ReadLine();
            if (input == null)
            {
                Console.WriteLine("Input error");
                return -1;
            }
            int index = 0;
            BWT(input, ref index);
            if (index == -1)
            {
                Console.WriteLine("BTW failed");
                return -1;
            }
            Console.WriteLine("");
            input = InverseBWT(input, ref index);
            if (index == -1)
            {
                Console.WriteLine("Inverse BTW failed");
                return -1;
            }
            Console.WriteLine("");
            return 0;
        }
    }
}