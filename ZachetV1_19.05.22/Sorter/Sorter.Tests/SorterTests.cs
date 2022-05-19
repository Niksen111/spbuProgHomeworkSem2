using System;
using System.Collections;
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
        Assert.IsTrue(Sorter<int>.AreListSorted(new List<int> {1, 2, 3}, new MyComparer<int>((first, second) => second - first)));
    }
    
    [Test]
    public void CompareWorksWithNonStandartFunction()
    {
        Assert.IsTrue(Sorter<int>.AreListSorted(new List<int> {2, 4, 6, 1, 3, 5}, new MyComparer<int>((first, second) =>
            second % 2 - first % 2)));
    }
}