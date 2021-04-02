using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.DP
{
    public class ClimbingStairs
    {
        public static int Solve(int[] steps)
        {
            //  _  _  _ _ _
            // 20 15 30 5
            if (steps.Length <= 1) return 0;
            var memo = new Dictionary<int, int>();
            // return Math.Min(MinCost(currentStep: steps.Length - 1, steps, memo), MinCost(currentStep: steps.Length - 2, steps, memo));
            return MinCostBottomUp(steps);
        }

        /// <summary>
        /// Top down approach T: O(n), S: O(n)
        /// </summary>
        /// <param name="currentStep"></param>
        /// <param name="steps"></param>
        /// <param name="memo"></param>
        /// <returns></returns>
        private static int MinCost(int currentStep, int[] steps, Dictionary<int, int> memo)
        {
            if (memo.ContainsKey(currentStep)) return memo[currentStep];
            if (currentStep < 0) return 0;
            if (currentStep <= 1) return steps[currentStep];
            memo[currentStep] = steps[currentStep] + Math.Min(MinCost(currentStep - 1, steps, memo), MinCost(currentStep - 2, steps, memo));
            return memo[currentStep];
        }

        private static int MinCostBottomUp(int[] steps)
        {
            int prev = steps[1];
            int beforePrev = steps[0];
            for (int i = 2; i < steps.Length; i++)
            {
                var tempPrev = prev;
                prev = steps[i] + Math.Min(prev, beforePrev);
                beforePrev = tempPrev;
            }
            return Math.Min(prev, beforePrev);
        }
    }
}