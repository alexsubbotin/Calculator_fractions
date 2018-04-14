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
            s = DecFracPlusMinus(s);
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
                s = s.Substring(0, startIndex) + newS + s.Substring(endIndex + 1, s.Length - endIndex + 1);
            }

            return s;
        }

        // Function to calcualte multiplication and division.
        public static string DecFracMultAndDiv(string s)
        {
            // If there are those operations at all.
            if (s.IndexOf('*') != -1 || s.IndexOf('/') != -1)
            {
                int multIndex = s.IndexOf('*');


            }
            else
                return s;
        }

        public static string DecFracPlusMinus(string s)
        {
            string X = "";
            string Y = "";

            int currIndex = 0;

            while (currIndex < s.Length && s[currIndex] != '+')
            {
                if (s[currIndex] == '-')
                    if (currIndex == 1 || !Char.IsDigit(s[currIndex - 1]))
                    {
                        X += s[currIndex];
                        currIndex++;
                    }
                    else
                        break;

                X += s[currIndex];
                currIndex++;
            }

            if (X != s)
                X = DecFracCalcAll(X);

            if (currIndex != s.Length)
            {
                string operation = s[currIndex].ToString();
                currIndex++;

                while (currIndex < s.Length)
                {
                    Y += s[currIndex];
                    currIndex++;
                }

                Y = DecFracCalcAll(Y);

                double res;
                if (operation == "+")
                    res = Convert.ToDouble(X) + Convert.ToDouble(Y);
                else
                    res = Convert.ToDouble(X) - Convert.ToDouble(Y);

                return res.ToString();
            }
            else
                return X;
        }
    }
}
