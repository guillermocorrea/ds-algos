using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Problems.Sorting;
using Xunit;

namespace ProblemsTests.Sorting
{
    public class QuickSortTests
    {
        [Fact]
        public void ShouldFindSolution()
        {
            // Given
            int[] arr = new int[] { 4, 2, 7, 6, 5, 3, 1, 8 };
            // When
            // QuickSort.Sort(arr);
            var result = QuickSort.FindKGreaterElement(arr, 2);
            // Then

        }
    }
}