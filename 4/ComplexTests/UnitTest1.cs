using oop_4;
namespace ComplexTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SumComplexTest()
        {
            complex a = new complex(-2, 3);
            complex b = new complex(1, -4);
            var result = a + b;
            var expected = new complex(-1, -1);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DiffComplexTest()
        {
            complex a = new complex(-2, 3);
            complex b = new complex(1, -4);
            var result = a - b;
            var expected = new complex(-3, 7);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MulComplexTest()
        {
            complex a = new complex(-2, 3);
            complex b = new complex(1, -4);
            var result = a * b;
            var expected = new complex(10, 11);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ModComplexTest()
        {
            complex a = new complex(3, 4);
            var result = a.Mod;
            var expected = 5;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToStringComplexTest()
        {
            complex a = new complex(-2, 3);
            var result = a.ToString();
            var expected = "-2 + 3i";
            Assert.AreEqual(expected, result);
        }
    }
}