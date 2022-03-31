using NUnit.Framework;

namespace UniqueList.Tests;

public class Tests
{
    private MyList _list = new MyList();
    [SetUp]
    public void Setup()
    {
        _list = new MyList();
    }

    [Test]
    public void ElementsAddedAndGet()
    {
        _list.Add(6);
        _list.Add(-532);
        _list.Add(0);
        Assert.IsTrue(_list.Get(0) == 6 && _list.Get(1) == -532 && _list.Get(2) == 0);
    }

    [Test]
    public void ElementsInsertedInTheRightOrder()
    {
        _list.Add(1);
        _list.Insert(2, 0);
        _list.Insert(3, 2);
        Assert.IsTrue(_list.Get(0) == 2 && _list.Get(1) == 1 && _list.Get(2) == 3);
    }

    [Test]
    public void ElementsSets()
    {
        _list.Add(6);
        _list.Add(-532);
        _list.Add(0);
        _list.SetPosition(35, 1);
        _list.SetPosition(111, 2);
        Assert.IsTrue(_list.Get(0) == 6 && _list.Get(1) == 35 && _list.Get(2) == 111);
    }

    [Test]
    public void RemoveWorks()
    {
        _list.Add(6);
        _list.Add(-532);
        _list.Add(222);
        _list.Remove(1);
        Assert.IsTrue(_list.Get(0) == 6 && _list.Get(1) == 222);
    }

    [Test]
    public void LengthWorks()
    {
        bool result = _list.Length == 0;
        _list.Add(545);
        result = result && _list.Length == 1;
        _list.Insert(-666, 0);
        result = result && _list.Length == 2;
        _list.SetPosition(235, 0);
        result = result && _list.Length == 2;
        _list.Remove(0);
        result = result && _list.Length == 1;
        Assert.IsTrue(result);
    }
}