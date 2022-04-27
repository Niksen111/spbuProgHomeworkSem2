namespace SparseVector;

/// <summary>
/// Sparse vector interface
/// </summary>
public interface IVector
{
    /// <summary>
    /// index length of the vector
    /// </summary>
    public int Length { get; }
    
    /// <summary>
    /// returns true if the vector is null
    /// </summary>
    public bool IsNull { get; }
    
    /// <summary>
    /// changes the vector value by the index
    /// </summary>
    /// <param name="index">the index</param>
    /// <param name="newValue">new vector value</param>
    public void SetPosition(int index, int newValue);
    
    /// <param name="index">the index</param>
    /// <returns>value of the position by the index</returns>
    public int GetPosition(int index);

    /// <summary>
    /// Increases the value of the vector by the given vector
    /// </summary>
    /// <param name="vector">vector to add</param>
    public void Add(IVector vector);

    /// <summary>
    /// Decreases the value of the vector by the given vector
    /// </summary>
    /// <param name="vector">a vector that is subtracted from</param>
    public void Subtract(IVector vector);

    /// <summary>
    /// takes two equal-length sequences of numbers and returns a number
    /// dot product
    /// </summary>
    /// <param name="vector">second multiply vector</param>
    /// <returns>dot product</returns>
    public int DotProduct(IVector vector);
    
    /// <returns>List of pairs - (index, non-zero element)</returns>
    public List<(int, int)> GetNotNullPositions();

    /// <returns>vector converted to an int array</returns>
    public int[] ToArray();
}