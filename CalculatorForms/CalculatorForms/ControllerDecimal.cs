using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorForms
{
    // Stores needed functions.
    class ControllerDecimal
    {
        // Function to calculate mathematical expressions with decimal fractions.
        public static string DecFracCalcAll(string s)
        {
            // Calculate brackets.
            s = CalculateBrackets(s);

            // Calcualte multiplication and division.
            s = DecFracMultAndDiv(s);

            // Calcualte addition and substraction
            s = DecFracAddAndSub(s);
            return s;
        }

        // Function to calculate everything in brackets.
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
                while(endIndex < s.Length)
                {
                    // If it's new brackets then calculate them and add.
                    if(s[endIndex] == '(')
                    {
                        s = s.Substring(0, endIndex) + DecFracCalcAll(s.Substring(endIndex, s.Length - endIndex));
                    }

                    // If it's the closing bracket then calcualte everything inside.
                    if (startIndex != s.Length && s[endIndex] == ')')
                    {
                        s = s.Substring(0, startIndex - 1) + DecFracCalcAll(s.Substring(startIndex, endIndex - startIndex)) +
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

        // Function to calcualte multiplication and division.
        public static string DecFracMultAndDiv(string s)
        {
            // Calcualte multiplication.
            s = DecMult(s);

            // Calculate division.
            s = DecDiv(s);

            return s;
        }

        // Calcualting multiplication.
        public static string DecMult(string s)
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
                while (startIndex > -1 && (Char.IsDigit(s[startIndex]) || s[startIndex] == ',' ||
                    (startIndex == 0 && s[startIndex] == '-')))
                {
                    X = s[startIndex] + X;
                    startIndex--;
                }

                // Index that finds the 2nd multiplier.
                int endIndex = multIndex + 1;

                // Getting the 2nd multiplier.
                while (endIndex < s.Length && (Char.IsDigit(s[endIndex]) || s[endIndex] == ',' ||
                    (endIndex == multIndex + 1 && s[endIndex] == '-')))
                {
                    Y += s[endIndex];
                    endIndex++;
                }

                string result = "";
                if (CheckDouble(X) && CheckDouble(Y))
                {
                    // Getting the result.
                    result = (Convert.ToDouble(X) * Convert.ToDouble(Y)).ToString();

                    // Inserting the result in the original string.
                    s = s.Substring(0, startIndex + 1) + result + s.Substring(endIndex, s.Length - endIndex);
                }
                else
                {
                    MessageBox.Show("Input error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }

            return s;
        }

        // Calculating division.
        public static string DecDiv(string s)
        {
            // If there is division.
            while (s.IndexOf('/') != -1)
            {
                // Index of the division sign.
                int multIndex = s.IndexOf('/');

                // The divisor.
                string X = "";

                // The divident.
                string Y = "";

                // Index that finds the divisor.
                int startIndex = multIndex - 1;

                // Getting the divisor.
                while (startIndex > -1 && (Char.IsDigit(s[startIndex]) || s[startIndex] == ',' ||
                    (startIndex == 0 && s[startIndex] == '-')))
                {
                    X = s[startIndex] + X;
                    startIndex--;
                }

                // Index that finds the divident.
                int endIndex = multIndex + 1;

                // Getting the divident.
                while (endIndex < s.Length && (Char.IsDigit(s[endIndex]) || s[endIndex] == ',' ||
                    (endIndex == multIndex + 1 && s[endIndex] == '-')))
                {
                    Y += s[endIndex];
                    endIndex++;
                }

                if (CheckDouble(X) && CheckDouble(Y))
                {
                    // Getting the result.
                    string result = (Convert.ToDouble(X) / Convert.ToDouble(Y)).ToString();

                    // Inserting the result in the original string.
                    s = s.Substring(0, startIndex + 1) + result + s.Substring(endIndex, s.Length - endIndex);
                }
                else
                {
                    MessageBox.Show("Input error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }

            return s;
        }

        // Function to calculate addition and substraction.
        public static string DecFracAddAndSub(string s)
        {
            // Replacing -- with +.
            s = ReplaceDoubleMinuses(s);

            // Calcualting addition.
            s = DecAddition(s);

            // Calculating subtraction.
            s = DecSubtration(s);

            return s;
        }

        // Calculating addition.
        public static string DecAddition(string s)
        {
            // If there is addition.
            while (s.IndexOf('+') != -1)
            {
                // Index of the addition sign.
                int addIndex = s.IndexOf('+');

                // The first summand.
                string X = "";

                // The second summand.
                string Y = "";

                // Index that finds the 1st summand.
                int startIndex = addIndex - 1;

                // Getting the 1st summand.
                while (startIndex > -1 && (Char.IsDigit(s[startIndex]) || s[startIndex] == ',' ||
                    (startIndex == 0 && s[startIndex] == '-')))
                {
                    X = s[startIndex] + X;
                    startIndex--;
                }

                // Index that finds the 2nd summand.
                int endIndex = addIndex + 1;

                // Getting the 2nd summand.
                while (endIndex < s.Length && (Char.IsDigit(s[endIndex]) || s[endIndex] == ',' ||
                    (endIndex == addIndex + 1 && s[endIndex] == '-')))
                {
                    Y += s[endIndex];
                    endIndex++;
                }

                if (CheckDouble(X) && CheckDouble(Y))
                {
                    // Getting the result.
                    string result = (Convert.ToDouble(X) + Convert.ToDouble(Y)).ToString();

                    // Inserting the result in the original string.
                    s = s.Substring(0, startIndex + 1) + result + s.Substring(endIndex, s.Length - endIndex);
                }
                else
                {
                    MessageBox.Show("Input error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }

            return s;
        }

        // Calculating subtraction.
        public static string DecSubtration(string s)
        {
            // If there is subtraction.
            while (s.LastIndexOf('-') != -1)
            {
                // Index of the subtraction sign.
                int subsIndex = s.LastIndexOf('-');

                // The minuend.
                string X = "";

                // The subtrahend.
                string Y = "";

                // Index that finds the minuend.
                int startIndex = subsIndex - 1;

                // Getting the minuend.
                while (startIndex > -1 && (Char.IsDigit(s[startIndex]) || s[startIndex] == ',' ||
                    (startIndex == 0 && s[startIndex] == '-')))
                {
                    X = s[startIndex] + X;
                    startIndex--;
                }

                // Index that finds the subtrahend.
                int endIndex = subsIndex + 1;

                // Getting the subtrahend.
                while (endIndex < s.Length && (Char.IsDigit(s[endIndex]) || s[endIndex] == ',' ||
                    (endIndex == subsIndex + 1 && s[endIndex] == '-')))
                {
                    Y += s[endIndex];
                    endIndex++;
                }

                string result = "";

                // If the subtrahend is not empty
                if (X != "" && Y != "")
                {
                    if (CheckDouble(X) && CheckDouble(Y))
                    {
                        // Getting the result.
                        result = (Convert.ToDouble(X) - Convert.ToDouble(Y)).ToString();

                        // Inserting the result in the original string.
                        s = s.Substring(0, startIndex + 1) + result + s.Substring(endIndex, s.Length - endIndex);
                    }
                    else
                    {
                        MessageBox.Show("Input error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
                else
                {
                    if (X == "")
                        if(CheckDouble(Y))
                        s = (0 - Convert.ToDouble(Y)).ToString();
                        else
                        {
                            MessageBox.Show("Input error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    else
                        s = X;

                    return s;
                }
            }

            return s;
        }

        // Replacing every -- with +.
        public static string ReplaceDoubleMinuses(string s)
        {
            StringBuilder sb = new StringBuilder(s);

            sb.Replace("--", "+");

            s = sb.ToString();

            return s;
        }

        // Function to check the format.
        public static bool CheckDouble(string obj)
        {
            double buf;
            return Double.TryParse(obj, out buf);
        }
    }
}
