using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Problems.Arrays;
using Xunit;

namespace ProblemsTests.Arrays
{
    public class MinStepsToMakePilesEqualHeightTests
    {
        [Fact]
        public void CanSolve()
        {
            // Given
            var arr = new int[] { 5, 2, 1 };

            // When
            var result = MinStepsToMakePilesEqualHeight.MinSteps(arr);

            // Then
            Assert.Equal(3, result);
            Assert.Equal(7, MinStepsToMakePilesEqualHeight.MinSteps(new int[] { 5, 2, 2, 3, 1 }));
            Assert.Equal(1, MinStepsToMakePilesEqualHeight.MinSteps(new int[] { 2, 2, 2, 3, 2 }));
        }
    }
}