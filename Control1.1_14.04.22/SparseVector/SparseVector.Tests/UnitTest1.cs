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
        myVector.SetPosition(1, 2);
        Assert.IsTrue(result && myVector.GetPosition(1) == 2);
    }

    [Test]
    public void NullVectorIsNullAndNotNullVectorIsNotNull()
    {
        IVector myVector = new Vector(10);
        bool result = myVector.IsNull;
        myVector.SetPosition(2, 5);
        Assert.IsTrue(result && !myVector.IsNull);
    }

    [Test]
    public void ToArrayWorks()
    {
        IVector vector = new Vector(7);
        vector.SetPosition(2, 5);
        vector.SetPosition(5, -345);
        var convertedVector = vector.ToArray();
        bool result = convertedVector.Length == vector.Length;
        for (int i = 0; i < convertedVector.Length; ++i)
        {
            if (i == 2)
            {
                result = result && convertedVector[i] == 5;
            }
            else if (i == 5)
            {
                result = result && convertedVector[i] == -345;
            }
            else
            {
                result = result && convertedVector[i] == 0;
            }
        }
        Assert.IsTrue(result);
    }
}