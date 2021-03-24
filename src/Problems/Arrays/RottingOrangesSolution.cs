using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Arrays
{
    public class RottingOrangesSolution
    {
        /// <summary>
        /// T: O(n^2) S: O(n)
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static int RottingOranges(int[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0) return 0;
            int minutes = 0, oranges = 0;
            var rottenOrangesQueue = new Queue<(int Row, int Col)>();
            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid[row].Length; col++)
                {
                    // Rotten orange found!
                    if (grid[row][col] == 2)
                    {
                        rottenOrangesQueue.Enqueue((row, col));
                    }
                    else if (grid[row][col] == 1)
                    {
                        oranges++;
                    }
                }
            }

            var visited = new HashSet<string>();
            while (rottenOrangesQueue.Count > 0)
            {
                var currentMinuteQueue = new Queue<(int Row, int Col)>(rottenOrangesQueue);
                while (currentMinuteQueue.Count > 0)
                {
                    var (currRow, currCol) = currentMinuteQueue.Dequeue();
                    grid[currRow][currCol] = 2;
                    visited.Add(GetKey(currRow, currCol));
                    rottenOrangesQueue.Dequeue();
                    if (currRow - 1 >= 0 && grid[currRow - 1][currCol] == 1 && !visited.Contains(GetKey(currRow - 1, currCol)))
                    {
                        oranges--;
                        rottenOrangesQueue.Enqueue((currRow - 1, currCol));
                        visited.Add(GetKey(currRow - 1, currCol));
                    }
                    if (currCol + 1 < grid[currRow].Length && grid[currRow][currCol + 1] == 1 && !visited.Contains(GetKey(currRow, currCol + 1)))
                    {
                        oranges--;
                        rottenOrangesQueue.Enqueue((currRow, currCol + 1));
                        visited.Add(GetKey(currRow, currCol + 1));
                    }
                    if (currRow + 1 < grid.Length && grid[currRow + 1][currCol] == 1 && !visited.Contains(GetKey(currRow + 1, currCol)))
                    {
                        oranges--;
                        rottenOrangesQueue.Enqueue((currRow + 1, currCol));
                        visited.Add(GetKey(currRow + 1, currCol));
                    }
                    if (currCol - 1 >= 0 && grid[currRow][currCol - 1] == 1 && !visited.Contains(GetKey(currRow, currCol - 1)))
                    {
                        oranges--;
                        rottenOrangesQueue.Enqueue((currRow, currCol - 1));
                        visited.Add(GetKey(currRow, currCol - 1));
                    }
                }
                minutes++;
                if (oranges == 0) break;
            }

            return oranges == 0 ? minutes : -1;
        }

        private static bool IsOrange(int[][] grid, int row, int col)
        {
            if (row >= 0 && row < grid.Length && col >= 0 && col < grid[row].Length)
            {
                return grid[row][col] == 1;
            }
            return false;
        }

        private static string GetKey(int row, int col) => $"{row}-{col}";
    }
}