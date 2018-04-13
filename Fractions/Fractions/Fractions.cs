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
            Simplify();
        }
        public static Fraction operator +(Fraction a, Fraction b)
        {
            if (a.Denominator == b.Denominator)
            {
                Fraction newFract = new Fraction(a.Numerator + b.Numerator, a.Denominator);
                newFract.Simplify();
                return newFract;
            }
            Fraction tmp = new Fraction();
            int newDen = LCM(a.Denominator, b.Denominator);
            tmp.Denominator = newDen;
            tmp.Numerator = a.Numerator * (newDen / a.Denominator) + b.Numerator * (newDen / b.Denominator);
            tmp.Simplify();
            return tmp;
        }
        public static Fraction operator -(Fraction a, Fraction b)
        {
            if (a.Denominator == b.Denominator)
            {
                Fraction newFract = new Fraction(a.Numerator - b.Numerator, a.Denominator);
                newFract.Simplify();
                return newFract;
            }
            Fraction tmp = new Fraction();
            int newDen = LCM(a.Denominator, b.Denominator);
            tmp.Denominator = newDen;
            tmp.Numerator = a.Numerator * (newDen / a.Denominator) - b.Numerator * (newDen / b.Denominator);
            tmp.Simplify();
            return tmp;
        }
        public static Fraction operator *(Fraction a, Fraction b)
        {
            Fraction newFract = new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
            newFract.Simplify();
            return newFract;
        }
        public static Fraction operator /(Fraction a, Fraction b)
        {
            b = new Fraction(b.Denominator, b.Numerator);
            return a * b;
        }
        private void Simplify()
        {
            int div = GCD(Math.Abs(Numerator), Math.Abs(Denominator));
            Numerator /= div;
            Denominator /= div;
        }
        private static int GCD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            return GCD(b, a % b);
        }
        private static int LCM(int a, int b)
        {
            return a * b / GCD(a, b);
        }
        public override string ToString()
        {
            return Numerator + "/" + Denominator;
        }
    }
}
