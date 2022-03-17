using System.Collections;

namespace LZW.Solution;

public class CompressorLZW
{
    public void ZipFile(string path)
    {
        byte[] file = File.ReadAllBytes(path);
        Trie dictionary = new Trie();
        dictionary.LoadAlphabet();
        List<byte> zippedFile = new List<byte>();
        int greaterDegree2 = 8;
        BitArray reminder = new BitArray(0);
        byte[] buffer = new byte[16];
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

        lastCode.Length = lastCode.Length + 8 - lastCode.Length % 8;
        lastCode.CopyTo(buffer, 0);
        for (int j = (lastCode.Length - 1) / 8; j >= 0; --j)
        {
            zippedFile.Add(buffer[j]);
        }
        
        File.WriteAllBytes(path, zippedFile.ToArray());
    }

    public void UnzipFile(string path)
    {
        
    }
}