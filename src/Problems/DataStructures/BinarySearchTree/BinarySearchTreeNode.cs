using System;

namespace Problems.DataStructures.BinarySearchTree
{
    public class BinaryTreeNode<T> where T : IComparable
    {
        public T Data { get; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode(T data)
        {
            Data = data;
        }

        public void Insert(T newNodeData)
        {
            // If the value already exists, ignore it
            if (newNodeData.CompareTo(Data) == 0) return;
            if (newNodeData.CompareTo(Data) > 0)
            {
                if (Right == null) Right = new BinaryTreeNode<T>(newNodeData);
                else Right.Insert(newNodeData);
            }
            else
            {
                if (Left == null) Left = new BinaryTreeNode<T>(newNodeData);
                else Left.Insert(newNodeData);
            }
        }

        public BinaryTreeNode<T> Search(T data)
        {
            if (data.CompareTo(Data) == 0) return this;
            if (data.CompareTo(Data) > 0)
            {
                if (Right == null) return null;
                return Right.Search(data);
            }
            else
            {
                if (Left == null) return null;
                return Left.Search(data);
            }
        }
    }
}