using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Problems.DataStructures.Heap;
using Xunit;

namespace ProblemsTests.DataStructures.BinaryHeap
{
    public class MaxBinaryHeapTests
    {
        [Fact]
        public void ShouldFindSolution()
        {
            // Given
            var maxHeap = new MaxBinaryHeap<int>();
            // When
            maxHeap.Insert(41);
            maxHeap.Insert(39);
            maxHeap.Insert(33);
            maxHeap.Insert(18);
            maxHeap.Insert(27);
            maxHeap.Insert(12);
            maxHeap.Insert(55);

            maxHeap.ExtractMax();
            maxHeap.ExtractMax();
            maxHeap.ExtractMax();
            maxHeap.ExtractMax();
            maxHeap.ExtractMax();
            maxHeap.ExtractMax();
            maxHeap.ExtractMax();
            maxHeap.ExtractMax();
            // Then

        }
    }
}