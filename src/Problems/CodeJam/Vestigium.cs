using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        var input = Console.ReadLine();
        var numCases = int.Parse(input);

        for (int i = 1; i <= numCases; i++)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new int[n][];
            for (int j = 0; j < n; j++)
            {
                matrix[j] = Console.ReadLine().Split(' ').Select(num => int.Parse(num)).ToArray();
            }
        }
    }
}