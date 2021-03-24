using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Problems.DataStructures.Stack;
using Xunit;

namespace ProblemsTests.DataStructures.Stack
{
    public class ValidParenthesesSolutionTests
    {
        [Fact]
        public void ShouldFindSolution()
        {
            // Given
            var str = "{([])}";
            // When
            var result = ValidParenthesesSolution.ValidParentheses(str);
            // Then
            Assert.True(result);
            Assert.False(ValidParenthesesSolution.ValidParentheses("{([]"));
            Assert.False(ValidParenthesesSolution.ValidParentheses("}})]"));
            Assert.False(ValidParenthesesSolution.ValidParentheses("{{}}}}"));
        }
    }
}