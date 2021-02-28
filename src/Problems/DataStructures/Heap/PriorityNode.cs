using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.DataStructures.Heap
{
    public class PriorityNode<T> // where T : IComparable
    {
        public T Value { get; set; }
        public int Priority { get; set; }

        public PriorityNode(T data, int priority)
        {
            Value = data;
            Priority = priority;
        }
    }
}