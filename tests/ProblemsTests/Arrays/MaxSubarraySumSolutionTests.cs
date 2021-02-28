using System;
using Problems.Arrays;
using Xunit;

namespace ProblemsTests.Arrays
{
    public class MaxSubarraySumSolutionTests
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 5, 2, 8, 1, 5 }, 2, 10)]
        [InlineData(new int[] { 1, 2, 5, 2, 8, 1, 5 }, 4, 17)]
        [InlineData(new int[] { 4, 2, 1, 6 }, 1, 6)]
        [InlineData(new int[] { 4, 2, 1, 6, 2 }, 4, 13)]
        [InlineData(new int[] { }, 4, null)]
        public void ShouldFindSolution(int[] arr, int n, int? expected)
        {
            // When
            var result = MaxSubarraySumSolution.MaxSubarraySum(arr, n);
            // Then
            Assert.Equal(expected, result);
        }
    }
}