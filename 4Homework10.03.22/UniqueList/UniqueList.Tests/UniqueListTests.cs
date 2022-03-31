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
}