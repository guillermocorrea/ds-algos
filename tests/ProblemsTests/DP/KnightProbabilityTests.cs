using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Problems.DP;
using Xunit;

namespace ProblemsTests.DP
{
    public class KnightProbabilityTests
    {
        [Fact]
        public void CanSolve()
        {
            // Given
            int n = 6, k = 2, r = 2, c = 2;

            // When
            var result = KnightProbability.GetKnightProbability(n, k, r, c);
            Console.WriteLine(result);
            // Then
            Assert.True(result == 0.531250m);
        }
    }
}