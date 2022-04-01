using NUnit.Framework;

namespace Trie.Tests;

public class Tests
{

    [Test]
    public void TestTrieAddAndSize()
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
        
        Assert.IsTrue(result);
    }

    [Test]
    public void TestTrieContains()
    {
        Trie trie = new Trie();
        trie.Add(new string("cat"));
        trie.Add(new string("catland"));
        trie.Add(new string("dog"));
        trie.Add(new string(""));
        Assert.IsTrue(trie.Contains("cat") 
                      && trie.Contains("catland") 
                      && trie.Contains("dog") 
                      && trie.Contains("") 
                      && !trie.Contains("mouse") 
                      && !trie.Contains("catla"));
    }
    
    [Test]
    public void TestTrieRemove()
    {
        Trie trie = new Trie();
        bool result = !trie.Remove("") && trie.Size == 0;
        trie.Add(new string("cat"));
        trie.Add(new string("catland"));
        trie.Add(new string("dog"));
        trie.Add(new string(""));
        result = result && trie.Remove("") && trie.Size == 3
                 && !trie.Contains("");
        Assert.IsTrue(result && trie.Remove("cat")
                             && trie.Remove("catland") && trie.Remove("dog")
                             && !trie.Remove("mouse") && trie.Size == 0);
    }
    
    [Test]
    public void TestTrieHowManyStartsWithPrefix()
    {
        Trie trie = new Trie();
        trie.Add(new string("cat"));
        trie.Add(new string("catland"));
        trie.Add(new string("dog"));
        trie.Add(new string(""));
        trie.Add(new string("catland1"));
        Assert.IsTrue(trie.HowManyStartsWithPrefix("") == 5
                      && trie.HowManyStartsWithPrefix("d") == 1
                      && trie.HowManyStartsWithPrefix("dog") == 1
                      && trie.HowManyStartsWithPrefix("c") == 3
                      && trie.HowManyStartsWithPrefix("catl") == 2
                      && trie.HowManyStartsWithPrefix("catland") == 2
                      && trie.HowManyStartsWithPrefix("catland1") == 1
                      && trie.HowManyStartsWithPrefix("catland111") == 0);
    }
}