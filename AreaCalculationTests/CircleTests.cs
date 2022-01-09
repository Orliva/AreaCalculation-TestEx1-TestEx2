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
    public class CircleTests
    {
        [TestMethod()]
        public void CircleValidRadiusCalcTest()
        {
            Circle circle_1000 = new Circle(1000.0, 4);
            Circle circle_0_001 = new Circle(0.001, 10);
            
            Assert.AreEqual<double>(
                Math.Round(Math.PI * Math.Pow(circle_1000.Radius, 2.0), 4),
                circle_1000.CalcArea()
                );
            Assert.AreEqual<double>(
                Math.Round(Math.PI * Math.Pow(circle_0_001.Radius, 2.0), 10),
                circle_0_001.CalcArea()
                );
        }

        [TestMethod()]
        public void CircleUnvalidRadiusCalcTest()
        {
            Circle circle_minus_1000 = new Circle(-1000.0);
            Circle circle_minus_0_001 = new Circle(-0.001);
            Circle circle_minVal = new Circle(double.MinValue);
            Circle circle_Nan = new Circle(double.NaN);
            Circle circle_NegInf = new Circle(double.NegativeInfinity);
            Circle circle_PosInf = new Circle(double.PositiveInfinity);



            Assert.ThrowsException<ArgumentException>(() => circle_minus_1000.CalcArea());
            Assert.ThrowsException<ArgumentException>(() => circle_minus_0_001.CalcArea());
            Assert.ThrowsException<ArgumentException>(() => circle_minVal.CalcArea());
            Assert.ThrowsException<ArgumentException>(() => circle_Nan.CalcArea());
            Assert.ThrowsException<ArgumentException>(() => circle_NegInf.CalcArea());
            Assert.ThrowsException<ArgumentException>(() => circle_PosInf.CalcArea());

        }

        [TestMethod()]
        public void CircleOverflowRadiusCalcTest()
        {
            Circle circle_overflow = new Circle(double.MaxValue);

            Assert.AreEqual<double>(
               Math.Round(Math.PI * Math.Pow(circle_overflow.Radius, 2.0), 4),
               circle_overflow.CalcArea()
               );
        }

    }
}