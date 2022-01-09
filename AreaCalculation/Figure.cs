using System;

namespace AreaCalculation
{
    public abstract class Figure
    {
        public uint PrecisionArea { get; }
        protected Figure(uint precisionArea = 4)
        {
            PrecisionArea = precisionArea;
        }

        public abstract double CalcArea();
    }
}
