using Problems.DataStructures.Heap;
using Xunit;

namespace ProblemsTests.DataStructures.Heap
{
    public class MaxHeapTests
    {
        [Fact]
        public void CanInsertMinHeap()
        {
            // Given
            var minHeap = new Heap<int>(int.MinValue, int.MaxValue, HeapType.MinHeap);
            // When
            minHeap.Insert(50);
            minHeap.Insert(45);
            minHeap.Insert(25);
            minHeap.Insert(10);
            minHeap.Insert(15);
            minHeap.Insert(40);
            minHeap.Insert(35);
            minHeap.Insert(20);
            minHeap.Insert(75);
            // Then
            var min = minHeap.Remove();
            Assert.Equal(10, min);
        }

        [Fact]
        public void CanInsertMaxHeap()
        {
            // Given
            var maxHeap = new Heap<int>(int.MinValue, int.MaxValue, HeapType.MaxHeap);
            // When
            maxHeap.Insert(50);
            maxHeap.Insert(45);
            maxHeap.Insert(25);
            maxHeap.Insert(10);
            maxHeap.Insert(15);
            maxHeap.Insert(40);
            maxHeap.Insert(35);
            maxHeap.Insert(20);
            maxHeap.Insert(75);
            // Then
            var max = maxHeap.Remove();
            Assert.Equal(75, max);
        }
    }
}