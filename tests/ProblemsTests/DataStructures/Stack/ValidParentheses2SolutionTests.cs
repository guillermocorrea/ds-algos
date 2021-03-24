using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Problems.DataStructures.queue;
using Problems.DataStructures.Stack;
using Xunit;

namespace ProblemsTests.DataStructures.Stack
{
    public class ValidParentheses2SolutionTests
    {
        [Fact]
        public void ShouldFindSolution()
        {
            // Given
            string str1 = "a)bc(d)";
            string str2 = "(ab(c)d";
            string str3 = "))((";
            // When
            // Then
            Assert.Equal("abc(d)", ValidadParentheses2.RemoveMinimunParentheses(str1));
            Assert.Equal("(abc)d", ValidadParentheses2.RemoveMinimunParentheses(str2));
            Assert.Equal("", ValidadParentheses2.RemoveMinimunParentheses(str3));
        }
    }
}