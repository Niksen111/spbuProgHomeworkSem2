using System.Collections.Generic;
using NUnit.Framework;

namespace ParseTree.Tests;

public class OperatorsTests
{
    private static IEnumerable<TestCaseData> Operators => new TestCaseData[]
    {
        new TestCaseData(new PlusOperator(null)),
        new TestCaseData(new MinusOperator(null)),
        new TestCaseData(new MultiplyOperator(null)),
        new TestCaseData(new DivideOperator(null)),
    };

    [TestCaseSource(nameof(Operators))]
    public void OperatorsDoNotAddThreeElements(INode node)
    {
        node.Add("54");
        node.Add("45");
        Assert.Throws<ExpressionProcessingException>(() =>node.Add("99"));
    }

    [TestCaseSource(nameof(Operators))]
    public void OperatorsDoNotAcceptInvalidStrings(INode node)
    {
        Assert.Throws<ExpressionProcessingException>(() =>node.Add("-==-"));
        Assert.Throws<ExpressionProcessingException>(() =>node.Add("425.35.325"));
        Assert.Throws<ExpressionProcessingException>(() =>node.Add("."));
        Assert.Throws<ExpressionProcessingException>(() =>node.Add("\\"));
        Assert.Throws<ExpressionProcessingException>(() =>node.Add("."));
    }

    [Test]
    public void PlusOperatorAddsUp()
    {
        var plusOperator = new PlusOperator(null);
        plusOperator.Add("58");
        plusOperator.Add("999");
        Assert.IsTrue(plusOperator.GetValue() - 1057 < 0.0001f);
        plusOperator = new PlusOperator(null);
        plusOperator.Add("58");
        plusOperator.Add("-999");
        Assert.IsTrue(plusOperator.GetValue() + 941 < 0.0001f);
    }
    
    [Test]
    public void MinusOperatorSubtracts()
    {
        var minusOperator = new MinusOperator(null);
        minusOperator.Add("58");
        minusOperator.Add("999");
        Assert.IsTrue(minusOperator.GetValue() + 941< 0.0001f);
        minusOperator = new MinusOperator(null);
        minusOperator.Add("58");
        minusOperator.Add("-999");
        Assert.IsTrue(minusOperator.GetValue() - 1057 < 0.0001f);
    }
    
    [Test]
    public void MultiplyOperatorMultiplies()
    {
        var multiplyOperator = new MultiplyOperator(null);
        multiplyOperator.Add("111");
        multiplyOperator.Add("3");
        Assert.IsTrue(multiplyOperator.GetValue() - 333 < 0.0001f);
        multiplyOperator = new MultiplyOperator(null);
        multiplyOperator.Add("0.5");
        multiplyOperator.Add("-222");
        Assert.IsTrue(multiplyOperator.GetValue() + 111 < 0.0001f);
    }
    
    [Test]
    public void DivideOperatorDivides()
    {
        var divideOperator = new DivideOperator(null);
        divideOperator.Add("999");
        divideOperator.Add("-111");
        Assert.IsTrue(divideOperator.GetValue() + 9 < 0.0001f);
        divideOperator = new DivideOperator(null);
        divideOperator.Add("1");
        divideOperator.Add("-2");
        Assert.IsTrue(divideOperator.GetValue() + 0.5 < 0.0001f);
    }
}