
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Problems.DataStructures.Graph;
using Xunit;

namespace ProblemsTests.DataStructures.Graph
{
    public class GraphTests
    {
        [Fact]
        public void ShouldInsertVertex()
        {
            // Given
            var graph = new Graph<string>();

            // When
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("E");
            graph.AddVertex("F");

            graph.AddEdge("A", "B");
            graph.AddEdge("A", "E");
            graph.AddEdge("E", "F");
            graph.AddEdge("B", "C");
            graph.AddEdge("B", "D");
            graph.AddEdge("C", "D");
            graph.AddEdge("D", "E");
            graph.AddEdge("D", "F");

            // graph.AddEdge("Madrid", "Cali");

            // graph.RemoveEdge("Madrid", "Brisbane");
            // graph.RemoveEdge("Madrid", "Bogota");

            // graph.RemoveVertex("Madrid");
            // graph.RemoveVertex("Tokyo");

            // Then
            var dfsResult = graph.DepthFirstRecursive("A");
            var dfsIrerativeResult = graph.DepthFirstIterative("A");
            var bfsResult = graph.BreadthFirstIterative("A");
        }
    }
}