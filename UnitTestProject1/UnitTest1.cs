using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FindXYZK()
        {
            var date = DateTime.Now;
            var result = Program.Process("Request for X_Y_Z_K", date);
            Assert.AreEqual($"Дата записи: {date:d}, Время записи: {date:t}, X, Y, Z, K", result);
        }

        [TestMethod]
        public void FindNothing()
        {
            var date = DateTime.Now;
            var result = Program.Process("ABracadabra", date);
            Assert.AreEqual(null, result);
        }
    }
}
