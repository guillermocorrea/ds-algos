using System;
using Problems.Strings;
using Xunit;

namespace ProblemsTests.Strings
{
    public class AreEqualTests
    {
        [Theory]
        [InlineData("ab#c", "az#c", true)]
        [InlineData("Ab#c", "az#c", false)]
        [InlineData("ab###c", " az####c", true)]
        [InlineData("y#fo##f", "y#f#o##f", true)]
        public void ShouldFindSolution(string s, string t, bool expectedResult)
        {
            var result = AreEqualSolution.AreEqual(s, t);
            Assert.Equal(expectedResult, result);
        }

        // [Theory]
        // [InlineData("ab#c", "az#c", true)]
        // [InlineData("Ab#c", "az#c", false)]
        // [InlineData("ab###c", " az####c", true)]
        // [InlineData("y#fo##f", "y#f#o##f", true)]
        // public void ShouldFindOptimalSolution(string s, string t, bool expectedResult)
        // {
        //     var result = AreEqualSolution.AreEqualOptimal(s, t);
        //     Assert.Equal(expectedResult, result);
        // }
    }
}