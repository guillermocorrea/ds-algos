using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.DataStructures.Graph
{
    public class Graph<T>
    {
        public Dictionary<T, List<T>> AdjacencyList { get; set; }

        public Graph()
        {
            AdjacencyList = new Dictionary<T, List<T>>();
        }

        public void AddVertex(T vertex)
        {
            AdjacencyList[vertex] = new List<T>();
        }

        public void AddEdge(T vertex1, T vertex2)
        {
            if (AdjacencyList.ContainsKey(vertex1))
            {
                AdjacencyList[vertex1].Add(vertex2);
            }
            if (AdjacencyList.ContainsKey(vertex2))
            {
                AdjacencyList[vertex2].Add(vertex1);
            }
        }

        public void RemoveEdge(T vertex1, T vertex2)
        {
            if (AdjacencyList.ContainsKey(vertex1))
            {
                AdjacencyList[vertex1].Remove(vertex2);
            }
            if (AdjacencyList.ContainsKey(vertex2))
            {
                AdjacencyList[vertex2].Remove(vertex1);
            }
        }

        public void RemoveVertex(T vertex)
        {
            if (AdjacencyList.ContainsKey(vertex))
            {
                while (AdjacencyList[vertex].Count > 0)
                {
                    var adjacentVertex = AdjacencyList[vertex][0];
                    AdjacencyList[vertex].RemoveAt(0);
                    RemoveEdge(vertex, adjacentVertex);
                }
                AdjacencyList.Remove(vertex);
            }
        }

        public IEnumerable<T> DepthFirstRecursive(T vertex)
        {
            if (!AdjacencyList.ContainsKey(vertex) || AdjacencyList[vertex].Count == 0) return new List<T>();
            var result = new List<T>();
            var visited = new Dictionary<T, bool>();
            DFSHelper(vertex, result, visited);
            return result;
        }

        // video 56
        private void DFSHelper(T vertex, List<T> result, Dictionary<T, bool> visited)
        {
            visited[vertex] = true;
            result.Add(vertex);
            if (!AdjacencyList.ContainsKey(vertex) || AdjacencyList[vertex].Count == 0)
            {
                return;
            }
            foreach (var adjacentVertext in AdjacencyList[vertex])
            {
                if (!visited.ContainsKey(adjacentVertext)) DFSHelper(adjacentVertext, result, visited);
            }
        }

        public IEnumerable<T> DepthFirstIterative(T vertex)
        {
            if (!AdjacencyList.ContainsKey(vertex) || AdjacencyList[vertex].Count == 0) return new List<T>();
            var result = new List<T>();
            var visited = new Dictionary<T, bool>();
            var stack = new Stack<T>();
            stack.Push(vertex);
            while (stack.Count > 0)
            {
                var currentVertex = stack.Pop();
                if (!visited.ContainsKey(currentVertex))
                {
                    visited[currentVertex] = true;
                    result.Add(currentVertex);
                    foreach (var adjacentVertext in AdjacencyList[currentVertex])
                    {
                        if (!visited.ContainsKey(adjacentVertext)) stack.Push(adjacentVertext);
                    }
                }
            }
            return result;
        }

        public IEnumerable<T> BreadthFirstIterative(T vertex)
        {
            if (!AdjacencyList.ContainsKey(vertex) || AdjacencyList[vertex].Count == 0) return new List<T>();
            var result = new List<T>();
            var visited = new Dictionary<T, bool>();
            var queue = new Queue<T>();
            queue.Enqueue(vertex);
            while (queue.Count > 0)
            {
                var currentVertex = queue.Dequeue();
                if (!visited.ContainsKey(currentVertex))
                {
                    visited[currentVertex] = true;
                    result.Add(currentVertex);
                    foreach (var adjacentVertext in AdjacencyList[currentVertex])
                    {
                        if (!visited.ContainsKey(adjacentVertext)) queue.Enqueue(adjacentVertext);
                    }
                }
            }
            return result;
        }
    }
}