using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace StackCalculator.Tests;

[TestFixture]
public class StackTests
{
    private static IEnumerable<TestCaseData> Stacks
        => new TestCaseData[]
        {
            new TestCaseData(new ArrayStack()),
            new TestCaseData(new ListStack())
        };
    
    [TestCaseSource(nameof(Stacks))]
    public void AddNumbers_1_2_3_Get_3_2_1(IStack stack)
    {
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        float? first = stack.Pop();
        float? second = stack.Pop();
        float? third = stack.Pop();
        Assert.NotNull(first);
        Assert.NotNull(second);
        Assert.NotNull(third);
        Assert.AreEqual(first, 3);
        Assert.AreEqual(second, 2);
        Assert.AreEqual(third, 1);
    }

    [TestCaseSource(nameof(Stacks))]
    public void GetNullFromEmptyStackByPop(IStack stack)
    {
        Assert.IsNull(stack.Pop());
    }

    [TestCaseSource(nameof(Stacks))]
    public void EmptyStackIsEmptyAndNotEmptyStackIsNotEmpty(IStack stack)
    {
        Assert.IsTrue(stack.IsEmpty);
        stack.Push(1);
        Assert.IsFalse(stack.IsEmpty);
        stack.Pop();
        Assert.IsTrue(stack.IsEmpty);
        stack.Pop();
        Assert.IsTrue(stack.IsEmpty);
    }

}