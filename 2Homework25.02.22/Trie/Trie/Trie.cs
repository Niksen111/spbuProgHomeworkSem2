namespace Trie;

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

        /// <summary>
        /// Number of words in the trie
        /// </summary>
        public int Size => Head.NumberOfWords;
        
        /// <summary>
        /// Added a string to the trie
        /// </summary>
        /// <param name="element">addable element</param>
        /// <returns>true if didn't contain the string before</returns>
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
        
        /// <summary>
        /// Checks if the trie contains the line
        /// </summary>
        /// <param name="element">element being checked</param>
        /// <returns>true if contained the line before</returns>
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
        /// <summary>
        /// Removes the element
        /// </summary>
        /// <param name="element">removable element</param>
        /// <returns>true if the element did contained</returns>
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
        /// <summary>number of the elements</summary>
        /// <param name="prefix">the prefix</param>
        /// <returns>number of words starts with the prefix</returns>
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