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
    }
}