using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindSLib;



namespace FindSquareUnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Radius3_returned28()
        {
            double R = 3;
            double Expected = 28.260000944137573;

            IGetSquare TestCircle = new Сircle(R);

            Assert.AreEqual(Expected, TestCircle.GetSquare());
        }
        [TestMethod]
        public void S_SideA3_SideB3_SideC6_returned0()
        {
            double A = 3;
            double B = 3;
            double C = 6;
            double Expected = 0;
            IGetSquare TestTringle = new Triangle(A, B, C);
            Assert.AreEqual(Expected, TestTringle.GetSquare());
        }
        [TestMethod]
        public void ItsRightTriangleTest()
        {
            double A = 5;
            double B = 12;
            double C = Math.Sqrt((Math.Pow(A, 2)) + (Math.Pow(B, 2)));
            bool Expected = true;

            Triangle TestTringle = new Triangle(A, B, C);
            Assert.AreEqual(Expected, TestTringle.RightTriangle);
        }
    }
}
