using NUnit.Framework;

namespace Trie.Tests;

public class Tests
{

    [Test]
    public void TestTrieAddAndSize()
    {
        var trie = new Trie();
        Assert.AreEqual(trie.Size, 0);
        trie.Add("cat");
        Assert.AreEqual(trie.Size, 1);
        trie.Add("catland");
        Assert.AreEqual(trie.Size, 2);
        trie.Add("dog");
        Assert.AreEqual(trie.Size, 3);
        trie.Add("");
        Assert.AreEqual(trie.Size, 4);
    }

    [Test]
    public void TestTrieContains()
    {
        var trie = new Trie();
        trie.Add("cat");
        trie.Add("catland");
        trie.Add("dog");
        trie.Add("");
        Assert.IsTrue(trie.Contains("cat"));
        Assert.IsTrue(trie.Contains("catland"));
        Assert.IsTrue(trie.Contains("dog"));
        Assert.IsTrue(trie.Contains(""));
        Assert.IsTrue(!trie.Contains("mouse"));
        Assert.IsTrue(!trie.Contains("catla"));
    }
    
    [Test]
    public void TestTrieRemove()
    {
        var trie = new Trie();
        Assert.IsTrue(!trie.Remove(""));
        Assert.AreEqual(trie.Size, 0);
        trie.Add("cat");
        trie.Add("catland");
        trie.Add("dog");
        trie.Add("");
        Assert.IsTrue(trie.Remove(""));
        Assert.AreEqual(trie.Size, 3);
        Assert.IsTrue(!trie.Contains(""));
        
        Assert.IsTrue(trie.Remove("cat"));
        Assert.IsTrue(trie.Remove("catland"));
        Assert.IsTrue(trie.Remove("dog"));
        Assert.IsFalse(trie.Remove("mouse"));
        Assert.AreEqual(trie.Size, 0);
    }
    
    [Test]
    public void TestTrieHowManyStartsWithPrefix()
    {
        var trie = new Trie();
        trie.Add("cat");
        trie.Add("catland");
        trie.Add("dog");
        trie.Add("");
        trie.Add("catland1");
        Assert.AreEqual(trie.HowManyStartsWithPrefix(""), 5);
        Assert.AreEqual(trie.HowManyStartsWithPrefix("d"), 1);
        Assert.AreEqual(trie.HowManyStartsWithPrefix("dog"), 1);
        Assert.AreEqual(trie.HowManyStartsWithPrefix("c"), 3);
        Assert.AreEqual(trie.HowManyStartsWithPrefix("catl"), 2);
        Assert.AreEqual(trie.HowManyStartsWithPrefix("catland"), 2);
        Assert.AreEqual(trie.HowManyStartsWithPrefix("catland1"), 1);
        Assert.AreEqual(trie.HowManyStartsWithPrefix("catland111"), 0);
    }

    [Test]
    public void Kek()
    {
        var trie = new Trie();
        trie.Add("a");
        trie.Add("aaa");
        trie.Add("aab");
        trie.Remove("aab");
        
        Assert.Pass();
    }
}