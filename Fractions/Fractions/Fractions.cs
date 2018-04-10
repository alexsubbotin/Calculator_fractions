using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{
    public class Fraction
    {
        private int numerator;
        public int Numerator
        {
            get
            {
                return numerator;
            }
            set
            {
                numerator = value;
            }
        }
        private int denominator;
        public int Denominator
        {
            get
            {
                return denominator;
            }
            set
            {
                if (value == 0)
                {
                    return;
                }
                denominator = value;
            }
        }
        public Fraction()
        {
            Numerator = -1;
            Denominator = -1;
        }
        public Fraction(int _num, int _den)
        {
            Numerator = _num;
            Denominator = _den;
        }
        private Fraction Simplify(Fraction a)
        {
            int div = GCD(a.Numerator, a.Denominator);
            a.Numerator /= div;
            a.Denominator /= div;
        }
        public static Fraction operator +(Fraction a, Fraction b)
        {
            if (a.Denominator == b.Denominator)
            {
                Fraction newFract = new Fraction(a.Numerator + b.Numerator, a.Denominator);
                return newFract.Simplify(newFract);
            }
            Fraction tmp = new Fraction();
            int newDen = LCM(a.Denominator, b.Denominator);
            tmp.Denominator = newDen;
            tmp.Numerator = a.Numerator * (newDen / a.Denominator) + b.Numerator * (newDen / b.Denominator);
            return tmp.Simplify(tmp);
        }
    }
}
