using System;
using NUnit.Framework;

namespace StackCalculator.Tests;

[TestFixture]
public class StackCalculatorTests
{
    private StackCalculator _calculator = new StackCalculator();
    
    [SetUp]
    public void Setup()
    {
        _calculator = new StackCalculator();
    }

    [Test]
    public void CalculateExpression()
    {
        var expression = "5 97 333 3 / - * 17 / 0 +";
        if (_calculator.CalculateExpression(expression) == null)
        {
            Assert.Fail();
        }
        float result = (float) _calculator.CalculateExpression(expression)!;
        Assert.IsTrue(Math.Abs(result + 4.1176) < 0.0001);
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