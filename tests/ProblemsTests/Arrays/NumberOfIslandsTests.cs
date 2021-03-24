using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Problems.Arrays;
using Xunit;

namespace ProblemsTests.Arrays
{
    public class NumberOfIslandsTests
    {
        [Fact]
        public void CanSolve()
        {
            // Given
            var grid = new char[][] {
                new char[] {'1', '1', '1', '1', '0'},
                new char[] {'1', '1', '0', '1', '0'},
                new char[] {'1', '1', '0', '0', '1'},
                new char[] {'0', '0', '0', '1', '1'},
            };
            // When
            var result = NumberOfIslands.NumIslands(grid);
            // Then
            Assert.Equal(2, result);
        }

        [Fact]
        public void CanSolveTwo()
        {
            // Given
            var grid = new char[][] {
                new char[] {'0', '1', '0', '1', '0'},
                new char[] {'1', '0', '1', '0', '1'},
                new char[] {'0', '1', '1', '1', '0'},
                new char[] {'1', '0', '1', '0', '1'},
            };
            // When
            var result = NumberOfIslands.NumIslands(grid);
            // Then
            Assert.Equal(7, result);
        }
    }
}