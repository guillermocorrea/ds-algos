using Problems.Arrays;
using Xunit;
using System;

namespace ProblemsTests.Arrays
{
    public class TwoNumsAddToTargetTests
    {
        [Theory]
        [InlineData(new int[] { }, 11)]
        [InlineData(new int[] { 1 }, 11)]
        [InlineData(new int[] { 11 }, 11)]
        [InlineData(new int[] { 1, 3, 7, 5, 2 }, 11)]
        public void ShouldReturnNullWhenThereIsNoSolutionBruteForce(int[] nums, int target)
        {
            var watch = new System.Diagnostics.Stopwatch();

            // When
            var result = TwoNumsAddToTargetSolution.GetIndexesThatAddUp(nums, target);

            // Then
            Assert.Null(result);
        }

        [Theory]
        [InlineData(new int[] { 1, 3, 7, 9, 2 }, 11, new int[] { 3, 4 })]
        [InlineData(new int[] { 11, 0 }, 11, new int[] { 0, 1 })]
        public void ShouldFindTheSolutionBruteForce(int[] nums, int target, int[] result)
        {
            // When
            var actualResult = TwoNumsAddToTargetSolution.GetIndexesThatAddUp(nums, target);
            // Then
            Assert.Equal(result, actualResult);
        }

        #region Optimized solution

        [Theory]
        [InlineData(new int[] { }, 11)]
        [InlineData(new int[] { 1 }, 11)]
        [InlineData(new int[] { 11 }, 11)]
        [InlineData(new int[] { 1, 3, 7, 5, 2 }, 11)]
        public void ShouldReturnNullWhenThereIsNoSolutionOptimized(int[] nums, int target)
        {
            var watch = new System.Diagnostics.Stopwatch();

            // When
            var result = TwoNumsAddToTargetSolution.GetIndexesThatAddUpOptimized(nums, target);

            // Then
            Assert.Null(result);
        }

        [Theory]
        [InlineData(new int[] { 1, 3, 7, 9, 2 }, 11, new int[] { 3, 4 })]
        [InlineData(new int[] { 11, 0 }, 11, new int[] { 0, 1 })]
        public void ShouldFindTheSolutionOptimized(int[] nums, int target, int[] result)
        {
            // When
            var actualResult = TwoNumsAddToTargetSolution.GetIndexesThatAddUpOptimized(nums, target);
            // Then
            Assert.Equal(result, actualResult);
        }

        #endregion

        [Theory]
        [InlineData(new int[] { -1, 0, 1, 2, -1, -4 })]
        public void ShouldFindTheSolutionThreeSum(int[] nums)
        {
            // When
            var actualResult = TwoNumsAddToTargetSolution.ThreeSum(nums);
            // Then
        }
    }
}