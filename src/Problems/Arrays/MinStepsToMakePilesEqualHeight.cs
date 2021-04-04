using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Arrays
{
    public class MinStepsToMakePilesEqualHeight
    {
        public static int MinSteps(int[] arr)
        {
            Array.Sort(arr, (a, b) => b.CompareTo(a)); // nlogn
            int steps = 0;
            while (true) // ?
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] != arr[i + 1])
                    {
                        steps++;
                        var diff = arr[i] - arr[i + 1];
                        arr[i] -= diff;
                        break;
                    }
                    else if (i == arr.Length - 2) return steps;
                }
            }
        }
    }
}