using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Problems.DataStructures.Heap;
using Xunit;

namespace ProblemsTests.DataStructures.BinaryHeap
{
    public class PriorityQueueTests
    {
        [Fact]
        public void ShouldFindSolution()
        {
            // Given
            var er = new PriorityQueue<string>();
            // When
            er.Enqueue("Fever", 3);
            er.Enqueue("Open wound", 2);
            er.Enqueue("Gun shot", 1);

            er.Dequeue();
            er.Dequeue();
            er.Dequeue();
            er.Dequeue();
            // Then

        }
    }
}