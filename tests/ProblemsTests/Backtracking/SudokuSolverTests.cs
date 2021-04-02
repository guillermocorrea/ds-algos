using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Problems.Backtracking;
using Xunit;

namespace ProblemsTests.Backtracking
{
    public class SudokuSolverTests
    {
        [Fact]
        public void CanSolve()
        {
            // Given
            var board = new int[][] {
                new int[] {5, 3, -1, -1, 7, -1, -1, -1, -1},
                new int[] {6, -1, -1, 1, 9, 5, -1, -1, -1},
                new int[] {-1, 9, 8, -1, -1, -1, -1, 6, -1},
                new int[] {8, -1, -1, -1, 6, -1, -1, -1, 3},
                new int[] {4, -1, -1, 8, -1, 3, -1, -1, 1},
                new int[] {7, -1, -1, -1, 2, -1, -1, -1, 6},
                new int[] {-1, 6, -1, -1, -1, -1, 2, 8, -1},
                new int[] {-1, -1, -1, 4, 1, 9, -1, -1, 5},
                new int[] {-1, -1, -1, -1, 8, -1, -1, 7, 9},
            };
            // When
            var result = SudokuSolver.Solve(board);
            // Then

        }
    }
}