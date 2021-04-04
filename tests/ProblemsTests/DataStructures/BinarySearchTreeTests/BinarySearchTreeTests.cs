using System;
using System.Collections.Generic;
using Problems.DataStructures.BinarySearchTree;
using Xunit;

namespace ProblemsTests.DataStructures.BinarySearchTreeTests
{
    public class BinarySearchTreeTests
    {
        [Fact]
        public void ShouldInsertANewNodeWhenTheRootIsNull()
        {
            // Given
            var bst = new BinarySearchTree<int>();
            bst.Insert(10);
            bst.Insert(15);
            bst.Insert(20);
            bst.Insert(6);
            bst.Insert(3);
            bst.Insert(8);

            //          10
            //      6       15
            //    3   8        20

            // When
            var searchEightResult = bst.Search(8);
            var searchThreeResult = bst.Search(3);
            var searchSevenResult = bst.Search(7);

            var bfsResult = bst.BreadthFirstSearchTraversal();

            // Root, left, right
            var preorderResult = bst.PreorderTraversal();
            // left, Root, right
            var inorderResult = bst.InorderTraversal();
            // left, right, Root
            var postorderResult = bst.PostorderTraversal();

            // Then
            Assert.NotNull(searchEightResult);
            Assert.Equal(8, searchEightResult.Data);

            Assert.NotNull(searchThreeResult);
            Assert.Equal(3, searchThreeResult.Data);

            Assert.Null(searchSevenResult);
            Assert.Equal(new List<int>() { 10, 6, 15, 3, 8, 20 }, bfsResult);
            Assert.Equal(new List<int>() { 10, 6, 3, 8, 15, 20 }, preorderResult);
            Assert.Equal(new List<int>() { 3, 6, 8, 10, 15, 20 }, inorderResult);
            Assert.Equal(new List<int>() { 3, 8, 6, 20, 15, 10 }, postorderResult);

            // Height
            var height = bst.GetHeight();
            Assert.Equal(2, height);
        }

        [Fact]
        public void MaximunDepth()
        {
            // Given
            var bst = new BinarySearchTree<int>();
            bst.Insert(10);
            bst.Insert(15);
            bst.Insert(6);
            bst.Insert(9);
            bst.Insert(3);
            bst.Insert(4);
            bst.Insert(5);

            //          10
            //      6       15
            //    3   9        
            //      4
            //        5      

            var result = bst.MaximunDepth();
            Assert.Equal(5, result);

            var expected = new List<List<int>>()
            {
                new List<int>() {10},
                new List<int>() {6, 15},
                new List<int>() {3, 9},
                new List<int>() {4},
                new List<int>() {5},
            };
            var resultLevelOrder = bst.LevelOrder();
            Assert.Equal(expected, resultLevelOrder);
        }

        [Fact]
        public void RightSideViewOfTree()
        {
            // Given
            var bst = new BinarySearchTree<int>();
            bst.Insert(10);
            bst.Insert(15);
            bst.Insert(17);
            bst.Insert(6);
            bst.Insert(9);
            bst.Insert(3);
            bst.Insert(4);
            bst.Insert(5);

            //          10
            //      6       15
            //    3   9        17
            //      4
            //        5      

            var expected = new List<int>()
            {
                10, 15, 17, 4, 5
            };
            var result = bst.RightSideViewOfTree();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void RightSideViewOfTreeDFS()
        {
            // Given
            var bst = new BinarySearchTree<int>();
            bst.Insert(10);
            bst.Insert(15);
            bst.Insert(17);
            bst.Insert(6);
            bst.Insert(9);
            bst.Insert(3);
            bst.Insert(4);
            bst.Insert(5);

            //          10
            //      6       15
            //    3   9        17
            //      4
            //        5      

            var expected = new List<int>()
            {
                10, 15, 17, 4, 5
            };
            var result = bst.RightSideViewOfTreeDFS();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void IsValidBST()
        {
            // Given
            var bst = new BinarySearchTree<int>();
            bst.Insert(10);
            bst.Insert(15);
            bst.Insert(17);
            bst.Insert(6);
            bst.Insert(9);
            bst.Insert(3);
            bst.Insert(4);
            bst.Insert(5);

            //          10
            //      6       15
            //    3   9        17
            //      4
            //        5      

            var result = bst.IsValidBST();
            Assert.Equal(true, result);
        }

        [Fact]
        public void InvalidBST()
        {
            // Given
            var bst = new BinarySearchTree<int>();
            bst.Insert(10);
            bst.Insert(15);
            bst.Insert(17);
            bst.Insert(6);
            bst.Insert(9);
            bst.Insert(3);
            bst.Insert(4);
            bst.Insert(5);
            var fifteenNode = bst.Search(15);
            fifteenNode.Left = new BinaryTreeNode<int>(8);

            //          10
            //      6       15
            //    3   9   8    17
            //      4
            //        5      

            var result = bst.IsValidBST();
            Assert.Equal(false, result);
        }

        [Fact]
        public void IsValidBSTRecursive()
        {
            // Given
            var bst = new BinarySearchTree<int>();
            bst.Insert(10);
            bst.Insert(15);
            bst.Insert(17);
            bst.Insert(6);
            bst.Insert(9);
            bst.Insert(3);
            bst.Insert(4);
            bst.Insert(5);

            //          10
            //      6       15
            //    3   9        17
            //      4
            //        5      

            var result = bst.IsValidBSTRecursive(int.MinValue, int.MaxValue);
            Assert.Equal(true, result);
        }

        [Fact]
        public void InvalidBSTRecursive()
        {
            // Given
            var bst = new BinarySearchTree<int>();
            bst.Insert(10);
            bst.Insert(15);
            bst.Insert(17);
            bst.Insert(6);
            bst.Insert(9);
            bst.Insert(3);
            bst.Insert(4);
            bst.Insert(5);
            var fifteenNode = bst.Search(15);
            fifteenNode.Left = new BinaryTreeNode<int>(8);

            //          10
            //      6       15
            //    3   9   8    17
            //      4
            //        5      

            var result = bst.IsValidBSTRecursive(int.MinValue, int.MaxValue);
            Assert.Equal(false, result);
        }
    }
}