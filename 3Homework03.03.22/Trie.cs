using System.Collections;
namespace LZW.Solution;
#nullable disable

public class Trie
    {
        private class Node
        {
            public Node()
            {
                Next = new Dictionary<byte, Node>();
            }
            
            public short NumberOfWords;
            public BitArray Code;
            public bool IsTerminal;
            public Dictionary<byte, Node> Next { get; }
        }
        public Trie()
        {
            Head = new Node();
            _currentPosition = Head;
            _currentCode = new BitArray(9);
        }

        private Node Head;
        private BitArray _currentCode;
        private Node _currentPosition;
        private int _dictionarySize;

        public int Size => Head.NumberOfWords;
        public int GetDictionarySize => _dictionarySize;
        public BitArray GetCurrentCode => _currentPosition.Code;
        private void Increase_currentCode()
        {
            if (!_currentCode[0])
            {
                _currentCode.Set(0, true);
                return;
            }

            _currentCode.Set(0, false);
            bool transport = true;
            int position = 1;
            while (transport && position < _currentCode.Length)
            {
                _currentCode.Set(position, !_currentCode[position]);
                ++position;
                if (_currentCode[position - 1])
                {
                    transport = false;
                }
            }

            if (transport)
            {
                _currentCode.Length += 1;
                _currentCode.Set(_currentCode.Length - 1, true);
            }
        }
        public void LoadAlphabet()
        {
            _currentCode = new BitArray(8);
            for (int i = 0; i < 256; ++i)
            {
                byte symbol = (byte) i;
                Add(new []{symbol});
            }
        }

        public BitArray AddGradually(byte b)
        {
            if (_currentPosition.Next.ContainsKey(b))
            {
                _currentPosition = _currentPosition.Next[b];
                return null;
            }

            ++_dictionarySize;
            Node newNode = new Node();
            _currentPosition.Next.Add(b, newNode);
            _currentPosition.Next[b].Code = new BitArray(_currentCode);
            newNode.IsTerminal = true;
            Increase_currentCode();
            Node position = _currentPosition;
            _currentPosition = Head;
                
            return position.Code;
        }

        public bool Add(byte[] element)
        {
            Node position = Head;
            foreach (byte b in element)
            {
                if (!position.Next.ContainsKey(b))
                {
                    Node newNode = new Node();
                    position.Next.Add(b, newNode);
                }

                position = position.Next[b];
            }

            bool result = !position.IsTerminal;
            if (result)
            {
                ++_dictionarySize;
                position.Code = new BitArray(_currentCode);
                Increase_currentCode();
                position = Head;
                foreach (byte b in element)
                {
                    ++position.NumberOfWords;
                    position = position.Next[b];
                }
                ++position.NumberOfWords;
            }
            position.IsTerminal = true;
            return result;
        }

        public bool Contains(byte[] element)
        {
            Node position = Head;
            foreach (byte b in element)
            {
                if (!position.Next.ContainsKey(b))
                {
                    return false;
                }

                position = position.Next[b];
            }
            return position.IsTerminal;
        }

        public int HowManyStartsWithPrefix(byte[] prefix)
        {
            Node position = Head;
            foreach (byte b in prefix)
            {
                if (!position.Next.ContainsKey(b))
                {
                    return 0;
                }

                position = position.Next[b];
            }
            return position.NumberOfWords;
        }
    }