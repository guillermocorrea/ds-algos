using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.DataStructures.Heap
{
    public class PriorityQueue<T> where T : IComparable
    {
        private List<PriorityNode<T>> _values { get; set; }

        public PriorityQueue()
        {
            _values = new List<PriorityNode<T>>();
        }

        public void Enqueue(T data, int priority)
        {
            _values.Add(new PriorityNode<T>(data, priority));
            BubbleUp();
        }

        public PriorityNode<T> Dequeue()
        {
            if (_values.Count == 0) return null;
            var max = _values[0];
            var end = _values[_values.Count - 1];
            _values.RemoveAt(_values.Count - 1);
            if (_values.Count > 0)
            {
                _values[0] = end;
                SinkDown();
            }

            return max;
        }

        private void SinkDown()
        {
            int idx = 0;
            int length = _values.Count;
            var element = _values[0];
            while (true)
            {
                var leftChildIdx = 2 * idx + 1;
                var rightChildIdx = 2 * idx + 2;
                PriorityNode<T> leftChild = null, rightChild = null;
                int? swapIdx = null;

                if (leftChildIdx < length)
                {
                    leftChild = _values[leftChildIdx];
                    if (leftChild.Priority.CompareTo(element.Priority) < 0)
                    {
                        swapIdx = leftChildIdx;
                    }
                }
                if (rightChildIdx < length)
                {
                    rightChild = _values[rightChildIdx];
                    if (swapIdx == null && rightChild.Priority.CompareTo(element.Priority) < 0 ||
                        swapIdx != null && rightChild.Priority.CompareTo(leftChild.Priority) < 0)
                    {
                        swapIdx = rightChildIdx;
                    }
                }

                if (swapIdx == null) break;
                _values[idx] = _values[swapIdx.Value];
                _values[swapIdx.Value] = element;
                idx = swapIdx.Value;
            }
        }


        private void BubbleUp()
        {
            int idx = _values.Count - 1;
            var element = _values[idx];
            while (true)
            {
                int parentIdx = (int)Math.Floor((idx - 1) / 2m);
                if (parentIdx >= 0 && parentIdx < _values.Count)
                {
                    var parent = _values[parentIdx];
                    if (element.Priority.CompareTo(parent.Priority) >= 0) break;
                    _values[parentIdx] = element;
                    _values[idx] = parent;
                    idx = parentIdx;
                }
                else
                {
                    break;
                }
            }
        }
    }
}