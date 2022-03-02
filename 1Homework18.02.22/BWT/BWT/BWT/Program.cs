using System;

namespace BWT
{
    internal class Program
    {
        private static string BWT(string line, ref int number)
        {
            return line;
        }

        private static string InverseBWT(string line, ref int number)
        {
            return line;
        }

        private static bool TestBWT()
        {
            var string1 = "ABACABA";
            var string1Answer = "BCABAAA";
            int number1 = 0;
            int number1Answer = 3;
            var string2 = "mississippi";
            var string2Answer = "ipssmpissii";
            int number2 = 0;
            int number2Answer = 6;
            string1 = BWT(string1, ref number1);
            string2 = BWT(string2, ref number2);
            return String.Compare(string1, string1Answer) == 0
                && String.Compare(string2, string2Answer) == 0
                && number1 == number1Answer && number2 == number2Answer;
        }

        private static bool TestInverseBWT()
        {
            var string1Answer = "ABACABA";
            var string1 = "BCABAAA";
            int number1 = 3;
            var string2Answer = "mississippi";
            var string2 = "ipssmpissii";
            int number2 = 6;
            string1 = BWT(string1, ref number1);
            string2 = BWT(string2, ref number2);
            return String.Compare(string1, string1Answer) == 0
                   && String.Compare(string2, string2Answer) == 0
                   && number1 != -1 && number2 != -1;
        }
        
        public static int Main(string[] args)
        {
            if (!TestBWT() || !TestInverseBWT())
            {
                System.Console.WriteLine("Tests failed");
                return -1;
            }
            var input = System.Console.ReadLine();
            if (input == null)
            {
                System.Console.WriteLine("Input error");
                return -1;
            }
            int number = 0;
            BWT(input, ref number);
            if (number == -1)
            {
                System.Console.WriteLine("BTW failed");
                return -1;
            }
            System.Console.WriteLine("");
            input = InverseBWT(input, ref number);
            if (number == -1)
            {
                System.Console.WriteLine("Inverse BTW failed");
                return -1;
            }
            System.Console.WriteLine("");
            return 0;
        }
    }
}