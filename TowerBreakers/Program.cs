using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'towerBreakers' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER m
     */

    public static int towerBreakers(int n, int m)
    {
        int P1 = 1;
        int P2 = 2;
        int turns = P1;
        List<int> towers = new List<int>();
        for (int i = 0; i < n; i++)
        {
            towers.Add(m);
        }

        while (towers.Any(m => m > 1))
        {
            towers[(towers.Select((value, index) => new { value, index = index + 1 })
                .Where(pair => pair.value > 1)
                .Select(pair => pair.index)
                .FirstOrDefault() - 1)] = 1;
            turns = (turns == P1) ? P2 : P1;
        }
        return (turns == P1) ? P2 : P1;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int m = Convert.ToInt32(firstMultipleInput[1]);

            int result = Result.towerBreakers(n, m);

            //textWriter.WriteLine(result);
            Console.WriteLine(result);
        }

        //textWriter.Flush();
        //textWriter.Close();
    }
}
