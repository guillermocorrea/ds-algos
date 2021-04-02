using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Problems.DP;
using Xunit;

namespace ProblemsTests.DP
{
    public class ClimbingStairsTests
    {
        [Fact]
        public void CanSolve()
        {
            // Given
            var cost = new int[] { 20, 15, 30, 5 };

            // When
            var result = ClimbingStairs.Solve(cost);

            // Then
            Assert.Equal(20, result);
        }
    }
}