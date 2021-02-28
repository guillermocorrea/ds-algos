using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.DataStructures.Graph
{
    public class WeightedGraph<T> where T : IComparable
    {
        public Dictionary<T, List<Edge<T>>> AdjacencyList { get; set; }

        public WeightedGraph()
        {
            AdjacencyList = new Dictionary<T, List<Edge<T>>>();
        }

        public void AddVertex(T vertex)
        {
            AdjacencyList[vertex] = new List<Edge<T>>();
        }

        public void AddEdge(T vertex1, T vertex2, int weight)
        {
            if (AdjacencyList.ContainsKey(vertex1))
            {
                AdjacencyList[vertex1].Add(new Edge<T>(vertex2, weight));
            }
            if (AdjacencyList.ContainsKey(vertex2))
            {
                AdjacencyList[vertex2].Add(new Edge<T>(vertex1, weight));
            }
        }

        public IEnumerable<T> ShortestPath(T start, T end)
        {
            var nodes = new PriorityQueueBasic<T>();
            var distances = new Dictionary<T, int>();
            var previous = new Dictionary<T, T>();
            List<T> path = new List<T>();

            // Initial state
            foreach (var vertex in AdjacencyList.Keys)
            {
                if (vertex.CompareTo(start) == 0)
                {
                    distances[vertex] = 0;
                    nodes.Enqueue(vertex, 0);
                }
                else
                {
                    distances[vertex] = int.MaxValue;
                    nodes.Enqueue(vertex, int.MaxValue);
                }
                previous[vertex] = default(T);
            }

            while (nodes.Count > 0)
            {
                var smallest = nodes.Dequeue().Value;
                if (smallest.CompareTo(end) == 0)
                {
                    // We are done!
                    // Build up the path
                    while (previous[smallest] != null)
                    {
                        path.Add(smallest);
                        smallest = previous[smallest];
                    }
                    break;
                }
                if (distances.ContainsKey(smallest) && distances[smallest] != int.MaxValue)
                {
                    foreach (var neighbor in AdjacencyList[smallest])
                    {
                        // var nextNode = AdjacencyList[smallest][neighbor];
                        // TODO: Complete!!!!
                        var candidate = distances[smallest] + neighbor.Weight;
                        if (candidate < distances[neighbor.Node])
                        {
                            // Updating new smallest distance to neighbor
                            distances[neighbor.Node] = candidate;
                            // Updating previous - How we got to neighbor
                            previous[neighbor.Node] = smallest;
                            nodes.Enqueue(neighbor.Node, candidate);
                        }
                    }
                }
            }
            path.Add(start);
            path.Reverse();
            return path;
        }
    }

    public class Edge<T>
    {
        public T Node { get; set; }
        public int Weight { get; set; }
        public Edge(T node, int weight)
        {
            Node = node;
            Weight = weight;
        }
    }
}