using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.InterfaceDesign
{
    public interface IMonarchy
    {
        void Birth(string child, string parent);
        void Death(string name);
        List<string> GetOrderOfSuccession();
    }

    public class Monarchy : IMonarchy
    {
        private readonly string _monarch;
        private readonly Tree _tree;

        public Monarchy(string monarch)
        {
            _monarch = monarch ?? throw new ArgumentNullException(nameof(monarch));
            _tree = new Tree(monarch);
        }

        public void Birth(string child, string parent)
        {
            var findResult = _tree.Find(parent);
            if (findResult == null) return;
            findResult.Value.Node.Children.Add(new TreeNode(child));
        }

        public void Death(string name)
        {
            var findResult = _tree.Find(name);
            if (findResult == null) return;
            var (node, parent) = findResult.Value;
            if (parent == null)
            {
                var children = node.Children;
                if (children.Count > 0)
                {
                    var newRoot = children[0];
                    children.RemoveAt(0);
                    newRoot.Children.AddRange(children);
                    _tree.Root = newRoot;
                }
            }
            else
            {
                parent.Children.InsertRange(0, node.Children);
                parent.Children.Remove(node);
            }
        }

        public List<string> GetOrderOfSuccession()
        {
            List<string> result = new List<string>();
            GetOrderOfSuccessionRecursive(_tree.Root, result);
            return result;
        }

        private void GetOrderOfSuccessionRecursive(TreeNode current, List<string> result)
        {
            if (current == null) return;
            result.Add(current.Data);
            foreach (var child in current.Children)
            {
                GetOrderOfSuccessionRecursive(child, result);
            }
        }
    }

    class Tree
    {
        public TreeNode Root { get; set; }
        public Tree(string monarch)
        {
            Root = new TreeNode(monarch);
        }

        public (TreeNode Node, TreeNode Parent)? Find(string data)
        {
            return FindRecursive(Root, null, data);
        }
        private (TreeNode Node, TreeNode Parent)? FindRecursive(TreeNode current, TreeNode parent, string data)
        {
            if (current == null) return null;
            if (current.Data == data) return (current, parent);
            foreach (var child in current.Children)
            {
                var childResult = FindRecursive(child, current, data);
                if (childResult != null)
                    return childResult;
            }
            return null;
        }
    }

    class TreeNode
    {
        public string Data { get; set; }
        public List<TreeNode> Children { get; set; }
        public TreeNode(string data)
        {
            Data = data;
            Children = new List<TreeNode>();
        }
    }
}