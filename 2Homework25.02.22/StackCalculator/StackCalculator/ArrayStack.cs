using StackCalculator;

namespace StackCalculator;
public class ArrayStack : IStack
{
    public ArrayStack()
    {
        _myArray = new float[10];
        _length = 10;
    }

    private float[] _myArray;
    private int _length;
    private int _filled;

    public void Push(float number)
    {
        if (_filled == _length)
        {
            Array.Resize(ref _myArray, _length * 2);
            _length *= 2;
        }

        _myArray[_filled] = number;
        ++_filled;
    }

    public float? Pop()
    {
        if (_filled == 0)
        {
            return null;
        }

        --_filled;
        return _myArray[_filled];
    }
    
    public float? Top => _filled == 0 ? null : _myArray[_filled - 1];
    
    public bool IsEmpty => _filled == 0; 
}