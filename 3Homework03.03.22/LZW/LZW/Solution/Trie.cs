namespace LZW.Solution;

public class Trie
    {
        private class Node
        {
            public Node()
            {
                Next = new Dictionary<byte, Node>();
            }
            public short NumberOfWords;
            public bool IsTerminal;
            public Dictionary<byte, Node> Next;
        }
        public Trie()
        {
            Head = new Node();
        }

        private Node Head;

        public int Size => Head.NumberOfWords;
        
        public bool Add(byte[] element)
        {
            Node position = Head;
            foreach (byte b in element)
            {
                if (!position.Next.ContainsKey(b))
                {
                    Node newNode = new Node();
                    position.Next.Add(b, newNode);
                }

                position = position.Next[b];
            }

            bool result = !position.IsTerminal;
            if (result)
            {
                position = Head;
                foreach (byte b in element)
                {
                    ++position.NumberOfWords;
                    position = position.Next[b];
                }
                ++position.NumberOfWords;
            }
            position.IsTerminal = true;
            return result;
        }

        public bool Contains(byte[] element)
        {
            Node position = Head;
            foreach (byte b in element)
            {
                if (!position.Next.ContainsKey(b))
                {
                    return false;
                }

                position = position.Next[b];
            }
            return position.IsTerminal;
        }

        public bool Remove(byte[] element)
        {
            Node position = Head;
            Node lastWord = Head;
            byte nextSymbol = 0;
            foreach (byte b in element)
            {
                if (!position.Next.ContainsKey(b))
                {
                    return false;
                }

                if (position.IsTerminal)
                {
                    lastWord = position;
                    nextSymbol = b;
                }
                position = position.Next[b];
            }

            if (!position.IsTerminal)
            {
                return false;
            }
            
            position = Head;
            foreach (byte b in element)
            {
                --position.NumberOfWords;
                position = position.Next[b];
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

        public int HowManyStartsWithPrefix(byte[] prefix)
        {
            Node position = Head;
            foreach (byte b in prefix)
            {
                if (!position.Next.ContainsKey(b))
                {
                    return 0;
                }

                position = position.Next[b];
            }
            return position.NumberOfWords;
        }
    }