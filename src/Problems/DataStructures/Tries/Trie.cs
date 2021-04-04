using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.DataStructures.Tries
{
    public class TrieNode
    {
        public char Character { get; set; }
        public Dictionary<char, TrieNode> Children { get; set; }
        public bool IsEndOfWord { get; set; }
        public TrieNode(char character)
        {
            Character = character;
            Children = new Dictionary<char, TrieNode>();
        }
    }

    public class Trie
    {
        private readonly TrieNode _root;

        public Trie()
        {
            _root = new TrieNode(default(char));
        }

        public void Insert(string word)
        {
            var charArr = word.ToCharArray();
            var tempRoot = _root;
            for (var i = 0; i < charArr.Length; i++)
            {
                if (tempRoot.Children.ContainsKey(charArr[i]))
                {
                    tempRoot = tempRoot.Children[charArr[i]];
                }
                else
                {
                    var newNode = new TrieNode(charArr[i]);
                    tempRoot.Children[charArr[i]] = newNode;
                    tempRoot = newNode;
                }
                if (i == charArr.Length - 1)
                {
                    tempRoot.IsEndOfWord = true;
                }
            }
        }

        public bool Search(string word)
        {
            var tempRoot = _root;
            foreach (var character in word)
            {
                if (!tempRoot.Children.ContainsKey(character))
                {
                    return false;
                }
                tempRoot = tempRoot.Children[character];
            }
            return tempRoot.IsEndOfWord;
        }

        public bool StartsWith(string prefix)
        {
            var tempRoot = _root;
            foreach (var character in prefix)
            {
                if (!tempRoot.Children.ContainsKey(character))
                {
                    return false;
                }
                tempRoot = tempRoot.Children[character];
            }
            return tempRoot.Children.Count > 0;
        }
    }
}