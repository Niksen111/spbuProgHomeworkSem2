using NUnit.Framework;

namespace SkipList.Tests;

public class SkipListTests
{
    private SkipList<string> _list = new();

    [SetUp]
    public void Setup()
    {
        _list = new SkipList<string>();
    }

    [Test]
    public void AddAndContainsWorks()
    {
        _list.Add("abc");
        _list.Add("lol");
        _list.Add("12345");
        Assert.IsTrue(_list.Contains("abc"));
        Assert.IsTrue(_list.Contains("lol"));
        Assert.IsTrue(_list.Contains("12345"));
        Assert.IsFalse(_list.Contains("ldskajg"));
    }

    [Test]
    public void RemoveWorks()
    {
        _list.Add("abc");
        _list.Add("lol");
        _list.Add("12345");
        Assert.IsTrue(_list.Contains("abc"));
        _list.Remove("abc");
        Assert.IsFalse(_list.Contains("abc"));
    }

    [Test]
    public void ForeachWorks()
    {
        _list.Add("abc");
        _list.Add("lol");
        _list.Add("12345");
        int i = 0;
        foreach (var x in _list)
        {
            ++i;
        }
        Assert.AreEqual(i, 3);
    }
}