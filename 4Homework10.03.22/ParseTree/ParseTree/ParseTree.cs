namespace ParseTree;

/// <summary>
/// Parsing an expression.
/// </summary>
public class ParseTree
{
    public ParseTree()
    {
        _root = new Operand(null, 0);
        _currentNode = _root;
        _result = 0;
    }
    
    public ParseTree(string expression)
    {
        _root = new PlusOperator(null);
        _currentNode = _root;
        RebuildTree(expression);
    }

    private INode _root;
    private INode _currentNode;
    private float _result;
    
    /// <summary>
    /// Returns value of the tree
    /// </summary>
    public double GetResult => _result;
    
    /// <summary>
    /// Rebuild the tree according to the new expression.
    /// </summary>
    public void RebuildTree(string expression)
    {
        _root = new PlusOperator(null);
        _currentNode = _root;
        int state = 0;
        var operations = "*/+";
        var startIndex = 0;
        
        for (int i = 0; i < expression.Length; ++i)
        {
            char c = expression[i];
            switch (state)
            {
                case 0:
                {
                    if (c == '-')
                    {
                        state = 1;
                        startIndex = i;
                        break;
                    }
                    if (operations.Contains(c))
                    {
                        state = 0;
                        _currentNode = _currentNode.Add(expression.Substring(i, 1));
                        startIndex = i + 1;
                        break;
                    }
                    if (c >= '0' && c <= '9')
                    {
                        state = 2;
                        startIndex = i;
                    }
                    break;
                }
                case 1:
                {
                    if (c >= '0' && c <= '9')
                    {
                        state = 2;
                        break;
                    }
                    state = 0;
                    _currentNode = _currentNode.Add(expression.Substring(startIndex, i - startIndex + 1));
                    startIndex = i + 1;
                    break;
                }
                case 2:
                {
                    if (c >= '0' && c <= '9')
                    {
                        state = 2;
                        break;
                    }
                    state = 0;
                    _currentNode = _currentNode.Add(expression.Substring(startIndex, i - startIndex + 1));
                    startIndex = i + 1;
                    break;
                }
            }
        }

        _root.Add("0");
        CalculateTree();
    }

    /// <summary>
    /// Prints the expression
    /// </summary>
    public void PrintTree()
    {
        _root.PrintYourself();
    }
    
    private void CalculateTree()
    {
        _result = _root.GetValue();
    }
}