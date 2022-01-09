using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculation
{
    public class Circle : Figure
    {
        public double Radius { get; }
        public Circle(double radius, uint precisionArea = 4) :
            base(precisionArea: precisionArea)
        {
            Radius = radius;
        }

        public override double CalcArea()
        {
            if (Radius < 0 || double.IsNaN(Radius) || double.IsInfinity(Radius))
                throw new ArgumentException("Radius");
            return Math.Round(Math.PI * Radius * Radius, (int)PrecisionArea);
        }
    }
}
