using System;
using Problems.Arrays;
using Xunit;

namespace ProblemsTests.Arrays
{
    public class TrappingRainWaterTests
    {
        [Theory]
        [InlineData(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6)]
        public void ShouldFindSolution(int[] height, int expectedResult)
        {
            var result = TrappingRainWaterSolution.Trap(height);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6)]
        public void ShouldFindSolutionOptimized(int[] height, int expectedResult)
        {
            var result = TrappingRainWaterSolution.TrapOptimized(height);
            Assert.Equal(expectedResult, result);
        }
    }
}