using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.DataStructures.Trie
{
    public class Node
    {
        public char? Value { get; set; }
        public Dictionary<char, Node> Children { get; set; }
        public Node Parent { get; set; }
        public bool End { get; set; }

        public Node(char? value)
        {
            Value = value;
            Children = new Dictionary<char, Node>();
            Parent = null;
            End = false;
        }

        public bool IsLeaf()
        {
            return Children.Count == 0;
        }

        /// <summary>
        /// iterates through the parents to get the word.
        /// time complexity: O(k), k = word length
        /// </summary>
        /// <returns></returns>
        public string GetWord()
        {
            var node = this;
            var stack = new Stack<char>();
            while (node != null)
            {
                if (node.Value.HasValue)
                    stack.Push((char)node.Value);
                node = node.Parent;
            }
            return new string(stack.ToArray());
        }
    }
}
