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
    public class FigureTests
    {
        [TestMethod()]
        public void CalcAreaTest()
        {
            Figure figure1 = new Triangle(3, 4, 5);
            Figure figure2 = new Circle(1, precisionArea: 4);

            Assert.AreEqual(6.0, figure1.CalcArea());
            Assert.AreEqual(Math.Round(Math.PI, 4), figure2.CalcArea());
        }
    }
}