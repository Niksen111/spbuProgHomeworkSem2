using System.Collections.Generic;
using NUnit.Framework;

namespace MapFilterFold.Tests;

public class Tests
{
    [Test]
    public void MapWorksWithIntAndString()
    {
        Assert.AreEqual(MyClass.Map(new List<int> {1, 2, 3}, 
            x => x * 2), new []{2, 4, 6});
        
        Assert.AreEqual(MyClass.Map(new List<string> {"a", "b", "c"}, 
            x => x + "."), new []{"a.", "b.", "c."});
    }

    [Test]
    public void FilterWorks()
    {
        Assert.AreEqual(MyClass.Filter(new List<int> {2, 5, 3, 12},
            x => x > 4), new[] {5, 12});

        Assert.AreEqual(MyClass.Filter(new List<string> {"MaxA", "MinA", "MaxB"},
            x => x.Contains("Max")), new[] {"MaxA", "MaxB"});
    }

    [Test]
    public void FoldWorks()
    {
        Assert.AreEqual(MyClass.Fold(new List<int> {1, 2, 3}, 1,
            (acc, elem) => acc * elem), 6);
        
        Assert.AreEqual(MyClass.Fold(new List<string> {"a", "b", "c"}, "", 
            (first, second) => first + second), "abc");
        
        Assert.AreEqual(MyClass.Fold(new List<int> {1, 2, 3}, "0",
            (acc, elem) => acc + elem.ToString()), "0123");
        
        Assert.AreEqual(MyClass.Fold(new List<int>() , 666, 
            (i, i1) => i + i1), 666);
    }
}