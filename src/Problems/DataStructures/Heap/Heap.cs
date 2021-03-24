using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.DataStructures.Heap
{
    public enum HeapType
    {
        MaxHeap,
        MinHeap
    }

    public class Heap<T> where T : IComparable
    {
        private readonly List<T> _list;
        private readonly T _min;
        private readonly T _max;
        private readonly HeapType _type;
        private readonly Func<T, T, bool> _comparator;
        private readonly Func<T, T, bool> _maxHeapComparator = (a, b) => a.CompareTo(b) > 0;
        private readonly Func<T, T, bool> _minHeapComparator = (a, b) => a.CompareTo(b) < 0;

        public Heap(T min, T max, HeapType type)
        {
            _list = new List<T>();
            _min = min;
            _max = max;
            _type = type;
            _comparator = type == HeapType.MaxHeap ? _maxHeapComparator : _minHeapComparator;
        }

        public void Insert(T data)
        {
            _list.Add(data);
            HeapifyUp(_list.Count - 1);
        }

        private void HeapifyUp(int idx)
        {
            if (_list.Count == 1) return;
            var parentIdx = (int)Math.Floor((idx - 1) / 2m);
            if (parentIdx < 0) return;
            if (_comparator.Invoke(_list[idx], _list[parentIdx]))
            {
                Swap(idx, parentIdx);
            }
            HeapifyUp(parentIdx);
        }

        private void Swap(int sourceIdx, int targetIndex)
        {
            var temp = _list[sourceIdx];
            _list[sourceIdx] = _list[targetIndex];
            _list[targetIndex] = temp;
        }

        public T Remove()
        {
            if (_list.Count == 0) throw new InvalidOperationException("No elements to remove");
            var max = _list[0];
            if (_list.Count <= 1) return max;
            Swap(_list.Count - 1, 0);
            _list.RemoveAt(_list.Count - 1);
            SinkDown(0);
            return max;
        }

        private void SinkDown(int idx)
        {
            int leftIdx = (idx * 2) + 1;
            int rightIdx = (idx * 2) + 2;
            var currValue = _list[idx];
            var leftValue = leftIdx < _list.Count ? _list[leftIdx] : _type == HeapType.MaxHeap ? _min : _max;
            var rightValue = rightIdx < _list.Count ? _list[rightIdx] : _type == HeapType.MaxHeap ? _min : _max;
            var (maxValue, maxIndex) = _comparator.Invoke(leftValue, rightValue) ? (leftValue, leftIdx) : (rightValue, rightIdx);
            if (_comparator.Invoke(maxValue, currValue))
            {
                Swap(idx, maxIndex);
                SinkDown(maxIndex);
            }
        }

        public int Count()
        {
            return _list.Count;
        }

        public bool IsEmpty()
        {
            return _list.Count == 0;
        }

        public T Peek()
        {
            if (IsEmpty()) throw new InvalidOperationException("No elements to Peek");
            return _list[0];
        }
    }
}