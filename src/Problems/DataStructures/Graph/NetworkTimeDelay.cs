using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.DataStructures.Graph
{
    public class NetworkTimeDelay
    {
        /// <summary>
        /// n^2
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <param name="times"></param>
        /// <returns></returns>
        public static int SolveNetworkTimeDelay(int n, int k, int[][] times)
        {
            var graph = new Graph();
            var distance = new int[n];
            for (int i = 1; i <= n; i++) // n
            {
                graph.AddVertex(i);
                distance[i - 1] = int.MaxValue;
            }
            for (int i = 0; i < times.Length; i++) // times.Length
            {
                var source = times[i][0];
                var target = times[i][1];
                var weight = times[i][2];
                graph.AddEdge(source, target, weight);
            }

            var queue = new Queue<int>();
            queue.Enqueue(k);
            distance[k - 1] = 0;
            while (queue.Count > 0) // n^2
            {
                var current = queue.Dequeue();
                var adjacent = graph.AdjacencyList[current];
                for (int i = 0; i < adjacent.Count; i++) // n
                {
                    var edge = adjacent[i];
                    var targetDistance = distance[current - 1] + edge.Weight;
                    if (targetDistance < distance[edge.Target - 1])
                    {
                        distance[edge.Target - 1] = targetDistance;
                        queue.Enqueue(edge.Target);
                    }
                }
            }
            int greatestDistance = distance.Max();
            return greatestDistance == int.MaxValue ? -1 : greatestDistance;
        }

        public static int SolveNetworkTimeDelayBellmanFord(int n, int k, int[][] times)
        {
            var distance = new int[n];
            for (var i = 0; i < n; i++)
            {
                distance[i] = int.MaxValue;
            }
            distance[k - 1] = 0;
            for (var i = 0; i < n - 1; i++)
            {
                int count = 0;
                for (int j = 0; j < times.Length; j++)
                {
                    var source = times[j][0];
                    var target = times[j][1];
                    var weight = times[j][2];
                    if (distance[source - 1] + weight < distance[target - 1])
                    {
                        distance[target - 1] = distance[source - 1] + weight;
                        count++;
                    }
                }
                if (count == 0) break;
            }
            var greatest = distance.Max();
            return greatest == int.MaxValue ? -1 : greatest;
        }
    }

    class Graph
    {
        public Dictionary<int, List<Edge>> AdjacencyList = new Dictionary<int, List<Edge>>();

        public void AddVertex(int data)
        {
            AdjacencyList[data] = new List<Edge>();
        }

        public void AddEdge(int source, int target, int weight)
        {
            AdjacencyList[source].Add(new Edge { Target = target, Weight = weight });
        }
    }

    class GraphNode
    {
        public int Data { get; set; }
    }

    class Edge
    {
        public int Target { get; set; }
        public int Weight { get; set; }
    }
}