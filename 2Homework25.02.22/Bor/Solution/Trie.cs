namespace Bor.Solution;

public class Trie
    {
        private class Node
        {
            public Node()
            {
                this.Next = new Dictionary<char, Node>();
            }
            public short NumberOfWords;
            public bool IsTerminal;
            public Dictionary<char, Node> Next;
        }
        public Trie()
        {
            Head = new Node();
        }

        private Node Head;

        public int Size => Head.NumberOfWords;
        
        public bool Add(string element)
        {
            Node position = Head;
            foreach (char c in element)
            {
                if (!position.Next.ContainsKey(c))
                {
                    Node newNode = new Node();
                    position.Next.Add(c, newNode);
                }

                position = position.Next[c];
            }

            bool result = !position.IsTerminal;
            if (result)
            {
                position = Head;
                foreach (char c in element)
                {
                    ++position.NumberOfWords;
                    position = position.Next[c];
                }
                ++position.NumberOfWords;
            }
            position.IsTerminal = true;
            return result;
        }

        public bool Contains(string element)
        {
            Node position = Head;
            foreach (char c in element)
            {
                if (!position.Next.ContainsKey(c))
                {
                    return false;
                }

                position = position.Next[c];
            }
            return position.IsTerminal;
        }

        public bool Remove(string element)
        {
            Node position = Head;
            Node lastWord = Head;
            char nextSymbol = '\0';
            foreach (char c in element)
            {
                if (!position.Next.ContainsKey(c))
                {
                    return false;
                }

                if (position.IsTerminal)
                {
                    lastWord = position;
                    nextSymbol = c;
                }
                position = position.Next[c];
            }

            if (!position.IsTerminal)
            {
                return false;
            }
            
            position = Head;
            foreach (char c in element)
            {
                --position.NumberOfWords;
                position = position.Next[c];
            }

            --position.NumberOfWords;
            position.IsTerminal = false;
            if (position.Next.Count != 0)
            {
                return true;
            }

            lastWord.Next.Remove(nextSymbol);
            return true;
        }

        public int HowManyStartsWithPrefix(String prefix)
        {
            Node position = Head;
            foreach (char c in prefix)
            {
                if (!position.Next.ContainsKey(c))
                {
                    return 0;
                }

                position = position.Next[c];
            }
            return position.NumberOfWords;
        }
    }