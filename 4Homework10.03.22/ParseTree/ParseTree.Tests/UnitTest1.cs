using NUnit.Framework;
namespace ParseTree.Tests;
using Solution;
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        ParseTree x = new ParseTree();
        int m = x.X;
        Assert.AreEqual(m, 0);
    }
}