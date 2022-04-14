namespace SparseVector;

public class Vector : IVector
{
    public Vector(int length)
    {
        _vector = new Dictionary<int, int>();
        _myLength = length;
    }

    public Vector(int[] array, int length)
    {
        if (length < array.Length)
        {
            throw new IndexOutOfRangeException();
        }
        _vector = new Dictionary<int, int>();
        for (int i = 0; i < array.Length; ++i)
        {
            if (array[i] != 0)
            {
                _vector.Add(i, array[i]);
            }
        }
        _myLength = length;
    }
    
    private Dictionary<int, int> _vector;

    public void SetPosition(int index, int newValue)
    {
        if (index >= _myLength)
        {
            throw new IndexOutOfRangeException();
        }

        if (_vector.ContainsKey(index))
        {
            if (newValue != 0)
            {
                _vector[index] = newValue;
            }
        }
        else
        {
            if (newValue != 0)
            {
                _vector.Add(index, newValue);
            }
        }
    }

    public int GetPosition(int index)
    {
        if (index >= _myLength)
        {
            throw new IndexOutOfRangeException();
        }

        if (_vector.TryGetValue(index, out int result))
        {
            return result;
        }

        return 0;
    }

    public void Add(IVector vector)
    {
        if (vector.Length != _myLength)
        {
            throw new IndexOutOfRangeException();
        }

        for (int i = 0; i < _myLength; ++i)
        {
            SetPosition(i, GetPosition(i) + vector.GetPosition(i));
        }
    }

    public void Subtract(IVector vector)
    {
        if (vector.Length != _myLength)
        {
            throw new IndexOutOfRangeException();
        }
        for (int i = 0; i < _myLength; ++i)
        {
            SetPosition(i, GetPosition(i) - vector.GetPosition(i));
        }
    }

    private readonly int _myLength;
    public int Length => _myLength;

    public bool IsNull => _vector.Count == 0;

    public int DotProduct(IVector vector)
    {
        if (vector.Length != _myLength)
        {
            throw new IndexOutOfRangeException();
        }

        int result = 0;
        for (int i = 0; i < _myLength; ++i)
        {
            result += GetPosition(i) * vector.GetPosition(i);
        }
        
        return result;
    }

    public int[] ToArray()
    {
        var result = new int[_myLength];
        var currentPair = _vector.GetEnumerator();
        result[currentPair.Current.Key] = currentPair.Current.Value;
        while (currentPair.MoveNext())
        {
            result[currentPair.Current.Key] = currentPair.Current.Value;
        }
        currentPair.Dispose();
        return result;
    }
}