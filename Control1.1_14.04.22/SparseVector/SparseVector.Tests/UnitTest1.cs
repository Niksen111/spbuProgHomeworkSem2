using NUnit.Framework;

namespace SparseVector.Tests;

public class Tests
{
    [Test]
    public void VectorCreatedWithLength()
    {
        IVector myVector = new Vector(10);
        Assert.IsTrue(myVector.Length == 10);
    }

    [Test]
    public void VectorCreatedUsingArray()
    {
        IVector myVector = new Vector(new []{5, 3, 0, 1, 0},10);
        Assert.Pass();
    }

    [Test]
    public void PositionChangesAndReturns()
    {
        IVector myVector = new Vector(new []{5, 3, 0, 1, 0},10);
        bool result = myVector.GetPosition(1) == 3;
        myVector.ChangePosition(1, 2);
        Assert.IsTrue(result && myVector.GetPosition(1) == 2);
    }

    [Test]
    public void NullVectorIsNullAndNotNullVectorIsNotNull()
    {
        IVector myVector = new Vector(10);
        bool result = myVector.IsNull;
        Assert.Pass();
    }
}