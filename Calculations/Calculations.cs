using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fractions;

namespace Calculations
{
    public class Calculations
    {
        public static Fraction Plus(Fraction a, Fraction b)
        {
            return a + b;
        }
        public static Fraction Minus(Fraction a, Fraction b)
        {
            return a - b;
        }
        public static Fraction Multiply(Fraction a, Fraction b)
        {
            return a * b;
        }
        public static Fraction Divide(Fraction a, Fraction b)
        {
            return a / b;
        }
        public static double ToDecimal(Fraction curFrac)
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
        public static Fraction ToSimpleFraction(double value)
        {
            int[] pairNum_Denum = GetNumeratorAndDenum(value);
            return new Fraction(pairNum_Denum[0], pairNum_Denum[1]);
        }
    }
}
