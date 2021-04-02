using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.DataStructures.Graph
{
    public class TimeNeededToInformEmployeesSolution
    {
        public static int TimeNeededToInformAllEmployees(int n, int headId, int[] managers, int[] informTime)
        {
            if (n <= 1) return 0;
            int time = 0;
            var graph = new WeightedGraph<int>();
            for (int i = 0; i < n; i++)
            {
                graph.AddVertex(i);
            }
            for (int i = 0; i < n; i++)
            {
                if (i == headId) continue;
                graph.AddEdge(managers[i], i, informTime[managers[i]]);
            }

            var subordinates = graph.AdjacencyList[headId];
            foreach (var subordinate in subordinates)
            {
                time = Math.Max(time, TimeNeededToInformAllEmployeesRecursive(graph, subordinate, subordinate.Weight));
            }
            return time;
        }

        private static int TimeNeededToInformAllEmployeesRecursive(WeightedGraph<int> graph, Edge<int> subordinate, int time)
        {
            if (graph.AdjacencyList[subordinate.Node].Count == 0) return time;
            var currentSubordinates = graph.AdjacencyList[subordinate.Node];
            int maxTime = 0;
            foreach (var currentSubordinate in currentSubordinates)
            {
                maxTime = Math.Max(maxTime, TimeNeededToInformAllEmployeesRecursive(graph, currentSubordinate, currentSubordinate.Weight + time));
            }
            return maxTime;
        }
    }
}