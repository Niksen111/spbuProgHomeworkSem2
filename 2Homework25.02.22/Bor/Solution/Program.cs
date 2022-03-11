namespace Bor.Solution;

internal class Program
{
    private static bool TestTrieAddAndSize()
    {
        Trie trie = new Trie();
        bool result = trie.Size == 0;
        trie.Add(new string("cat"));
        result = result && trie.Size == 1;
        trie.Add(new string("catland"));
        result = result && trie.Size == 2;
        trie.Add(new string("dog"));
        result = result && trie.Size == 3;
        trie.Add(new string(""));
        result = result && trie.Size == 4;

        return result;
    }

    private static bool TestTrieContains()
    {
        Trie trie = new Trie();
        trie.Add(new string("cat"));
        trie.Add(new string("catland"));
        trie.Add(new string("dog"));
        trie.Add(new string(""));
        return trie.Contains("cat") && trie.Contains("catland")
            && trie.Contains("dog") && trie.Contains("")
            && !trie.Contains("mouse") && !trie.Contains("catla");
    }

    private static bool TestTrieRemove()
    {
        Trie trie = new Trie();
        bool result = !trie.Remove("") && trie.Size == 0;
        trie.Add(new string("cat"));
        trie.Add(new string("catland"));
        trie.Add(new string("dog"));
        trie.Add(new string(""));
        result = result && trie.Remove("") && trie.Size == 3
                 && !trie.Contains("");
        return result && trie.Remove("cat")
              && trie.Remove("catland") && trie.Remove("dog")
              && !trie.Remove("mouse") && trie.Size == 0;
    }

    private static bool TestTrieHowManyStartsWithPrefix()
    {
        Trie trie = new Trie();
        trie.Add(new string("cat"));
        trie.Add(new string("catland"));
        trie.Add(new string("dog"));
        trie.Add(new string(""));
        trie.Add(new string("catland1"));
        return trie.HowManyStartsWithPrefix("") == 5
               && trie.HowManyStartsWithPrefix("d") == 1
               && trie.HowManyStartsWithPrefix("dog") == 1
               && trie.HowManyStartsWithPrefix("c") == 3
               && trie.HowManyStartsWithPrefix("catl") == 2
               && trie.HowManyStartsWithPrefix("catland") == 2
               && trie.HowManyStartsWithPrefix("catland1") == 1
               && trie.HowManyStartsWithPrefix("catland111") == 0;
    }
    public static int Main(string[] args)
    {
        if (!TestTrieAddAndSize() || !TestTrieContains() || !TestTrieRemove()
            || !TestTrieHowManyStartsWithPrefix())
        {
            Console.WriteLine("Tests falied:(");
            return -1;
        }
        Console.WriteLine("All ok :)");
        return 0;
    }
}