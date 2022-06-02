using System;
using System.IO;
using NUnit.Framework;

namespace Routers.Tests;

public class Tests
{
    private bool FileCompare(string path1, string path2)
    {
        const int BYTES_TO_READ = sizeof(Int64);
        var first = new FileInfo(path1);
        var second = new FileInfo(path2);
        if (first.Length != second.Length)
        {
            return false;
        }

        if (string.Equals(first.FullName, second.FullName, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        int iterations = (int)Math.Ceiling((double)first.Length / BYTES_TO_READ);

        using (FileStream fs1 = first.OpenRead())
        using (FileStream fs2 = second.OpenRead())
        {
            var one = new byte[BYTES_TO_READ];
            var two = new byte[BYTES_TO_READ];

            for (int i = 0; i < iterations; i++)
            {
                fs1.Read(one, 0, BYTES_TO_READ);
                fs2.Read(two, 0, BYTES_TO_READ);

                if (BitConverter.ToInt64(one, 0) != BitConverter.ToInt64(two, 0))
                {
                    return false;
                }
            }
        }

        return true;
    }
    
    [Test]
    public void ConfigurationFromTheTask()
    {
        var generator = new ConfigurationGenerator("../../../InputFile1.txt");
        generator.PrintConfigToFile("../../../OutputFile1.txt");
        Assert.IsTrue(FileCompare("../../../OutputFile1.txt", "../../../AnswerFile1.txt"));
    }

    [Test]
    public void AcyclicGraph()
    {
        var generator = new ConfigurationGenerator("../../../InputFile2.txt");
        generator.PrintConfigToFile("../../../OutputFile2.txt");
        Assert.IsTrue(FileCompare("../../../OutputFile2.txt", "../../../AnswerFile2.txt"));
    }

    [Test]
    public void BigGraph()
    {
        var generator = new ConfigurationGenerator("../../../InputFile3.txt");
        generator.PrintConfigToFile("../../../OutputFile3.txt");
        Assert.IsTrue(FileCompare("../../../OutputFile3.txt", "../../../AnswerFile3.txt"));
    }
}