using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Sorting
{
    public class QuickSort
    {
        public static void Sort(int[] arr)
        {
            QuickSortRecursive(arr, 0, arr.Length - 1);
        }

        public static int FindKGreaterElement(int[] arr, int k)
        {
            return FindKGreaterElementRecursive(arr, 0, arr.Length - 1, k);
        }

        private static int FindKGreaterElementRecursive(int[] arr, int left, int right, int k)
        {
            if (left < right)
            {
                var partitionIdx = Partition(arr, left, right);
                if (partitionIdx == k) return arr[partitionIdx];
                if (partitionIdx < k)
                    return FindKGreaterElementRecursive(arr, left, partitionIdx - 1, k);
                else
                    return FindKGreaterElementRecursive(arr, partitionIdx + 1, right, k);
            }
            return arr[k - 1];
        }

        private static void QuickSortRecursive(int[] arr, int left, int right)
        {
            if (left < right)
            {
                var partitionIdx = Partition(arr, left, right);
                QuickSortRecursive(arr, left, partitionIdx - 1);
                QuickSortRecursive(arr, partitionIdx + 1, right);
            }
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int partitionIdx = left;
            for (int j = left; j < right; j++)
            {
                if (arr[j] < pivot)
                {
                    Swap(arr, partitionIdx, j);
                    partitionIdx++;
                }
            }
            Swap(arr, partitionIdx, right);
            return partitionIdx;
        }

        private static void Swap(int[] arr, int source, int dest)
        {
            var destElement = arr[dest];
            arr[dest] = arr[source];
            arr[source] = destElement;
        }
    }
}