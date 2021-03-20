using System;
using System.Collections.Generic;

namespace SubsetSumProblem
{
    class Program
    {
        static void Main(string[] args)
        {

            static bool RecSubsetSum(List<int> set, int n, int sum)
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
                return /* 1. */ RecSubsetSum(set, n - 1, sum) || /* 2. */ RecSubsetSum(set, n - 1, sum - set[n - 1]);
            }
            static bool IsSubsetSum(List<int> set, int n, int sum)
            {
                // Remove unnecessary elements 
                for (int i = 0; i < set.Count - 1; i++)
                {
                    if (set[i] > sum)
                    {
                        set.RemoveAt(i);
                        i--;
                    }
                }
                // Then calls recursive method to avoid checking for unnecessary elements everytime 
                return RecSubsetSum(set, n, sum);
            }
            List<int> set = new List<int> { 3, 34, 4, 12, 8, 5, 2 };
            int sum = 9;
            int n = set.Count;
            Console.WriteLine(IsSubsetSum(set, n, sum));
        }
    }
}
