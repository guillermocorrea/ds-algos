using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Amazon
{
    public class Problem1
    {
        // Different options to shop https://leetcode.com/discuss/interview-question/974912/Amazon-or-Phone-or-Find-all-combinations-of-numbers-that-sum-to-a-target/792368
        public static int Solution(List<int> priceOfJeans, List<int> priceOfShoes,
            List<int> priceOfSkirts, List<int> priceOfTops, int budget)
        {
            var mapCD = new Dictionary<string, int>();
            foreach (var c in priceOfSkirts)
            {
                foreach (var d in priceOfTops)
                {
                    mapCD[$"c{c}d{d}"] = c + d;
                }
            }
            var mapAB = new Dictionary<string, int>();
            int result = 0;
            foreach (var a in priceOfJeans)
            {
                foreach (var b in priceOfShoes)
                {
                    mapAB[$"a{a}b{b}"] = a + b;
                }
            }
            foreach (var ab in mapAB.Values)
            {
                foreach (var cd in mapCD.Values)
                {
                    if (ab + cd <= budget) result++;
                }
            }
            return result;
        }
    }
}
