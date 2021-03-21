using System;
using System.Collections.Generic;

namespace SubsetSumProblem
{
    class Program
    {
        static void Main(string[] args)
        {

            static bool RecSubsetSum(List<int> input, int n, int sum)
            {
                // Base Cases 
                if (sum == 0)
                {
                    return true;
                }
                if (n == 0) // The set is empty - sum != 0 will have already been checked above
                {
                    return false;
                }
                // 1 - Assuming set[n - 1] is not part of subset that sums to the sum
                // 2 - Assuming that it is
                return /* 1. */ RecSubsetSum(input, n - 1, sum) || /* 2. */ RecSubsetSum(input, n - 1, sum - input[n - 1]);
            }
            static bool IsSubsetSum(List<int> input, int n, int sum)
            {
                // Remove unnecessary elements 
                for (int i = 0; i < input.Count - 1; i++)
                {
                    if (input[i] > sum)
                    {
                        input.RemoveAt(i);
                        i--;
                    }
                }
                // Then calls recursive method to avoid checking for unnecessary elements everytime 
                return RecSubsetSum(input, n, sum);
            }
            List<int> input = new List<int> { 8, 22, 4, 1, 19, 36, 6 };
            int sum = 34;
            int n = input.Count;
            Console.WriteLine(IsSubsetSum(input, n, sum));
        }
    }
}
