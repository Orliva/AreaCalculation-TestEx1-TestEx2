using Microsoft.VisualStudio.TestTools.UnitTesting;
using AreaCalculation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculation.Tests
{
    [TestClass()]
    public class TriangleTests
    {

        [TestMethod()]
        public void RightTriangleCalcTest()
        {
            Triangle triangle_3_4_5 = new Triangle(3, 4, 5, precisionArea: 4);
            Triangle triangle_6_8_10 = new Triangle(10, 8, 6, precisionArea: 3);
            Triangle triangle_5_12_13 = new Triangle(12, 13, 5, precisionArea: 10);


            Assert.AreEqual<double>(
                Math.Round(0.5 * 3 * 4, 4),
                triangle_3_4_5.CalcArea()
                );
            Assert.AreEqual<double>(
                Math.Round(0.5 * 6 * 8, 3),
                triangle_6_8_10.CalcArea()
                );
            Assert.AreEqual<double>(
                Math.Round(0.5 * 5 * 12, 3),
                triangle_5_12_13.CalcArea()
                );
        }

        [TestMethod()]
        public void CustomTriangleValidCalcTest()
        {
            Triangle triangle_1 = new Triangle(90, 50, 50, precisionArea: 3);
            Triangle triangle_2 = new Triangle(10, 10, 10, precisionArea: 4);
            Triangle triangle_3 = new Triangle(10, 1, 10.5, precisionArea: 10);

            double p1 = GetHalfPastPerimetr(90, 50, 50);
            double p2 = GetHalfPastPerimetr(10, 10, 10);
            double p3 = GetHalfPastPerimetr(10, 1, 10.5);


            double exp1 = Math.Sqrt(p1 * (p1 - 90.0) * (p1 - 50.0) * (p1 - 50.0));
            Assert.AreEqual<double>(
                Math.Round(exp1, 3),
                triangle_1.CalcArea()
                );

            double exp2 = Math.Sqrt(p2 * (p2 - 10) * (p2 - 10) * (p2 - 10));
            Assert.AreEqual<double>(
                Math.Round(exp2, 4),
                triangle_2.CalcArea()
                );

            double exp3 = Math.Sqrt(p3 * (p3 - 10) * (p3 - 1) * (p3 - 10.5));
            Assert.AreEqual<double>(
                Math.Round(exp3, 10),
                triangle_3.CalcArea()
                );

        }

        private double GetHalfPastPerimetr(double s1, double s2, double s3)
        {
            return (s1 + s2 + s3) / 2.0;
        }

        [TestMethod()]
        public void HypotenuseTest()
        {
            Triangle triangle1 = new Triangle(3, 4, 5);
            Triangle triangle2 = new Triangle(4, 5, 3);
            Triangle triangle3 = new Triangle(5, 4, 3);

            Triangle triangle4 = new Triangle(10, 10, 10);
            Triangle triangle5 = new Triangle(90, 50, 50);
            Triangle triangle6 = new Triangle(50, 90, 50);
            Triangle triangle7 = new Triangle(50, 50, 90);



            Assert.AreEqual(5.0, triangle1.Hypotenuse);
            Assert.AreEqual(5.0, triangle2.Hypotenuse);
            Assert.AreEqual(5.0, triangle3.Hypotenuse);
            Assert.AreEqual(10.0, triangle4.Hypotenuse);
            Assert.AreEqual(90.0, triangle5.Hypotenuse);
            Assert.AreEqual(90.0, triangle6.Hypotenuse);
            Assert.AreEqual(90.0, triangle7.Hypotenuse);
        }

        [TestMethod()]
        public void UnvalidTriangleTest()
        {
            Assert.ThrowsException<ArgumentException>(() => new Triangle(1, 2, 3));
            Assert.ThrowsException<ArgumentException>(() => new Triangle(-3, 4, 5));
            Assert.ThrowsException<ArgumentException>(() => new Triangle(3, -4, 5));
            Assert.ThrowsException<ArgumentException>(() => new Triangle(3, 4, -5));
            Assert.ThrowsException<ArgumentException>(() => new Triangle(-3, -4, -5));
            Assert.ThrowsException<ArgumentException>(() => new Triangle(2, 1, 3));
            Assert.ThrowsException<ArgumentException>(() => new Triangle(2, 3, 1));
            Assert.ThrowsException<ArgumentException>(() => new Triangle(0, 0, 0));
        }
    }
}