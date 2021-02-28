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
        }
    }
}