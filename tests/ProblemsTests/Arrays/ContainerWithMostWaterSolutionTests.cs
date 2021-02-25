using Problems.Arrays;
using Xunit;

namespace ProblemsTests.Arrays
{
    public class ContainerWithMostWaterSolutionTests
    {
        [Theory]
        [InlineData(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
        public void ShouldFindSolution(int[] heights, int expected)
        {
            var actualResult = ContainerWithMostWaterSolution.ContainerWithMostWater(heights);
            Assert.Equal(expected, actualResult);
        }

        [Theory]
        [InlineData(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
        public void ShouldFindSolutionOptimized(int[] heights, int expected)
        {
            var actualResult = ContainerWithMostWaterSolution.ContainerWithMostWaterOptimized(heights);
            Assert.Equal(expected, actualResult);
        }
    }
}