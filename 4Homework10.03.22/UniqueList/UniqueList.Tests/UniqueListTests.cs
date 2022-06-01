using NUnit.Framework;

namespace UniqueList.Tests;

public class UniqueListTests
{
    private UniqueList _list = new UniqueList();

    [SetUp]
    public void SetUp()
    {
        _list = new UniqueList();
    }

    [Test]
    public void OnlyNecessaryValuesAdded()
    {
        _list.Add(4);
        _list.Add(3);
        
        Assert.Throws<AddingExistingValueException>(() => _list.Add(4));

        _list.Remove(0);
        _list.Add(4);
    }

    [Test]
    public void OnlyDesiredValuesInserted()
    {
        _list.Add(4);
        _list.Add(3);
        
        Assert.Throws<AddingExistingValueException>(() => _list.Insert(4, 1));

        _list.Add(8);
        _list.Remove(0);
        _list.Insert(4, 1);
    }

    [Test]
    public void RepetitiveValuesNotSet()
    {
        _list.Add(8);
        _list.Add(-88);
        _list.Add(888);

        Assert.Throws<AddingExistingValueException>(() => _list[1] = 8);
        
        Assert.AreEqual(_list[1], -88);
        _list[1] = -8;
        Assert.AreEqual(_list[1], -8);
    }
}