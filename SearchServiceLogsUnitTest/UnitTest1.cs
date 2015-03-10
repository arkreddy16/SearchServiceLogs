using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchServiceLogs;

namespace SearchServiceLogsUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(true, true);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(true, false);
        }
        [TestMethod]
        public void TestMethod3()
        {
            object obj = new object();
            Assert.AreSame(obj, obj);
        }
    }
}
