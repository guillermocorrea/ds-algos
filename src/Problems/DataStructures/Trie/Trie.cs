using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.DataStructures.Trie
{
    public class Trie
    {
        private readonly Node _root;

        public Trie()
        {
            _root = new Node(null);
        }

        /// <summary>
        /// inserts a word into the trie.
        /// time complexity: O(k), k = word length
        /// </summary>
        /// <param name="word"></param>
        public void Insert(string word)
        {
            var node = _root;
            for (int i = 0; i < word.Length; i++)
            {
                if (!node.Children.ContainsKey(word[i]))
                {
                    node.Children[word[i]] = new Node(word[i]);
                    node.Children[word[i]].Parent = node;
                }

                node = node.Children[word[i]];

                if (i == word.Length - 1)
                {
                    node.End = true;
                }
            }
        }

        /// <summary>
        /// check if it contains a whole word.
        /// time complexity: O(k), k = word length
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Contains(string word)
        {
            var node = _root;
            for (int i = 0; i < word.Length; i++)
            {
                if (node.Children.ContainsKey(word[i]))
                {
                    node = node.Children[word[i]];
                }
                else
                {
                    return false;
                }
            }

            return node.End;
        }

        /// <summary>
        /// Returns every word with given prefix
        /// time complexity: O(p + n), p = prefix length, n = number of child paths
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public string[] Find(string prefix)
        {
            var node = _root;
            var stack = new Stack<string>();

            for (int i = 0; i < prefix.Length; i++)
            {
                if (node.Children.ContainsKey(prefix[i]))
                {
                    node = node.Children[prefix[i]];
                }
                else
                {
                    return stack.ToArray();
                }
            }

            // recursive
            FindAllWords(node, stack);

            return stack.ToArray();
        }

        private void FindAllWords(Node node, Stack<string> stack)
        {
            // base case, if node is at end, push to output
            if (node.End) stack.Push(node.GetWord());

            foreach(var child in node.Children.Values)
            {
                FindAllWords(child, stack);
            }
        }
    }
}
