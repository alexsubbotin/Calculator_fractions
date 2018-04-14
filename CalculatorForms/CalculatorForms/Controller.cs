using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorForms
{
    // Stores needed functions.
    class Controller
    {
        // Function to calculate mathematical expresions with decimal fractions.
        public static string DecFracCalcAll(string s)
        {
            // Calculate brackets.
            s = CalculateBrackets(s);

            // Calcualte multiplication and division.
            s = DecFracMultAndDiv(s);

            // Calcualte addition and substraction
            s = DecFracAddAndSubs(s);
            return s;
        }

        // Function to calculate everything in brackets.
        public static string CalculateBrackets(string s)
        {
            // If there are brackets at all.
            if (s.IndexOf('(') != -1)
            {
                // Start of brackets.
                int startIndex = s.IndexOf('(');

                // End of brackets.
                int endIndex = s.LastIndexOf(')');

                // String in brackets.
                string newS = "";

                // Getting the string in brackets.
                newS = s.Substring(startIndex + 1, endIndex - startIndex - 1);

                // Calculate it.
                newS = DecFracCalcAll(newS);

                // Insert in the original string.
                if (endIndex != s.Length - 1)
                    s = s.Substring(0, startIndex) + newS + s.Substring(endIndex + 1, s.Length - endIndex + 1);
                else
                    s = s.Substring(0, startIndex) + newS;
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

                // Getting the result.
                string result = (Convert.ToDouble(X) * Convert.ToDouble(Y)).ToString();

                // Inserting the result in the original string.
                s = s.Substring(0, startIndex + 1) + result + s.Substring(endIndex, s.Length - endIndex);
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
                while (startIndex > -1 && (Char.IsDigit(s[startIndex]) || s[startIndex] == ','))
                {
                    X = s[startIndex] + X;
                    startIndex--;
                }

                // Index that finds the divident.
                int endIndex = multIndex + 1;

                // Getting the divident.
                while (endIndex < s.Length && (Char.IsDigit(s[endIndex]) || s[endIndex] == ','))
                {
                    Y += s[endIndex];
                    endIndex++;
                }

                // Getting the result.
                string result = (Convert.ToDouble(X) / Convert.ToDouble(Y)).ToString();

                // Inserting the result in the original string.
                s = s.Substring(0, startIndex + 1) + result + s.Substring(endIndex, s.Length - endIndex);
            }

            return s;
        }

        // Function to calculate addition and substraction.
        public static string DecFracAddAndSubs(string s)
        {
            // Calculating substraction.
            s = DecSubstration(s);

            // Calcualting addition.
            s = DecAddition(s);

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

                // Getting the result.
                string result = (Convert.ToDouble(X) + Convert.ToDouble(Y)).ToString();

                // Inserting the result in the original string.
                s = s.Substring(0, startIndex + 1) + result + s.Substring(endIndex, s.Length - endIndex);
            }

            return s;
        }

        // Calculating substraction.
        public static string DecSubstration(string s)
        {
            // If it's the first in the string (negative value).
            if (s.IndexOf('-') == 0)
            {
                // Replacing (-a) with (a - 2*a).
                //s = DecReplaceNegative(s);
            }

            // If there is substraction.
            while (s.IndexOf('-') > 0)
            {
                // Index of the substraction sign.
                int addIndex = s.IndexOf('-');

                // The minuend.
                string X = "";

                // The subtrahend.
                string Y = "";

                // Index that finds the minuend.
                int startIndex = addIndex - 1;

                // Getting the minuend.
                while (startIndex > -1 && (Char.IsDigit(s[startIndex]) || s[startIndex] == ','))
                {
                    X = s[startIndex] + X;
                    startIndex--;
                }

                // Index that finds the subtrahend.
                int endIndex = addIndex + 1;

                // Getting the subtrahendd.
                while (endIndex < s.Length && (Char.IsDigit(s[endIndex]) || s[endIndex] == ','))
                {
                    Y += s[endIndex];
                    endIndex++;
                }

                // Getting the result.
                string result = (Convert.ToDouble(X) - Convert.ToDouble(Y)).ToString();

                // Inserting the result in the original string.
                s = s.Substring(0, startIndex + 1) + result + s.Substring(endIndex, s.Length - endIndex);
            }

            return s;
        }
        
        // Replacing (-a) with (a - 2*a).
        //public static string DecReplaceNegative(string s)
        //{
        //    // Index that finds the negative value.
        //    int startIndex = 1;

        //    // The value.
        //    string value = "";

        //    // Getting the value.
        //    while (startIndex < s.Length && (Char.IsDigit(s[startIndex]) || s[startIndex] == '.'))
        //    {
        //        value += s[startIndex];
        //        startIndex++;
        //    }

        //    // Replacing (-value) with (value - 2*value).
        //    string newValue = value + "-" + (2 * Convert.ToDouble(value)).ToString();

        //    // Inserting the new value in the original string.
        //    s = newValue + s.Substring(startIndex, s.Length - startIndex);

        //    return s;
        //}
    }
}
