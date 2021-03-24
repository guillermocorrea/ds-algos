using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Problems.Arrays;
using Xunit;

namespace ProblemsTests.Arrays
{
    public class RottingOrangesTests
    {
        [Fact]
        public void CanSolve()
        {
            // Given
            var grid = new int[][]
            {
                new int[] {2, 1, 1, 0, 0},
                new int[] {1, 1, 1, 0, 0},
                new int[] {0, 1, 1, 1, 1},
                new int[] {0, 1, 0, 0, 1},
            };
            // When
            var result = RottingOrangesSolution.RottingOranges(grid);
            // Then
            Assert.Equal(7, result);
        }

        [Fact]
        public void CannotSolve()
        {
            // Given
            var grid = new int[][]
            {
                new int[] {1, 1, 0, 0, 0},
                new int[] {2, 1, 0, 0, 0},
                new int[] {0, 0, 0, 1, 2},
                new int[] {0, 1, 0, 0, 1},
            };
            // When
            var result = RottingOrangesSolution.RottingOranges(grid);
            // Then
            Assert.Equal(-1, result);
        }
    }
}