using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Sorter.Tests;

public class Tests
{
    public class MyComparer<T> : IComparer<T>
    {
        public MyComparer(Func<T?, T?, int> comparer)
        {
            _myComparer = comparer;
        }
        private readonly Func<T?, T?, int> _myComparer;
        int IComparer<T>.Compare(T? x, T? y)
        {
            return _myComparer(x, y);
        }
    }

    [Test]
    public void AreArraySortedWorked()
    {
        Assert.IsTrue(Sorter<int>.AreListSorted(new List<int> {1, 2, 2, 3}, new MyComparer<int>((first, second) => second - first)));
        Assert.IsFalse(Sorter<int>.AreListSorted(new List<int> {-100, -101, 2, 3}, new MyComparer<int>((first, second) => second - first)));

    }
    
    [Test]
    public void CompareWorksWithNonStandartFunction()
    {
        Assert.IsTrue(Sorter<int>.AreListSorted(new List<int> {2, 4, 6, 1, 3, 5}, new MyComparer<int>((first, second) =>
            second % 2 - first % 2)));
        Assert.IsFalse(Sorter<int>.AreListSorted(new List<int> {6, 4, 1, 2, 3, 5}, new MyComparer<int>((first, second) =>
            second % 2 - first % 2)));
    }

    [Test]
    public void SorterSortsSimpleTest()
    {
        Assert.IsTrue(Sorter<int>.AreListSorted(Sorter<int>.SortByBubble(
            new List<int>{9, 4, 6, 2, 5, 2}, 
            new MyComparer<int>((first, second) => second - first)),
            new MyComparer<int>((first, second) => second - first)));
    }
    
    [Test]
    public void SortedStrings()
    {
        Assert.IsTrue(Sorter<string>.AreListSorted(Sorter<string>.SortByBubble(
                new List<string>{"zx", "acb", "aaaa"}, 
                new MyComparer<string>((first, second) => first.Length - second.Length)),
            new MyComparer<string>((first, second) => first.Length - second.Length)));
    }
}