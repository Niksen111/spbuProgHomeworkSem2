using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MapFilterFold.Tests;

public class Tests
{

    [Test]
    public void MapWorksWithIntAndString()
    {
        Assert.AreEqual(MyClass<int>.Map(new List<int> {1, 2, 3}, 
            x => x * 2), new []{2, 4, 6});
        
        Assert.AreEqual(MyClass<string>.Map(new List<string> {"a", "b", "c"}, 
            x => x + "."), new []{"a.", "b.", "c."});
    }

    [Test]
    public void FilterWorks()
    {
        Assert.AreEqual(MyClass<int>.Filter(new List<int>() {2, 5, 3, 12},
            x => x > 4), new[] {5, 12});

        Assert.AreEqual(MyClass<string>.Filter(new List<string>() {"MaxA", "MinA", "MaxB"},
            x => x.Contains("Max")), new[] {"MaxA", "MaxB"});
    }

    [Test]
    public void FoldWorks()
    {
        Assert.AreEqual(MyClass<int>.Fold(new List<int>() {1, 2, 3}, 1,
            (acc, elem) => acc * elem), 6);
        
        Assert.AreEqual(MyClass<string>.Fold(new List<string>() {"a", "b", "c"}, "", 
            (first, second) => first + second), "abc");
    }
}