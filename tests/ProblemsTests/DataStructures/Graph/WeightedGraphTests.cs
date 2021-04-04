
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Problems.DataStructures.Graph;
using Xunit;

namespace ProblemsTests.DataStructures.Graph
{
    public class WeightedGraphTests
    {
        [Fact]
        public void ShouldInsertVertex()
        {
            // Given
            var graph = new WeightedGraph<string>();

            // When
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("E");
            graph.AddVertex("F");

            graph.AddEdge("A", "B", 4);
            graph.AddEdge("A", "C", 2);
            graph.AddEdge("B", "E", 3);
            graph.AddEdge("C", "D", 2);
            graph.AddEdge("C", "F", 4);
            graph.AddEdge("D", "E", 3);
            graph.AddEdge("D", "F", 1);
            graph.AddEdge("E", "F", 1);

            var shortestPath = graph.ShortestPath("A", "E");
            // graph.AddEdge("Madrid", "Cali");

            // graph.RemoveEdge("Madrid", "Brisbane");
            // graph.RemoveEdge("Madrid", "Bogota");

            // graph.RemoveVertex("Madrid");
            // graph.RemoveVertex("Tokyo");

            // Then
            // var dfsResult = graph.DepthFirstRecursive("A");
            // var dfsIrerativeResult = graph.DepthFirstIterative("A");
            // var bfsResult = graph.BreadthFirstIterative("A");
        }
    }
}