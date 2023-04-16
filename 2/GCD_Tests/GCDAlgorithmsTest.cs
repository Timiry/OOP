using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using oop_2;

namespace GCD_Tests
{
    [TestClass]
    public class GCDAlgorithmsTest
    {
        [TestMethod]
        public void EuclidTest_2()
        {
            var result = GCDAlgorithms.FindGCDEuclid(2806, 345);
            Assert.AreEqual(23, result);
        }

        [TestMethod]
        public void EuclidTest_3()
        {
            var result = GCDAlgorithms.FindGCDEuclid(7396, 1978, 1204);
            Assert.AreEqual(86, result);
        }

        [TestMethod]
        public void EuclidTest_4()
        {
            var result = GCDAlgorithms.FindGCDEuclid(7396, 1978, 1204, 430);
            Assert.AreEqual(86, result);
        }

        [TestMethod]
        public void EuclidTest_5()
        {
            var result = GCDAlgorithms.FindGCDEuclid(7396, 1978, 1204, 430, 258);
            Assert.AreEqual(86, result);
        }

        [TestMethod]
        public void EuclidTest_5_1()
        {
            int[] values = {7396, 1978, 1204, 430, 258};
            var result = GCDAlgorithms.FindGCDEuclid(values);
            Assert.AreEqual(86, result);
        }

        [TestMethod]
        public void SteinTest_2()
        {
            var result = GCDAlgorithms.FindGCDStein(298467352, 569484);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void SteinTest_5()
        {
            int[] values = { 7396, 1978, 1204, 430, 258 };
            var result = GCDAlgorithms.FindGCDStein(values);
            Assert.AreEqual(86, result);
        }
    }
}