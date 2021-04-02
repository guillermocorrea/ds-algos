using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Problems.Arrays;
using Xunit;

namespace ProblemsTests.Arrays
{
    public class WallsAndGatesSolutionTests
    {
        [Fact]
        public void CanFindSolution()
        {
            // Given
            var grid = new int[][]
            {
                new int[] {int.MaxValue, -1, 0, int.MaxValue},
                new int[] {int.MaxValue, int.MaxValue, int.MaxValue, -1},
                new int[] {int.MaxValue, -1, int.MaxValue, -1},
                new int[] {0, -1, int.MaxValue, int.MaxValue},
            };
            // When
            var result = WallsAndGatesSolution.WallsAndGates(grid);
            var expected = new int[][]
            {
                new int[] {3, -1, 0, 1},
                new int[] {2, 2, 1, -1},
                new int[] {1, -1, 2, -1},
                new int[] {0, -1, 3, 4},
            };
            // Then
            Assert.Equal(expected, result);
        }
    }
}