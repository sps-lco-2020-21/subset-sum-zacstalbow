using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubsetSum.Lib;

namespace SubsetSum.Tests
{
    [TestClass]
    public class GeneratorTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            IList<int> s = new List<int> { 1, 3, 4, 5, 7 };
            IList<int> ss = SubsetGenerator.SubsetSum(s, 12);

            Assert.IsNotNull(ss);
            Assert.AreEqual(12, ss.Sum());

        }
    }
}
