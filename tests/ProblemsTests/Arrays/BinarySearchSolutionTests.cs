using System;
using Problems.Arrays;
using Xunit;
namespace ProblemsTests.Arrays
{
    public class BinarySearchSolutionTests
    {
        [Theory]
        [InlineData(new int[] { 1, 3, 4, 6, 7, 9, 11, 12, 15, 16, 17, 18, 19 }, 15, 8)]
        [InlineData(new int[] { 1, 3, 4, 6, 7, 9, 11, 12, 15, 16, 17, 18, 19 }, 25, -1)]
        [InlineData(new int[] { 1, 3, 4, 6, 7, 9, 11, 12, 15, 16, 17, 18, 19 }, -5, -1)]
        public void ShouldFindSolution(int[] arr, int item, int expected)
        {
            var result = BinarySearchSolution.IndexOf(arr, item);
            Assert.Equal(expected, result);
        }
    }
}