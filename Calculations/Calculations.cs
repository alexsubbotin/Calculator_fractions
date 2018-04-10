using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations
{
    class Calculations
    {
        public static int LCM (int a, int b)
        {
            return a * b / GCD(a,b);
        }
        public static int GCD (int a, int b)
        {
            if (b == 0)
                return a;
            return GCD(b, a % b);
        }
        static Fraction Plus(Fraction a, Fraction b)
        {
            return a + b;
        }
        static Fraction Minus(Fraction a, Fraction b)
        {
            return a - b;
        }
        static Fraction Multiply(Fraction a, Fraction b)
        {
            return a * b;
        }
        static Fraction Divide(Fraction a, Fraction b)
        {
            return a / b;
        }
        static double ToDecimal(Fraction curFrac)
        {
            return (double)(curFrac.Numerator) / curFrac.Denumerator;
        }
    }
}
