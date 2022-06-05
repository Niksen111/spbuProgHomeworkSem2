namespace Trie;

/// <summary>
/// data structure for storing a set of strings
/// </summary>
public class Trie
{
    private class Node
    {
        public Node()
        {
            Next = new Dictionary<char, Node>();
        }
        
        public short NumberOfWords;
        public bool IsTerminal;
        public Dictionary<char, Node> Next;
    }
    
    public Trie()
    {
        _head = new Node();
    }

    private readonly Node _head;

    /// <summary>
    /// Number of words in the trie
    /// </summary>
    public int Size => _head.NumberOfWords;
    
    /// <summary>
    /// Added a string to the trie
    /// </summary>
    /// <param name="element">addable element</param>
    /// <returns>true if didn't contain the string before</returns>
    public bool Add(string element)
    {
        var position = _head;
        foreach (char c in element)
        {
            if (!position.Next.ContainsKey(c))
            {
                var newNode = new Node();
                position.Next.Add(c, newNode);
            }

            position = position.Next[c];
        }

        var result = !position.IsTerminal;
        if (result)
        {
            position = _head;
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
        var position = _head;
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
        var position = _head;
        var lastFork = _head;
        char nextSymbol = '\0';
        foreach (char c in element)
        {
            if (!position.Next.ContainsKey(c))
            {
                return false;
            }

            if (position.Next.Count > 1)
            {
                lastFork = position;
                nextSymbol = c;
            }
            position = position.Next[c];
        }

        if (!position.IsTerminal)
        {
            return false;
        }
        
        position = _head;
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
        
        lastFork.Next.Remove(nextSymbol);
        return true;
    }
    
    /// <summary>number of the elements</summary>
    /// <param name="prefix">the prefix</param>
    /// <returns>number of words starts with the prefix</returns>
    public int HowManyStartsWithPrefix(String prefix)
    {
        var position = _head;
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