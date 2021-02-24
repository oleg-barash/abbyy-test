using System;
using System.Linq;

namespace TestTask.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = 100;
            var numbers = Generator.GenerateArray(100);
            System.Console.WriteLine($"Skipped numbers: { string.Join("; ", numbers.Skipped) }");
            var originalSum = n * (n + 1) / 2;
            var missingSum = originalSum - numbers.Generated.Sum(num => num);
            System.Console.WriteLine($"Sum of missing numbers: { missingSum }");
            int missingAverage = missingSum / 2;

            decimal sumSmallerHalf = numbers.Generated.Where(s => s <= missingAverage).Sum(s => s);
            decimal sumGreaterHalf = numbers.Generated.Where(s => s > missingAverage).Sum(s => s);
            
            int totalSmallerHalf = missingAverage * (missingAverage + 1) / 2;
            
            System.Console.WriteLine($"First number: {totalSmallerHalf - sumSmallerHalf}"); 
            System.Console.WriteLine($"Second number: {n * (n + 1) / 2 - totalSmallerHalf - sumGreaterHalf}");
            
        }
    }
}