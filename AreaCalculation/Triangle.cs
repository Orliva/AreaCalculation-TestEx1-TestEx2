using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculation
{
    public class Triangle : Figure
    {
        public double Katet1 { get; private set; }
        public double Katet2 { get; private set; }
        public double Hypotenuse { get; private set; }

        public Triangle(double s1, double s2, double s3, uint precisionArea = 8) :
            base(precisionArea: precisionArea)
        {
            if (!IsValidSide(in s1, in s2, in s3))
                throw new ArgumentException("Unvalid side length");
            SetSide(in s1, in s2, in s3);
        }

        private bool IsValidSide(in double s1, in double s2, in double s3)
        {
            if (s1 > 0 &&
                s2 > 0 &&
                s3 > 0 &&
                s1 + s2 > s3 &&
                s2 + s3 > s1 &&
                s3 + s1 > s2
                )
                return true;
            return false;
        }

        private void SetSide(in double s1, in double s2, in double s3)
        {
            if (s1 > s2)
            {
                if (s1 > s3)
                {
                    Hypotenuse = s1;
                    Katet1 = s2;
                    Katet2 = s3;
                }
                else
                {
                    Hypotenuse = s3;
                    Katet1 = s2;
                    Katet2 = s1;
                }
            }
            else
            {
                if (s2 > s3)
                {
                    Hypotenuse = s2;
                    Katet1 = s1;
                    Katet2 = s3;
                }
                else
                {
                    Hypotenuse = s3;
                    Katet1 = s2;
                    Katet2 = s1;
                }
            }
        }

        /// <summary>
        /// Рассчет площади произвольного треугольника
        /// </summary>
        /// <returns>Площадь</returns>
        public override double CalcArea()
        {
            //Если треугольник - прямоугольный, то расчитываем прощадь как половину произведения катетов.
            if (IsRightTriangle())
                return Math.Round(0.5 * Katet1 * Katet2, (int)PrecisionArea);
            //Иначе рассчитываем по формуле Герона
            return Math.Round(GeronFormula(), (int)PrecisionArea);
        }

        /// <summary>
        /// Проверка, является ли треугольник прямоугольным.
        /// Если треугольник прямоугольный, гипотенуза - самая длинная сторона =>
        /// по теореме косинусов a^2 = b^2 + c^2 + a*b*c*cos(alfa) проверяем наличие прямого угла.
        /// Косинус угла в 90 градусов равен 0 => проверяем выражение a^2 = b^2 + c^2.
        /// </summary>
        /// <returns></returns>
        private bool IsRightTriangle()
        {
            if (Math.Round(Hypotenuse * Hypotenuse, (int)PrecisionArea) == Math.Round((Katet1 * Katet1) + (Katet2 * Katet2),
                (int)PrecisionArea))
                return true;
            return false;
        }

        /// <summary>
        /// Расчет площади по формуле Герона: sqrt(p(p-a)(p-b)(p-c)),
        /// где p - полупериметр
        /// </summary>
        /// <returns>Площадь</returns>
        private double GeronFormula()
        {
            double halfPastPerimetr = (Katet1 + Katet2 + Hypotenuse) / 2.0;

            return Math.Sqrt(
                 halfPastPerimetr *
                (halfPastPerimetr - Katet1) *
                (halfPastPerimetr - Katet2) *
                (halfPastPerimetr - Hypotenuse)
                );
        }
    }
}
