using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.DataStructures.Heap
{
    public class MaxBinaryHeap<T> where T : IComparable
    {
        private List<T> _values { get; set; }

        public MaxBinaryHeap()
        {
            _values = new List<T>();
        }

        public void Insert(T element)
        {
            _values.Add(element);
            BubbleUp();
        }

        public T ExtractMax()
        {
            if (_values.Count == 0) return default(T);
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
                T leftChild = default(T), rightChild = default(T);
                int? swapIdx = null;

                if (leftChildIdx < length)
                {
                    leftChild = _values[leftChildIdx];
                    if (leftChild.CompareTo(element) > 0)
                    {
                        swapIdx = leftChildIdx;
                    }
                }
                if (rightChildIdx < length)
                {
                    rightChild = _values[rightChildIdx];
                    if (swapIdx == null && rightChild.CompareTo(element) > 0 ||
                        swapIdx != null && rightChild.CompareTo(leftChild) > 0)
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
            T element = _values[idx];
            while (true)
            {
                int parentIdx = (int)Math.Floor((idx - 1) / 2m);
                if (parentIdx >= 0 && parentIdx < _values.Count)
                {
                    T parent = _values[parentIdx];
                    if (element.CompareTo(parent) <= 0) break;
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