using System;
using NUnit.Framework;

namespace StackCalculator.Tests;

[TestFixture]
public class StackCalculatorTests
{
    private StackCalculator _calculator = new StackCalculator(new ArrayStack());
    
    [SetUp]
    public void Setup()
    {
        _calculator = new StackCalculator(new ListStack());
    }

    [Test]
    public void CalculateExpression()
    {
        var expression = "5 97 333 3 / - * 17 / 0 +";
        Assert.IsNotNull(_calculator.CalculateExpression(expression));
        float result = (float) _calculator.CalculateExpression(expression)!;
        Assert.IsTrue(Math.Abs(result + 4.117647) < 0.0001);
    }

    [Test]
    public void DivisionByZero()
    {
        var expression = "333 0 /";
        Assert.IsNull(_calculator.CalculateExpression(expression));
    }

    [Test]
    public void UnnecessaryOperations()
    {
        var expression = "333 0 4 5 6 1 / + + + + + + +";
        Assert.IsNull(_calculator.CalculateExpression(expression));
    }

    [Test]
    public void IncorrectOperation()
    {
        var expression = "42 124 54 + 99 ^ 8 - +";
        Assert.IsNull(_calculator.CalculateExpression(expression));
    }
    
}