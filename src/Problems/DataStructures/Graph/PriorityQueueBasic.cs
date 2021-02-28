using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Problems.DataStructures.Heap;

namespace Problems.DataStructures.Graph
{
    public class PriorityQueueBasic<T> // where T : IComparable
    {
        private List<PriorityNode<T>> _values { get; set; }
        public PriorityQueueBasic()
        {
            _values = new List<PriorityNode<T>>();
        }

        public void Enqueue(T val, int priority)
        {
            _values.Add(new PriorityNode<T>(val, priority));
            Sort();
        }

        public PriorityNode<T> Dequeue()
        {
            if (_values.Count == 0) return null;
            var element = _values[0];
            _values.RemoveAt(0);
            return element;
        }

        public int Count { get => _values.Count; }

        public void Sort()
        {
            _values.Sort((a, b) => a.Priority - b.Priority);
        }
    }
}