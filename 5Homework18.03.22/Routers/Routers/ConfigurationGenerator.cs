using Microsoft.VisualBasic;

namespace Routers;

/// <summary>
/// This topology creates an optimal network configuration without cycles
/// </summary>
public class ConfigurationGenerator
{
    public ConfigurationGenerator(string path)
    {
        _topology = new List<(int, int, int)>();
        _resultTopology = new SortedList<int, int>[1];
        GenerateConfig(path);
    }

    private List<(int, int, int)> _topology;
    private int _nodesNumber;
    private SortedList<int, int>[] _resultTopology;
    private int _sumOfCapacities;
    
    /// <summary>
    /// The sum of the network bandwidth
    /// </summary>
    public int SumOfCapacities => _sumOfCapacities;

    private void GetTopology(string path)
    {
        _topology.Clear();
        var file = File.ReadAllLines(path);
        foreach (var line in file)
        {
            if (line.Length == 0)
            {
                continue;
            }
            var numbersInLine = Strings.Split(line.Replace( ": ", " ").Replace( " (", " ").Replace( ")", "").Replace(",", "")).Select(x => int.Parse(x)).ToArray();
            if (numbersInLine.Length % 2 == 0)
            {
                throw new InputDataException();
            }

            for (int i = 1; i < numbersInLine.Length; i += 2)
            {
                if (numbersInLine[i + 1] < 0)
                {
                    throw new InputDataException();
                }

                if (Math.Max(numbersInLine[i], numbersInLine[0]) > _nodesNumber)
                {
                    _nodesNumber = Math.Max(numbersInLine[i], numbersInLine[0]);
                }
                _topology.Add((-numbersInLine[i + 1], numbersInLine[0] - 1, numbersInLine[i] - 1));
            }
        }
    }
    
    /// <summary>
    /// Generates a configuration from an input file
    /// </summary>
    /// <param name="path">path to input file</param>
    public void GenerateConfig(string path)
    {
        GetTopology(path);
        _topology.Sort(delegate((int, int ,int) x, (int, int, int) y)
        {
            if (x.Item1 == y.Item1)
            {
                return 0;
            }
            if (x.Item1 < y.Item1)
            {
                return -1;
            }
            return 1;
        });
        var connectivityComponents = new int[_nodesNumber];
        _resultTopology = new SortedList<int, int>[_nodesNumber];
        for (int i = 0; i < _nodesNumber; ++i)
        {
            connectivityComponents[i] = i + 1;
            _resultTopology[i] = new SortedList<int, int>();
        }
        foreach (var edge in _topology)
        {
            if (connectivityComponents[edge.Item2] != connectivityComponents[edge.Item3])
            {
                _resultTopology[edge.Item2].Add(edge.Item3, -edge.Item1);
                _sumOfCapacities += -edge.Item1;
                int node2Value = connectivityComponents[edge.Item3];
                for (int i = 0; i < _nodesNumber; ++i)
                {
                    if (connectivityComponents[i] == node2Value)
                    {
                        connectivityComponents[i] = connectivityComponents[edge.Item2];
                    }
                }
            }
        }
    }

    /// <summary>
    /// Prints the configuration in the output file
    /// </summary>
    /// <param name="path">path to output file</param>
    public void PrintConfigToFile(string path)
    {
        var file = new StreamWriter(path);
        for (int i = 0; i < _nodesNumber; ++i)
        {
            if (_resultTopology[i].Count > 0)
            {
                file.Write($"{i + 1}: ");

                int j = 0;
                foreach (var element in _resultTopology[i])
                {
                    if (j != 0)
                    {
                        file.Write(", ");
                    }
                    file.Write($"{element.Key + 1} ({element.Value})");
                    ++j;
                }
                file.WriteLine();

            }
        }
        file.Close();
    }
}