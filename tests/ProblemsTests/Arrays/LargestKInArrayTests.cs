using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Problems.Arrays;
using Xunit;

namespace ProblemsTests.Arrays
{
    public class LargestKInArrayTests
    {
        public static bool AreSentencesSimilar(string sentence1, string sentence2)
        {
            var difference = new List<string>();
            var wordsS1 = sentence1.Split(" ");
            var wordsS2 = sentence2.Split(" ");
            var greatest = wordsS1.Length > wordsS2.Length ? wordsS1 : wordsS2;
            var smallest = wordsS1.Length < wordsS2.Length ? wordsS1 : wordsS2;
            for (int i = 0; i < greatest.Length; i++)
            {
                if (!smallest.Contains(greatest[i]))
                {
                    difference.Add(greatest[i]);
                }
            }
            var diff = string.Join(" ", difference);
            var smallestStr = string.Join(" ", smallest);
            var greatestStr = string.Join(" ", greatest);
            if (smallestStr + " " + diff == greatestStr) return true;
            if (diff + " " + smallestStr == greatestStr) return true;
            for (int i = 0; i < smallestStr.Length; i++)
            {
                if (smallestStr[i] == ' ')
                {
                    var newStr = smallestStr.Insert(i, " " + diff);
                    if (newStr == greatestStr) return true;
                }
            }
            return false;
        }

        [Fact]
        public void CanSolve()
        {

            var r = AreSentencesSimilar("My name is Haley", "My Haley");
            // Given
            /// Input: [3, 2, -2, 5, -3]
            /// Output: 3
            /// Example 2:

            /// Input: [1, 2, 3, -4]
            /// Output: 0

            var str = "My Haley";
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == ' ')
                {
                    var t = str.Insert(i, " name is");
                }
            }
            string.Join(" ", str.Split(" "));
            Assert.Equal(3, LargestKInArray.GetLargestK(new int[] { 3, 2, -2, 5, -3 }));
            Assert.Equal(0, LargestKInArray.GetLargestK(new int[] { 1, 2, 3, -4 }));
        }
    }
}