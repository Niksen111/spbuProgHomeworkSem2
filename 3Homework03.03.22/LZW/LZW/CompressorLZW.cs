using System;
using System.Collections;

namespace LZW;

public class CompressorLZW
{
    public void ZipFile(string path)
    {
        byte[] file = File.ReadAllBytes(path);
        byte[] buffer = new byte[4];
        List<byte> zippedFile = new List<byte>();
        Trie dictionary = new Trie();
        dictionary.LoadAlphabet();
        
        int greaterDegree2 = 8;
        BitArray reminder = new BitArray(0);
        
        for (int i = 0; i < file.Length; ++i)
        {
            BitArray? code = dictionary.AddGradually(file[i]);
            if (code != null)
            {
                int size = dictionary.GetDictionarySize - 1;
                if (size > Math.Pow(2, greaterDegree2))
                {
                    ++greaterDegree2;
                }

                code.Length = greaterDegree2 + reminder.Length;
                for (int j = greaterDegree2; j < code.Length; ++j)
                {
                    code[j] = reminder[j - greaterDegree2];
                }
                reminder.Length = code.Length % 8;
                for (int j = 0; j < code.Length % 8; ++j)
                {
                    reminder[j] = code[0];
                    code.RightShift(1);
                }

                code.Length -= reminder.Length;
                code.CopyTo(buffer, 0);
                for (int j = (code.Length - 1) / 8; j >= 0; --j)
                {
                    zippedFile.Add(buffer[j]);
                }

                dictionary.AddGradually(file[i]);
            }
        }

        BitArray lastCode = dictionary.GetCurrentCode;
        int lastSize = dictionary.GetDictionarySize - 1;
        if (lastSize > Math.Pow(2, greaterDegree2))
        {
            ++greaterDegree2;
        }

        lastCode.Length = greaterDegree2 + reminder.Length;
        for (int j = greaterDegree2; j < lastCode.Length; ++j)
        {
            lastCode[j] = reminder[j - greaterDegree2];
        }

        int length = lastCode.Length;
        lastCode.Length = lastCode.Length + 8 - lastCode.Length % 8;
        lastCode.LeftShift(8 - length % 8);
        lastCode.CopyTo(buffer, 0);
        for (int j = (lastCode.Length - 1) / 8; j >= 0; --j)
        {
            zippedFile.Add(buffer[j]);
        }
        
        File.WriteAllBytes(path, zippedFile.ToArray());
        File.Move(path, path + ".zipped");
    }

    public void UnzipFile(string path)
    {
        string extension = ".zipped";
        for (int i = path.Length - 7; i < path.Length; ++i)
        {
            if (path[i] != extension[i - path.Length + 7])
            {
                throw new NotSupportedException();
            }
        }
        byte[] input = File.ReadAllBytes(path);
        List<byte> output = new List<byte>();
        
        Dictionary<int, byte[]> dictionary = new Dictionary<int, byte[]>();
        for (int i = 0; i < 256; ++i)
        { 
            dictionary.Add(i, new []{(byte) i});
        }

        int newIndex = 0;
        int significantBits = 0;
        int lastIndex = 256;
        int greaterDegree2 = 8;
        List<byte> newCode = new List<byte>();
        foreach (byte symbol in input)
        {
            int currentDegree2 = greaterDegree2;
            newIndex = (newIndex << 8) + symbol;
            significantBits += 8;
            if (significantBits >= greaterDegree2)
            {
                int x = newIndex >> significantBits - currentDegree2;
                output.AddRange(dictionary[newIndex >> significantBits - currentDegree2]);
                
                if (newCode.Count != 0)
                {
                    newCode.Add(dictionary[newIndex >> significantBits - currentDegree2][0]);
                    dictionary.Add(lastIndex - 1, newCode.ToArray());
                }
                ++lastIndex;
                if (lastIndex > (int) Math.Pow(2, greaterDegree2))
                {
                    ++greaterDegree2;
                }
                newCode.Clear();
                newCode.AddRange(dictionary[newIndex >> significantBits - currentDegree2]);
                newIndex %= (int) Math.Pow(2, significantBits - currentDegree2);
                significantBits -= currentDegree2;
            }
        }
        File.WriteAllBytes(path, output.ToArray());
        File.Move(path, path.Substring(0, path.Length - 7));
    }

    private int GreaterDegree2(int number)
    {
        return (int) Math.Ceiling(Math.Log2(number));
    }
}