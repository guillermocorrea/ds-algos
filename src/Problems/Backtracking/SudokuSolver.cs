using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Backtracking
{
    public class SudokuSolver
    {
        private const int N = 9;
        public const int EmptyCell = -1;

        public static int[][] Solve(int[][] board)
        {
            var boxes = new Dictionary<int, HashSet<int>>();
            var rows = new Dictionary<int, HashSet<int>>();
            var cols = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < N; i++)
            {
                boxes[i] = new HashSet<int>();
                rows[i] = new HashSet<int>();
                cols[i] = new HashSet<int>();
            }
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < N; col++)
                {
                    var val = board[row][col];
                    if (val != EmptyCell)
                    {
                        var boxId = GetBoxId(row, col);
                        boxes[boxId].Add(val);
                        rows[row].Add(val);
                        cols[col].Add(val);
                    }
                }
            }
            SolveBacktrack(board, boxes, rows, cols, 0, 0);
            return board;
        }

        public static bool SolveBacktrack(int[][] board, Dictionary<int, HashSet<int>> boxes, Dictionary<int, HashSet<int>> rows,
            Dictionary<int, HashSet<int>> cols, int row, int col)
        {
            if (row == N || col == N)
                return true;
            if (board[row][col] == EmptyCell)
            {
                for (int num = 1; num <= 9; num++)
                {
                    board[row][col] = num;
                    var boxId = GetBoxId(row, col);
                    var box = boxes[boxId];
                    var rowSet = rows[row];
                    var colSet = cols[col];
                    if (IsValid(box, rowSet, colSet, board[row][col]))
                    {
                        box.Add(num);
                        rowSet.Add(num);
                        colSet.Add(num);
                        if (col == N - 1)
                        {
                            if (SolveBacktrack(board, boxes, rows, cols, row + 1, 0))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (SolveBacktrack(board, boxes, rows, cols, row, col + 1))
                            {
                                return true;
                            }
                        }
                        // Backtracking Removal
                        box.Remove(num);
                        rowSet.Remove(num);
                        colSet.Remove(num);
                    }
                    board[row][col] = EmptyCell;
                }
            }
            else
            {
                if (col == N - 1)
                {
                    if (SolveBacktrack(board, boxes, rows, cols, row + 1, 0))
                    {
                        return true;
                    }
                }
                else
                {
                    if (SolveBacktrack(board, boxes, rows, cols, row, col + 1))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static int GetBoxId(int row, int col)
        {
            var colVal = Math.Floor(col / 3m);
            var rowVal = Math.Floor(row / 3m) * 3;
            return (int)(colVal + rowVal);
        }

        private static bool IsValid(HashSet<int> box, HashSet<int> row, HashSet<int> col, int val)
        {
            if (box.Contains(val) || row.Contains(val) || col.Contains(val))
                return false;
            return true;
        }
    }
}