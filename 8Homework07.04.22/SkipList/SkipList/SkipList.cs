﻿using System.Collections;

namespace SkipList;

public class SkipList<T> : IList<T>, IReadOnlyCollection<T> where T : IComparable<T>
{
    private class SkipListElement
    {
        public T? Value { get; set; }
        public SkipListElement? Next;
        public SkipListElement? Down;

        public SkipListElement(T? value)
        {
            Value = value;
        }
    }

    private List<SkipListElement> _listSkipLists;
    private int _count;

    public int Count => _count;

    public bool IsReadOnly { get; }
    
    public SkipList()
    {
        _listSkipLists = new List<SkipListElement> {new(default)};
        _count = 0;
        IsReadOnly = false;
    }

    private List<T?> ToList()
    {
        SkipListElement? currentElement = _listSkipLists[0];
        var list = new List<T?>();
        currentElement = currentElement.Next;
        while (currentElement != null)
        {
            list.Add(currentElement.Value!);
            currentElement = currentElement.Next;
        }

        return list;
    }

    private SkipListElement? AddRecursive(SkipListElement element, T value, out bool levelUp)
    {
        while (element.Next != null && element.Value!.CompareTo(value) < 0)
        {
            element = element.Next;
        }

        bool levelUp1 = true;
        SkipListElement? downElement = null;
        if (element.Down != null)
        {
            downElement = AddRecursive(element.Down, value, out levelUp1);
        }

        levelUp = false;

        if (levelUp1)
        {
            var random = new Random();
            levelUp = random.Next(1) == 1;
            var newElement = new SkipListElement(value);
            newElement.Next = element.Next;
            element.Next = newElement;
            if (element.Down != null)
            {
                newElement.Down = downElement;
            }

            return newElement;
        }

        return null;
    }

    public void Add(T element)
    {
        if (IsReadOnly)
        {
            throw new NotSupportedException();
        }

        ++_count;
        AddRecursive(_listSkipLists[_listSkipLists.Count - 1], element, out bool levelUp);
    }

    public void Clear()
    {
        if (IsReadOnly)
        {
            throw new NotSupportedException();
        }

        _count = 0;
        _listSkipLists = new List<SkipListElement> {new(default)};
    }

    private bool ContainsRecursive(SkipListElement element, T value)
    {
        while (element.Next != null && element.Value!.CompareTo(value) < 0)
        {
            element = element.Next;
        }

        return false;
    }

    public bool Contains(T item)
    {
        return ContainsRecursive(_listSkipLists[_listSkipLists.Count - 1], item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        var currentElement = _listSkipLists[0].Next;
        while (currentElement != null)
        {
            array[arrayIndex] = currentElement.Value!;
            ++arrayIndex;
            currentElement = currentElement.Next;
        }
    }

    public bool Remove(T item)
    {
        if (IsReadOnly)
        {
            throw new NotSupportedException();
        }
        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return ToList().GetEnumerator();
    }

    public int IndexOf(T item)
    {
        var currentElement = _listSkipLists[0].Next;
        if (currentElement == null)
        {
            return -1;
        }

        int i = 0;
        while (currentElement.Value!.CompareTo(item) != 0)
        {
            ++i;
            currentElement = currentElement.Next;
            if (currentElement == null)
            {
                return -1;
            }
        }

        return i;
    }

    public void Insert(int index, T item)
    {
        throw new NotSupportedException();
    }

    public void RemoveAt(int index)
    {
        if (IsReadOnly)
        {
            throw new NotSupportedException();
        }

        var currentElement = _listSkipLists[0];
        if (currentElement.Next == null)
        {
            throw new IndexOutOfRangeException();
        }
        for (int i = 0; i < index; ++i)
        {
            currentElement = currentElement.Next;
            if (currentElement!.Next == null)
            {
                throw new IndexOutOfRangeException();
            }
        }

        currentElement.Next = currentElement.Next.Next;
        --_count;
    }

    public T this[int index]
    {
        get
        {
            var currentElement = _listSkipLists[0].Next;
            if (currentElement == null)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = 0; i < index; ++i)
            {
                currentElement = currentElement.Next;
                if (currentElement == null)
                {
                    throw new IndexOutOfRangeException();
                }
            }

            return currentElement.Value!;
        }
        set => throw new NotSupportedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}