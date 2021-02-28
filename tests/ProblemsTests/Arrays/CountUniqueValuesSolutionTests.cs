using System;
using Problems.Arrays;
using Xunit;

namespace ProblemsTests.Arrays
{
    public class CountUniqueValuesSolutionTests
    {
        [Theory]
        [InlineData(new int[] { }, 0)]
        [InlineData(new int[] { 1 }, 1)]
        [InlineData(new int[] { 1, 1, 1, 1, 2 }, 2)]
        [InlineData(new int[] { 1, 2, 3, 4, 4, 7, 7, 12, 12, 13 }, 7)]
        [InlineData(new int[] { -2, -1, 0, 0, 1 }, 4)]
        public void ShouldFindSolution(int[] arr, int expected)
        {
            // When
            var result = CountUniqueValuesSolution.CountUniqueValues(arr);
            // Then
            Assert.Equal(expected, result);
        }
    }
}