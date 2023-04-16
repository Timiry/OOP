using oop_2_Matrix;

namespace MatrixTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MatrixMultiplyTest1()
        {
            var first = new double[2, 3] { { 1, 2, 3 }, { 1, 0, 1 } };
            var second = new double[3, 3] { { 3, 4, 5 }, { 6, 0, 2 }, { 7, 1, 8 } };
            var result = MainWindow.multiplyMatrices(first, second);
            var expected = new double[2, 3] { { 36, 7, 33 }, { 10, 5, 13 } };
            Assert.AreEqual(expected.GetLength(0), result.GetLength(0));
            Assert.AreEqual(expected.GetLength(1), result.GetLength(1));
            for (int i = 0; i < expected.GetLength(0); i++)
            {
              for (int j = 0; j < expected.GetLength(1); j++)
                {
                    Assert.AreEqual(expected[i, j], result[i, j]);
                }
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void MatrixMultiplyTest2()
        {
            var first = new double[1, 2]
            {
                { 1, 2 }
            };
            var second = new double[3, 4]
            {
                {1, 1, 1, 1},
                {1, 1, 1, 1},
                {1, 1, 1, 1},
            };
            var result = MainWindow.multiplyMatrices(first, second);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void MatrixMultiplyTest3()
        {
            var first = new double[1, 2]
            {
                { 1, -2 }
            };
            var second = new double[3, 4]
            {
                {1, 1, 1, 1},
                {1, 1, 1, 1},
                {1, 1, 1, 1},
            };
            var result = MainWindow.multiplyMatrices(first, second);
        }
    }
}