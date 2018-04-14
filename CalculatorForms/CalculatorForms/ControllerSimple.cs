using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorForms
{
    class ControllerSimple
    {
        // Function to calculate an expression with simple fractions.
        public static string SimpFracCalcAll(string s)
        {
            // Find and calculate brackets.
            s = CalculateBrackets(s);

            // Multiplicate.
            s = SimpMult(s);

            // Addition and subtraction
            s = SimpAddAndSub(s);

            // Creating a fraction object in oerder to get rid of several /.
            Fraction fr = new Fraction();
            if (CreateFraction(s, ref fr))
            {
                if (fr.Denominator != 1 && fr.Denominator != -1)
                    s = fr.ToString();
                else
                {
                    if (fr.Denominator == -1)
                        s = "-" + fr.Numerator.ToString();
                    else
                        s = fr.Numerator.ToString();
                }
            }
            else
                s = "Cannot be calculated!";

            return s;
        }

        // Function to find and calcualte brackets.
        public static string CalculateBrackets(string s)
        {
            // If there are brackets at all.
            if (s.IndexOf('(') != -1)
            {
                // Start of brackets.
                int startIndex = s.IndexOf('(') + 1;

                // End of brackets.
                int endIndex = startIndex;

                // While we haven't seen all the string.
                while (endIndex < s.Length)
                {
                    // If it's new brackets then calculate them and add.
                    if (s[endIndex] == '(')
                    {
                        s = s.Substring(0, endIndex) + SimpFracCalcAll(s.Substring(endIndex, s.Length - endIndex));
                    }

                    // If it's the closing bracket then calcualte everything inside.
                    if (startIndex != s.Length && s[endIndex] == ')')
                    {
                        s = s.Substring(0, startIndex - 1) + SimpFracCalcAll(s.Substring(startIndex, endIndex - startIndex)) +
                            s.Substring(endIndex + 1, s.Length - endIndex - 1);

                        // Again calcualting what's left.
                        s = CalculateBrackets(s);
                    }

                    // If there are no brackets left then leave.
                    if (s.IndexOf('(') == -1)
                        break;
                    else
                        endIndex++;
                }
            }

            return s;
        }

        public static string SimpMult(string s)
        {
            // If there is multiplication.
            while (s.IndexOf('*') != -1)
            {
                // Index of the multiplication sign.
                int multIndex = s.IndexOf('*');

                // The first multiplier.
                string X = "";

                // The second multiplier.
                string Y = "";

                // Index that finds the 1st multiplier.
                int startIndex = multIndex - 1;

                // Getting the 1st multiplier.
                while (startIndex > -1 && (Char.IsDigit(s[startIndex]) ||
                    s[startIndex] == '/' || (startIndex == 0 && s[startIndex] == '-')))
                {
                    X = s[startIndex] + X;
                    startIndex--;
                }

                // Index that finds the 2nd multiplier.
                int endIndex = multIndex + 1;

                // Getting the 2nd multiplier.
                while (endIndex < s.Length && (Char.IsDigit(s[endIndex]) ||
                    s[endIndex] == '/' || (endIndex == multIndex + 1 && s[endIndex] == '-')))
                {
                    Y += s[endIndex];
                    endIndex++;
                }

                // Creating buffers for future fractions.
                Fraction xFrac = new Fraction();
                Fraction yFrac = new Fraction();

                // If both can be fractions then calcualte and add to the original string.
                if (CreateFraction(X, ref xFrac) && CreateFraction(Y, ref yFrac))
                {
                    string result = Calculations.Multiply(xFrac, yFrac).ToString();

                    s = s.Substring(0, startIndex + 1) + result + s.Substring(endIndex, s.Length - endIndex);
                }
                else
                {
                    MessageBox.Show("Input error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    s = "Cannot be calculated!";
                    return s; ;
                }
            }

            return s;
        }

        public static string SimpAddAndSub(string s)
        {
            // Replacing -- with +
            ControllerDecimal.ReplaceDoubleMinuses(s);

            // Calculating addition.
            s = SimpAdd(s);

            // Calculating subtraction.
            s = SimpSub(s);

            return s;
        }

        // Function to calcualte sums.
        public static string SimpAdd(string s)
        {
            // If there is addition.
            while (s.IndexOf('+') != -1)
            {
                // Index of the addition sign.
                int multIndex = s.IndexOf('+');

                // The first summand.
                string X = "";

                // The second summand.
                string Y = "";

                // Index that finds the 1st summand.
                int startIndex = multIndex - 1;

                // Getting the 1st summand.
                while (startIndex > -1 && (Char.IsDigit(s[startIndex]) ||
                    s[startIndex] == '/' || (startIndex == 0 && s[startIndex] == '-')))
                {
                    X = s[startIndex] + X;
                    startIndex--;
                }

                // Index that finds the 2nd summand.
                int endIndex = multIndex + 1;

                // Getting the 2nd summand.
                while (endIndex < s.Length && (Char.IsDigit(s[endIndex]) ||
                    s[endIndex] == '/' || (endIndex == multIndex + 1 && s[endIndex] == '-')))
                {
                    Y += s[endIndex];
                    endIndex++;
                }

                // Creating buffers for future fractions.
                Fraction xFrac = new Fraction();
                Fraction yFrac = new Fraction();

                // If both can be fractions then calcualte and add to the original string.
                if (CreateFraction(X, ref xFrac) && CreateFraction(Y, ref yFrac))
                {
                    string result = Calculations.Plus(xFrac, yFrac).ToString();

                    s = s.Substring(0, startIndex + 1) + result + s.Substring(endIndex, s.Length - endIndex);
                }
                else
                {
                    MessageBox.Show("Input error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    s = "Cannot be calculated!";
                    return s;
                }
            }

            return s;
        }

        public static string SimpSub(string s)
        {
            // If there is subtraction.
            while (s.IndexOf('-') != -1)
            {
                // Index of the multiplication sign.
                int multIndex = s.IndexOf('-');

                // The minuend.
                string X = "";

                // The subtrahend.
                string Y = "";

                // Index that finds the minuend.
                int startIndex = multIndex - 1;

                // Getting the minuend.
                while (startIndex > -1 && (Char.IsDigit(s[startIndex]) ||
                    s[startIndex] == '/' || (startIndex == 0 && s[startIndex] == '-')))
                {
                    X = s[startIndex] + X;
                    startIndex--;
                }

                // Index that finds the subtrahend.
                int endIndex = multIndex + 1;

                // Getting the subtrahend.
                while (endIndex < s.Length && (Char.IsDigit(s[endIndex]) ||
                    s[endIndex] == '/' || (endIndex == multIndex + 1 && s[endIndex] == '-')))
                {
                    Y += s[endIndex];
                    endIndex++;
                }

                // Creating buffers for future fractions.
                Fraction xFrac = new Fraction();
                Fraction yFrac = new Fraction();

                if (X != "" && Y != "")
                {
                    // If both can be fractions then calcualte and add to the original string.
                    if (CreateFraction(X, ref xFrac) && CreateFraction(Y, ref yFrac))
                    {
                        string result = Calculations.Minus(xFrac, yFrac).ToString();

                        s = s.Substring(0, startIndex + 1) + result + s.Substring(endIndex, s.Length - endIndex);
                    }
                    else
                    {
                        MessageBox.Show("Input error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        s = "Cannot be calculated!";
                        return s;
                    }
                }
                else
                {
                    if (X == "")
                    {
                        if (CreateFraction(Y, ref yFrac))
                            s = yFrac.ToString();
                        else
                        {
                            MessageBox.Show("Input error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            s = "Cannot be calculated!";
                            return s;
                        }
                    }
                    else
                        s = X;
                }
            }

            return s;
        }

        // Function to create a fraction object.
        public static bool CreateFraction(string s, ref Fraction fraction)
        {
            // If there are / symbols.
            if (s.IndexOf('/') != -1)
            {
                // Getting the array of symbols.
                string[] frac = s.Split('/');

                int buf;

                // Future numerator.
                int numer = 0;
                // Future denominator.
                int denom = 1;

                // Checking all the symbols.
                for (int i = 0; i < frac.Length; i++)
                {
                    // If it's an integer then add it.
                    if (Int32.TryParse(frac[i], out buf))
                    {
                        // The 1st integer is the numerator.
                        if (i == 0)
                            numer = Convert.ToInt32(frac[i]);
                        // The multiplication of the rest is the denominator.
                        else
                            denom *= Convert.ToInt32(frac[i]);
                    }
                    // If it's not an integer then can't create a fracton.
                    else
                        return false;
                }

                try
                {
                    fraction = new Fraction(numer, denom);
                }
                catch
                {
                    return false;
                }

                return true;
            }
            else
            {
                fraction = new Fraction(Convert.ToInt32(s), 1);
                return true;
            }
        }
    }
}
