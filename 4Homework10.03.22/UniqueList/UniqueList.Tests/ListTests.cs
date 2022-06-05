namespace UniqueList.Tests;

using NUnit.Framework;

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
        Assert.AreEqual(_list[0], 6);
        Assert.AreEqual(_list[1], -532);
        Assert.AreEqual(_list[2], 0);
    }

    [Test]
    public void ElementsInsertedInTheRightOrder()
    {
        _list.Add(1);
        _list.Insert(2, 0);
        _list.Insert(3, 2);
        Assert.AreEqual(_list[0], 2); 
        Assert.AreEqual(_list[1], 1); 
        Assert.AreEqual(_list[2], 3);
    }

    [Test]
    public void ElementsSets()
    {
        _list.Add(6);
        _list.Add(-532);
        _list.Add(0);
        _list[1] = 35;
        _list[2] = 111;
        Assert.AreEqual(_list[0], 6);
        Assert.AreEqual(_list[1], 35); 
        Assert.AreEqual(_list[2], 111);
    }

    [Test]
    public void RemoveWorks()
    {
        _list.Add(6);
        _list.Add(-532);
        _list.Add(222);
        _list.Remove(1);
        Assert.AreEqual(_list[0], 6); 
        Assert.AreEqual(_list[1], 222);
    }

    [Test]
    public void LengthWorks()
    {
        Assert.AreEqual(_list.Length, 0);
        _list.Add(545);
        Assert.AreEqual(_list.Length, 1);
        _list.Insert(-666, 0);
        Assert.AreEqual(_list.Length, 2);
        _list[0] = 235;
        Assert.AreEqual(_list.Length, 2);
        _list.Remove(0);
        Assert.AreEqual(_list.Length, 1);
    }
}