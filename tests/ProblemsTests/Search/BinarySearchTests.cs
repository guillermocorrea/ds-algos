using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Problems.Search;
using Xunit;

namespace ProblemsTests.Search
{
    public class BinarySearchTests
    {
        [Fact]
        public void FindSolution()
        {
            Assert.Equal(4, BinarySearch.FindBinarySearch(Enumerable.Range(1, 7).ToArray(), 5));
            Assert.Equal(-1, BinarySearch.FindBinarySearch(new int[] { 1, 2, 3 }, 5));
            Assert.Equal(-1, BinarySearch.FindBinarySearch(new int[] { }, 1));
            Assert.Equal(0, BinarySearch.FindBinarySearch(new int[] { 1, 2 }, 1));
            Assert.Equal(0, BinarySearch.FindBinarySearch(new int[] { 1, 2, 3 }, 1));

            Assert.Equal(new int[] { 4, 4 }, BinarySearch.GetStartingAndEndingIndexOfTarget(Enumerable.Range(1, 9).ToArray(), 5));
            Assert.Equal(new int[] { 3, 5 }, BinarySearch.GetStartingAndEndingIndexOfTarget(new int[] { 1, 3, 3, 5, 5, 5, 9 }.ToArray(), 5));
        }
    }
}