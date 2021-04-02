using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Problems.DataStructures.Graph;
using Xunit;

namespace ProblemsTests.DataStructures.Graph
{
    public class TimeNeededToInformEmployeesTest
    {
        [Fact]
        public void CanSolve()
        {
            // Given
            int n = 8, headId = 4;
            var managers = new int[] { 2, 2, 4, 6, -1, 4, 4, 5 };
            var informTime = new int[] { 0, 0, 4, 0, 7, 3, 6, 0 };

            // When
            var res = TimeNeededToInformEmployeesSolution.TimeNeededToInformAllEmployees(n, headId, managers, informTime);

            // Then
            Assert.Equal(13, res);
        }
    }
}