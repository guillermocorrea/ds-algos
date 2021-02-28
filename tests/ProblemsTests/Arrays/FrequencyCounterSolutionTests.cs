using Xunit;
using System;
using Problems.Arrays;

namespace ProblemsTests.Arrays
{
    public class FrequencyCounterSolutionTests
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 4, 1, 9 }, true)]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 9 }, false)]
        [InlineData(new int[] { 1, 2, 1 }, new int[] { 4, 4, 1 }, false)]
        public void ShouldFindSolution(int[] arr1, int[] arr2, bool expected)
        {
            // When
            var result = FrequencyCounterSolution.IsSquared(arr1, arr2);
            // Then
            Assert.Equal(expected, result);
        }
    }
}