using System;
using Problems.Sorting;
using Xunit;

namespace ProblemsTests.Sorting
{
    public class SelectionSortingTests
    {
        [Fact]
        public void ShouldSort()
        {
            // Given
            var arr = new int[] { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0 };
            // When
            SelectionSortingSolution.Sort(arr);
            // Then
            var expected = new int[] { 0, 1, 2, 4, 5, 6, 44, 63, 87, 99, 283 };
            Assert.Equal(expected, arr);
        }
    }
}