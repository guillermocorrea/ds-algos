using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.DataStructures.Tree
{
    public class MaxDistinctNodesFromRootToLeaf
    {
        public static int Solve(Node root)
        {
            if (root == null) return 0;

            return SolveRecursive(root, new HashSet<int>());
        }

        private static int SolveRecursive(Node root, HashSet<int> hashSet)
        {
            if (root == null) return 0;
            int count = 0;
            if (!hashSet.Contains(root.Data))
            {
                hashSet.Add(root.Data);
                count++;
            }
            return count + Math.Max(SolveRecursive(root.Left, new HashSet<int>(hashSet)), SolveRecursive(root.Right, new HashSet<int>(hashSet)));
        }
    }

    public class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node(int data)
        {
            Data = data;
        }
    }
}