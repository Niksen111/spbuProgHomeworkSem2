using NUnit.Framework;
using ParseTree.Solution;

namespace ParseTree.Tests;
public class NodeTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void OperandCreatedAndReturnsValue()
    {
        INode node = new Operand(null, 2.5);
        Assert.AreEqual(node.GetValue(), 2.5);
    }

    [TestCase(2, 3)]
    public void OperatorsAreExecutedCorrectly(double variable1, double variable2)
    {
        
    }
    
    
}