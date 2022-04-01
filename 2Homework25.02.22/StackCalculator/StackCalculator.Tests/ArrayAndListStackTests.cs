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
        bool result = first != null && second != null
            && third != null && Math.Abs((float) (first - 3)) < 0.0001
            && Math.Abs((float) (second - 2)) < 0.0001
            && Math.Abs((float) (third - 1)) < 0.0001;
        Assert.IsTrue(result);
    }

    [TestCaseSource(nameof(Stacks))]
    public void GetNullFromEmptyStackByPop(IStack stack)
    {
        Assert.IsNull(stack.Pop());
    }

    [TestCaseSource(nameof(Stacks))]
    public void EmptyStackIsEmptyAndNotEmptyStackIsNotEmpty(IStack stack)
    {
        bool result = stack.IsEmpty;
        stack.Push(1);
        result = result && !stack.IsEmpty;
        stack.Pop();
        result = result && stack.IsEmpty;
        stack.Pop();
        result = result && stack.IsEmpty;
        Assert.IsTrue(result);
    }

}