using NUnit.Framework;

namespace ParseTree.Tests;

public class OperandTests
{
    private INode _node = new Operand(null, 3.1415f);
    [SetUp]
    public void SetUp()
    {
        _node = new Operand(null, 3.1415f);
    }
    
    [Test]
    public void OperandCreatedAndReturnsValue()
    {
        Assert.IsTrue(_node.GetValue() - 3.1415f < 0.001f);
    }

    [Test]
    public void OperandWithoutParentFallsWhenAdding()
    {
        Assert.Throws<ExpressionProcessingException>(() => _node.Add("3"));
    }
}