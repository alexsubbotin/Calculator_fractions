using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations
{
    public class Calculations
    {
        public static Fractions Plus(Fractions a, Fractions b)
        {
            return a + b;
        }
        public static Fractions Minus(Fractions a, Fractions b)
        {
            return a - b;
        }
        public static Fractions Multiply(Fractions a, Fractions b)
        {
            return a * b;
        }
        public static Fractions Divide(Fractions a, Fractions b)
        {
            return a / b;
        }
        public static double ToDecimal(Fractions curFrac)
        {
            return (double)(curFrac.Numerator) / curFrac.Denumerator;
        }
        private static int[] GetNumeratorAndDenum(double value)
        {
            int denum = 1, numer = 1;
            int i = 0;
            while (Math.Abs(value* Math.Pow(10, i) - numer) > 0.000000001 && i<9)
            {
                i++;
                numer = (int)(value * Math.Pow(10,i));
            }
            denum = (int)Math.Pow(10, i);
            return new int[]{ numer, denum};
        }
        public static Fractions ToSimpleFraction(double value)
        {
            int[] pairNum_Denum = GetNumeratorAndDenum(value);
            return new Fractions(pairNum_Denum[0], pairNum_Denum[1]);
        }
    }
}
