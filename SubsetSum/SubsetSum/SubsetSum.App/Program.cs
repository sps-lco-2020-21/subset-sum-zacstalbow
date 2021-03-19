using SubsetSum.Lib;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SubsetSum.App
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> s = new List<int> { 1, 3, 4, 5, 7 };
            IList<int> ss = SubsetGenerator.SubsetSum(s, 12);
            
            Debug.Assert(ss != null);
            Debug.Assert(ss.Sum() == 12);
            
        }
    }


}
