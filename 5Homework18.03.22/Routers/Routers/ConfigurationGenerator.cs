using System.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace Routers;

public class ConfigurationGenerator : IConfigurationGenerator
{
    public ConfigurationGenerator(string path)
    {
        _topology = new SortedList<int, (int, int)>();
        GenerateConfig(path);
    }

    private SortedList<int, (int, int)> _topology;
    private int _numberNodes;
    private List<(int, int)>[] _resultTopology;
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
            var numbersInLine = Strings.Split(Strings.Replace(line, @",():", "")).Select(x => int.Parse(x)).ToArray();
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

                if (Math.Max(Math.Max(numbersInLine[i], numbersInLine[i + 1]), numbersInLine[0]) > _numberNodes)
                {
                    _numberNodes = Math.Max(Math.Max(numbersInLine[i], numbersInLine[i + 1]), numbersInLine[0]);
                }
                _topology.Add(-numbersInLine[i + 1], (numbersInLine[0], numbersInLine[i]));
            }
        }
    }
    public void GenerateConfig(string path)
    {
        GetTopology(path);
        var addedNodes = new bool[_numberNodes];
        _resultTopology = new List<(int, int)>[_numberNodes];
        foreach (var edge in _topology)
        {
            if (!addedNodes[edge.Value.Item1] && !addedNodes[edge.Value.Item2])
            {
                _resultTopology[edge.Value.Item1].Add((edge.Value.Item2, edge.Key));
            }
        }
    }

    public void PrintConfigToFile(string path)
    {
        
    }
}