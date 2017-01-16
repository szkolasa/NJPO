using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJPO.UnitTest.QuadraticEquation
{
    public struct QuadraticEquation
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public QuadraticEquation(double a = 0, double b = 0, double c = 0)
        {
            A = a;
            B = b;
            C = c;
        }

        public double Delta()
        {
            return Math.Pow(B, 2) - (4 * A * C);
        }

        public void ZerosOfFunction(out double? x1, out double? x2)
        {
            x1 = x2 = null;

            if (A == 0)
            {
                throw new DivideByZeroException();
            }

            var delta = Delta();

            if (delta < 0)
            {
                return;
            }
            else if (delta == 0)
            {
                x1 = -B / (2 * A);
                return;
            }
            else
            {
                x1 = (-B + Math.Sqrt(delta)) / (2 * A);
                x2 = (-B - Math.Sqrt(delta)) / (2 * A);
                return;
            }
        }
    }
}
