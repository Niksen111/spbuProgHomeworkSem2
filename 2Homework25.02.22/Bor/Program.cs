using System;



namespace Bor
{
    interface IBorFunctions
    {
        bool Add(string element);
        bool Contains(string element);
        bool Remove(string element);
        int HowManyStartsWithPrefix(String prefix);
    }
    class Vertex : IBorFunctions
    {
        public Vertex()
        {
            this.next = new Vertex[65536];
            this.isTerminal = true;
        }

        private Vertex[] next;
        private bool isTerminal;

        public bool Add(string element)
        {
            //if ()
            return true;
        }

        public bool Contains(string element)
        {
            return true;
        }

        public bool Remove(string element)
        {
            return true;
        }

        public int HowManyStartsWithPrefix(String prefix)
        {
            return 1;
        }
    }

    internal class Program
    {
        public static int Main(string[] args)
        {
            int x = (int) Math.Pow((double) 2, (double) 8 * sizeof(char));
            Console.WriteLine("{0}", x);
            return 0;
        }
    }
}