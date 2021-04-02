using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.DataStructures.Graph
{
    public class CourseSchedulerSolution
    {
        public static bool CanFinishAllCoursesBruteForce(int n, int[][] prereqs)
        {
            if (prereqs.Length == 0) return false;
            var adjacencyList = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++) // O(n)
            {
                adjacencyList[i] = new List<int>();
            }
            for (int i = 0; i < prereqs.Length; i++) // O(m), m = prereqs.Length
            {
                var to = prereqs[i][0];
                var from = prereqs[i][1];
                adjacencyList[from].Add(to);
            }
            for (int i = 0; i < n; i++) // O(n) ^3
            {
                var queue = new Queue<int>(adjacencyList[i]);
                var seen = new HashSet<int>() { i };
                while (queue.Count > 0)
                {
                    var current = queue.Dequeue();
                    if (seen.Contains(current))
                    {
                        // Cycle detected!
                        return false;
                    }
                    foreach (var next in adjacencyList[current])
                        queue.Enqueue(next);
                }
            }

            return true;
        }

        public static bool CanFinishAllCoursesTopologicalSort(int n, int[][] prereqs)
        {
            var indegree = new Dictionary<int, int>();
            var adjacencyList = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++) // T: O(n) S: O(n)
            {
                indegree[i] = 0;
                adjacencyList[i] = new List<int>();
            }
            for (var i = 0; i < prereqs.Length; i++) // T: O(m) m = prereqs.Length
            {
                var to = prereqs[i][0];
                var from = prereqs[i][1];
                indegree[to]++;
                adjacencyList[from].Add(to);
            }

            while (indegree.Count > 0) // T: O(n) ^2+m
            {
                int current = int.MaxValue;
                foreach (var kv in indegree) // T: O(n)
                {
                    if (kv.Value == 0)
                    {
                        current = kv.Key;
                        break;
                    }
                }
                if (current == int.MaxValue) return false;
                indegree.Remove(current);
                if (adjacencyList.TryGetValue(current, out var connections))
                {
                    for (int i = 0; i < connections.Count; i++) // T: O(n)
                    {
                        var key = connections[i];
                        if (indegree.ContainsKey(key))
                            indegree[key]--;
                    }
                }
            }
            return true;
        }
    }
}