using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Problems.DataStructures.Graph;
using Xunit;

namespace ProblemsTests.DataStructures.Graph
{
    public class NetworkTimeDelayTests
    {

        [Fact]
        public void CanSolveDijkstra()
        {
            // Given
            int n = 5, k = 1;
            var times = new int[][]
            {
                new int[] { 1, 2, 9 },
                new int[] { 1, 4, 2 },
                new int[] { 2, 5, 1 },
                new int[] { 4, 2, 4 },
                new int[] { 4, 5, 6 },
                new int[] { 3, 2, 3 },
                new int[] { 5, 3, 7 },
                new int[] { 3, 1, 5 },
            };
            // When
            var result = NetworkTimeDelay.SolveNetworkTimeDelay(n, k, times);

            // Then
            Assert.Equal(14, result);

            Assert.Equal(-1, NetworkTimeDelay.SolveNetworkTimeDelay(3, 2, new int[][] {
                new int[] {2, 3, 4}
            }));

            Assert.Equal(-1, NetworkTimeDelay.SolveNetworkTimeDelay(3, 1, new int[][] {
                new int[] {1, 2, 8},
                new int[] {3, 1, 3},
            }));
        }

        [Fact]
        public void CanSolveDijkstraNegatives()
        {
            // Given
            int n = 5, k = 1;
            var times = new int[][]
            {
                new int[] { 1, 4, 2 },
                new int[] { 1, 2, 9 },
                new int[] { 4, 2, -4 },
                new int[] { 2, 5, -3 },
                new int[] { 4, 5, 6 },
                new int[] { 5, 3, 7 },
                new int[] { 3, 2, 3 },
                new int[] { 3, 1, 5 },
            };
            // When
            var result = NetworkTimeDelay.SolveNetworkTimeDelayBellmanFord(n, k, times);

            // Then
            Assert.Equal(2, result);
        }
    }
}