using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Problems.Arrays;
using Xunit;

namespace ProblemsTests.Arrays
{
    public class Traversing2DArraysTests
    {
        [Fact]
        public void CanDFS()
        {
            // Given
            var matrix = new int[][]
            {
                new int[] {1, 2, 3, 4, 5},
                new int[] {6, 7, 8, 9, 10},
                new int[] {11, 12, 13, 14, 15},
                new int[] {16, 17, 18, 19, 20},
            };
            var expected = new List<int>
            {
                1, 2, 3, 4, 5, 10, 15, 20, 19, 14, 9, 8, 13, 18, 17, 12, 7, 6, 11, 16
            };
            // When
            var result = Traversing2DArray.DFS(matrix);
            // Then
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CanBFS()
        {
            // Given
            var matrix = new int[][]
            {
                new int[] {1, 2, 3, 4, 5},
                new int[] {6, 7, 8, 9, 10},
                new int[] {11, 12, 13, 14, 15},
                new int[] {16, 17, 18, 19, 20},
            };
            var expected = new List<int>
            {
                1, 2, 3, 4, 5, 10, 15, 20, 19, 14, 9, 8, 13, 18, 17, 12, 7, 6, 11, 16
            };
            // When
            var result = Traversing2DArray.BFS(matrix);
            // Then
            // TODO: Fix assert
            // Assert.Equal(expected, result);
        }
    }
}