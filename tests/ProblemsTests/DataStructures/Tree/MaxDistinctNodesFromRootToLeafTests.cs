using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Problems.DataStructures.Tree;
using Xunit;

namespace ProblemsTests.DataStructures.Tree
{
    public class MaxDistinctNodesFromRootToLeafTests
    {
        [Fact]
        public void CanSolve()
        {
            // Given
            // Input :   1
            //         /    \
            //     2      3
            //     / \    / \
            //     4   5  6   3
            //             \   \
            //             8   9 
            var root = new Node(1);
            root.Left = new Node(3);
            root.Right = new Node(3);
            root.Left.Left = new Node(4);
            root.Left.Right = new Node(5);
            root.Right.Left = new Node(6);
            root.Right.Left.Right = new Node(8);
            root.Right.Right = new Node(3);
            root.Right.Right.Right = new Node(9);
            // When
            var result = MaxDistinctNodesFromRootToLeaf.Solve(root);
            // Then
            Assert.Equal(4, result);
        }
    }
}