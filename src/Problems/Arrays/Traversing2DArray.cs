using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Arrays
{
    public class Traversing2DArray
    {
        /// <summary>
        /// T: O(rows*cols) S: O(rows*cols)
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static List<int> DFS(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0) return new List<int>();
            var result = new List<int>();
            var visited = new HashSet<string>();
            DFSRecursive(matrix, row: 0, col: 0, result, visited);
            return result;
        }

        private static void DFSRecursive(int[][] matrix, int row, int col, List<int> result, HashSet<string> visited)
        {
            var key = GetKey(row, col);
            if (!visited.Contains(key))
            {
                result.Add(matrix[row][col]);
                visited.Add(key);
            }
            if (row - 1 >= 0 && !visited.Contains(GetKey(row - 1, col)))
                DFSRecursive(matrix, row - 1, col, result, visited);
            if (col + 1 < matrix[row].Length && !visited.Contains(GetKey(row, col + 1)))
                DFSRecursive(matrix, row, col + 1, result, visited);
            if (row + 1 < matrix.Length && !visited.Contains(GetKey(row + 1, col)))
                DFSRecursive(matrix, row + 1, col, result, visited);
            if (col - 1 >= 0 && !visited.Contains(GetKey(row, col - 1)))
                DFSRecursive(matrix, row, col - 1, result, visited);
        }

        private static string GetKey(int row, int col) => $"{row}-{col}";

        /// <summary>
        /// T: O(n) S: O(n)
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static List<int> BFS(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0) return new List<int>();
            var values = new List<int>();
            var queue = new Queue<(int Value, int row, int col)>();
            queue.Enqueue((matrix[0][0], 0, 0));
            var seen = new HashSet<string>();
            while (queue.Count > 0)
            {
                var (current, currRow, currCol) = queue.Dequeue();
                if (seen.Contains(GetKey(currRow, currCol)))
                {
                    continue;
                }
                values.Add(current);
                seen.Add(GetKey(currRow, currCol));
                if (currRow - 1 >= 0 && !seen.Contains(GetKey(currRow - 1, currCol)))
                    queue.Enqueue((matrix[currRow - 1][currCol], currRow - 1, currCol));
                if (currCol + 1 < matrix[currRow].Length && !seen.Contains(GetKey(currRow, currCol + 1)))
                    queue.Enqueue((matrix[currRow][currCol + 1], currRow, currCol + 1));
                if (currRow + 1 < matrix.Length && !seen.Contains(GetKey(currRow + 1, currCol)))
                    queue.Enqueue((matrix[currRow + 1][currCol], currRow + 1, currCol));
                if (currCol - 1 >= 0 && !seen.Contains(GetKey(currRow, currCol - 1)))
                    queue.Enqueue((matrix[currRow][currCol - 1], currRow, currCol - 1));
            }
            return values;
        }
    }
}