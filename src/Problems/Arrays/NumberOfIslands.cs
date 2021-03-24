using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Arrays
{
    public class NumberOfIslands
    {
        public static int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0]?.Length == 0) return 0;
            int count = 0;
            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid[row].Length; col++)
                {
                    if (grid[row][col] == '1')
                    {
                        count++;
                        var queue = new Queue<(int row, int col)>();
                        queue.Enqueue((row, col));
                        while (queue.Count > 0)
                        {
                            var (currRow, currCol) = queue.Dequeue();
                            grid[currRow][currCol] = '0';
                            if (currCol - 1 > 0 && grid[currRow][currCol - 1] == '1')
                                queue.Enqueue((currRow, currCol - 1));
                            if (currRow + 1 < grid.Length && grid[currRow + 1][currCol] == '1')
                                queue.Enqueue((currRow + 1, currCol));
                            if (currCol + 1 < grid[currRow].Length && grid[currRow][currCol + 1] == '1')
                                queue.Enqueue((currRow, currCol + 1));
                        }
                    }
                }
            }
            return count;
        }

        private static string GetKey(int row, int col) => $"{row}-{col}";
    }
}