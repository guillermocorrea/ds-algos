using System;
using System.Collections.Generic;

namespace Problems.DataStructures.BinarySearchTree
{
    public class BinarySearchTree<T> where T : IComparable
    {
        public BinaryTreeNode<T> _root { get; set; }

        public void Insert(T newNodeData)
        {
            if (_root == null)
            {
                _root = new BinaryTreeNode<T>(newNodeData);
                return;
            }
            _root.Insert(newNodeData);
        }

        public BinaryTreeNode<T> Search(T data)
        {
            if (_root == null) return null;
            return _root.Search(data);
        }

        public IEnumerable<T> BreadthFirstSearchTraversal()
        {
            if (_root == null) return null;
            var visited = new List<T>();
            var queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(_root);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                visited.Add(current.Data);
                if (current.Left != null) queue.Enqueue(current.Left);
                if (current.Right != null) queue.Enqueue(current.Right);
            }
            return visited;
        }

        #region DFS
        /// <summary>
        /// Root, Left, Right
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> PreorderTraversal()
        {
            if (_root == null) return null;
            var visited = new List<T>();
            PreorderTraversalHelper(_root, visited);
            return visited;
        }

        /// <summary>
        /// Root, Left, Right
        /// </summary>
        /// <returns></returns>
        private void PreorderTraversalHelper(BinaryTreeNode<T> current, List<T> visited)
        {
            visited.Add(current.Data);
            if (current.Left != null) PreorderTraversalHelper(current.Left, visited);
            if (current.Right != null) PreorderTraversalHelper(current.Right, visited);
        }

        /// <summary>
        /// Left, Root, Right
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> InorderTraversal()
        {
            if (_root == null) return null;
            var visited = new List<T>();
            InorderTraversalHelper(_root, visited);
            return visited;
        }

        /// <summary>
        /// Left, Root, Right
        /// </summary>
        /// <returns></returns>
        private void InorderTraversalHelper(BinaryTreeNode<T> current, List<T> visited)
        {
            if (current.Left != null) InorderTraversalHelper(current.Left, visited);
            visited.Add(current.Data);
            if (current.Right != null) InorderTraversalHelper(current.Right, visited);
        }

        /// <summary>
        /// Root, Left, Right
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> PostorderTraversal()
        {
            if (_root == null) return null;
            var visited = new List<T>();
            PostorderTraversalHelper(_root, visited);
            return visited;
        }

        /// <summary>
        /// Left, Right, Root
        /// </summary>
        /// <returns></returns>
        public void PostorderTraversalHelper(BinaryTreeNode<T> current, List<T> visited)
        {
            if (current.Left != null) PostorderTraversalHelper(current.Left, visited);
            if (current.Right != null) PostorderTraversalHelper(current.Right, visited);
            visited.Add(current.Data);
        }
        #endregion

        /// <summary>
        /// T: O(n), S: O(n)
        /// </summary>
        /// <returns></returns>
        public int MaximunDepth()
        {
            if (_root == null) return 0;
            return MaximunDepthRecursive(_root, 0);
        }

        private int MaximunDepthRecursive(BinaryTreeNode<T> current, int count)
        {
            if (current == null) return count;
            count++;
            return Math.Max(MaximunDepthRecursive(current.Left, count), MaximunDepthRecursive(current.Right, count));
        }

        public IEnumerable<List<T>> LevelOrder()
        {
            var result = new List<List<T>>();
            if (_root == null) return result;

            var queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(_root);
            while (queue.Count > 0)
            {
                var level = new List<T>();
                var size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var current = queue.Dequeue();
                    level.Add(current.Data);
                    if (current.Left != null)
                    {
                        queue.Enqueue(current.Left);
                    }
                    if (current.Right != null)
                    {
                        queue.Enqueue(current.Right);
                    }
                }
                result.Add(level);
            }

            return result;
        }

        /// <summary>
        /// BFS Approach
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> RightSideViewOfTree()
        {
            var result = new List<T>();
            if (_root == null) return result;
            var queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(_root);
            while (queue.Count > 0)
            {
                var level = new Stack<T>();
                int levelSize = queue.Count;
                for (int i = 0; i < levelSize; i++)
                {
                    var currentNode = queue.Dequeue();
                    level.Push(currentNode.Data);
                    if (currentNode.Left != null)
                        queue.Enqueue(currentNode.Left);
                    if (currentNode.Right != null)
                        queue.Enqueue(currentNode.Right);
                }
                result.Add(level.Pop());
            }
            return result;
        }

        /// <summary>
        /// DFS T: O(n) S: O(n/2)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> RightSideViewOfTreeDFS()
        {
            var result = new List<T>();
            int level = 1;
            RightSideViewOfTreeRecursive(result, _root, level);
            return result;
        }

        /// <summary>
        /// DFS T: O(n) S: O(n)
        /// </summary>
        public void RightSideViewOfTreeRecursive(List<T> result, BinaryTreeNode<T> node, int level)
        {
            if (node == null) return;
            if (result.Count < level)
            {
                result.Add(node.Data);
            }
            RightSideViewOfTreeRecursive(result, node.Right, level + 1);
            RightSideViewOfTreeRecursive(result, node.Left, level + 1);
        }

        public bool IsValidBSTRecursive(T min, T max)
        {
            if (_root == null) return true;
            if (_root.Left == null && _root.Right == null) return true;
            if (_root.Left?.Data.CompareTo(_root.Data) >= 0) return false;
            if (_root.Right?.Data.CompareTo(_root.Data) <= 0) return false;

            return IsValidBSTRecursiveHelper(_root.Left, min, _root.Data) &&
                IsValidBSTRecursiveHelper(_root.Right, _root.Data, max);
        }

        private bool IsValidBSTRecursiveHelper(BinaryTreeNode<T> node, T leftBoundary, T rightBoundary)
        {
            if (node.Data.CompareTo(leftBoundary) < 0 || node.Data.CompareTo(rightBoundary) > 0) return false;
            if (node.Left != null)
                return IsValidBSTRecursiveHelper(node.Left, leftBoundary, node.Data);
            if (node.Right != null)
                return IsValidBSTRecursiveHelper(node.Right, node.Data, rightBoundary);
            return true;
        }

        /// <summary>
        /// T: O(n), S: O(n)
        /// </summary>
        /// <returns></returns>
        public bool IsValidBST()
        {
            if (_root == null) return true;
            if (_root.Left == null && _root.Right == null) return true;
            if (_root.Left?.Data.CompareTo(_root.Data) >= 0) return false;
            if (_root.Right?.Data.CompareTo(_root.Data) <= 0) return false;

            var queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(_root.Left);
            // Left side traversal
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current == null) break;
                if (current.Left != null)
                {
                    var isValid = current.Left.Data.CompareTo(current.Data) < 0 && current.Left.Data.CompareTo(_root.Data) < 0;
                    if (!isValid) return false;
                    queue.Enqueue(current.Left);
                }
                if (current.Right != null)
                {
                    var isValid = current.Right.Data.CompareTo(current.Data) > 0 && current.Right.Data.CompareTo(_root.Data) < 0;
                    if (!isValid) return false;
                    queue.Enqueue(current.Right);
                }
            }

            // Right side traversal
            queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(_root.Right);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current == null) break;
                if (current.Left != null)
                {
                    var isValid = current.Left.Data.CompareTo(current.Data) < 0 && current.Left.Data.CompareTo(_root.Data) > 0;
                    if (!isValid) return false;
                    queue.Enqueue(current.Left);
                }
                if (current.Right != null)
                {
                    var isValid = current.Right.Data.CompareTo(current.Data) > 0 && current.Right.Data.CompareTo(_root.Data) > 0;
                    if (!isValid) return false;
                    queue.Enqueue(current.Right);
                }
            }

            return true;
        }
    }
}