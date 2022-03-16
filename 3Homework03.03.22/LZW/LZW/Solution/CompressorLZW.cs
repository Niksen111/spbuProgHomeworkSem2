using System.Collections;

namespace LZW.Solution;

public class CompressorLZW
{
    public void ZipFile(string path)
    {
        byte[] file = File.ReadAllBytes(path);
        Trie dictionary = new Trie();
        dictionary.LoadAlphabet();
        List<byte> zippedFile;
        int nearestDegreeOf2 = 8;
        for (int i = 0; i < file.Length; ++i)
        {
            BitArray? code = dictionary.AddGradually(file[i]);
            if (code != null)
            {
                int size = dictionary.GetDictionarySize - 1;
                if (size > Math.Pow(2, nearestDegreeOf2))
                {
                    ++nearestDegreeOf2;
                }

                code.Length = nearestDegreeOf2;
                
            }
        }
    }

    public void UnzipFile(string path)
    {
        
    }
}