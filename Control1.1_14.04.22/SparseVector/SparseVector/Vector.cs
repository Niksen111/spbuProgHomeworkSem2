namespace SparseVector;

/// <summary>
/// Sparse Vector
/// </summary>
public class Vector : IVector
{
    public Vector(int length)
    {
        _vector = new Dictionary<int, int>();
        _length = length;
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
        _length = length;
    }
    
    
    private readonly int _length;
    public int Length => _length;

    public bool IsNull => _vector.Count == 0;
    
    private Dictionary<int, int> _vector;

    public void SetPosition(int index, int newValue)
    {
        if (index >= _length)
        {
            throw new IndexOutOfRangeException();
        }

        if (_vector.ContainsKey(index))
        {
            if (newValue != 0)
            {
                _vector[index] = newValue;
            }
            else
            {
                _vector.Remove(index);
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
        if (index >= _length)
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
        if (vector.Length != _length)
        {
            throw new IndexOutOfRangeException();
        }

        var vectorWithoutNulls = vector.GetNotNullPositions();
        foreach (var element in vectorWithoutNulls)
        {
            SetPosition(element.Item1, GetPosition(element.Item1) + element.Item2);
        }
    }

    public void Subtract(IVector vector)
    {
        if (vector.Length != _length)
        {
            throw new IndexOutOfRangeException();
        }
        
        var vectorWithoutNulls = vector.GetNotNullPositions();
        foreach (var element in vectorWithoutNulls)
        {
            SetPosition(element.Item1, GetPosition(element.Item1) - element.Item2);
        }
    }

    public int DotProduct(IVector vector)
    {
        if (vector.Length != _length)
        {
            throw new IndexOutOfRangeException();
        }

        int result = 0;
        foreach (var element in _vector)
        {
            result += element.Value * vector.GetPosition(element.Key);
        }
        
        return result;
    }

    public List<(int, int)> GetNotNullPositions()
    {
        List<(int, int)> list = new List<(int, int)>();
        foreach (var element in _vector)
        {
            list.Add((element.Key, element.Value));
        }

        return list;
    }

    public int[] ToArray()
    {
        var result = new int[_length];
        foreach (var element in _vector)
        {
            result[element.Key] = element.Value;
        }
        return result;
    }
}