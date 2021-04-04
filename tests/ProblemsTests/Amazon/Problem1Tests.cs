using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProblemsTests.Amazon
{
    public class Problem1Tests
    {
        [Fact]
        public void ShouldFindSolution()
        {
            // Given
            var jeans = new List<int> { 2, 3 };
            var shoes= new List<int> { 4 };
            var skirts = new List<int> { 2, 3 };
            var tops = new List<int> { 1, 2 };
            int budget = 10;
            // When
            var result = Problems.Amazon.Problem1.Solution(jeans, shoes, skirts, tops, budget);
            // Then
            Assert.Equal(4, result);
        }
    }
}
