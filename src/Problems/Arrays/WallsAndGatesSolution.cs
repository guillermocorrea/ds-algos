using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Arrays
{
    public class WallsAndGatesSolution
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static int[][] WallsAndGates(int[][] grid)
        {
            if (grid == null || grid.Length == 0) return grid;
            var gatesQueue = new Queue<(int Row, int Col, int Count)>();
            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid.Length; col++)
                {
                    if (grid[row][col] == 0)
                    {
                        gatesQueue.Enqueue((row, col, 0));
                    }
                }
            }

            while (gatesQueue.Count > 0)
            {
                var (row, col, count) = gatesQueue.Dequeue();
                // Top
                if (row - 1 >= 0 && count + 1 < grid[row - 1][col])
                {
                    grid[row - 1][col] = count + 1;
                    gatesQueue.Enqueue((row - 1, col, count + 1));
                }
                // Right
                if (col + 1 < grid[row].Length && count + 1 < grid[row][col + 1])
                {
                    grid[row][col + 1] = count + 1;
                    gatesQueue.Enqueue((row, col + 1, count + 1));
                }
                // Bottom
                if (row + 1 < grid.Length && count + 1 < grid[row + 1][col])
                {
                    grid[row + 1][col] = count + 1;
                    gatesQueue.Enqueue((row + 1, col, count + 1));
                }
                // Left
                if (col - 1 >= 0 && count + 1 < grid[row][col - 1])
                {
                    grid[row][col - 1] = count + 1;
                    gatesQueue.Enqueue((row, col - 1, count + 1));
                }
            }

            return grid;
        }
    }
}