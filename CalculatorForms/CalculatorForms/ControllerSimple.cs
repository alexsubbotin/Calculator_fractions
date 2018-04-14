using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorForms
{
    class ControllerSimple
    {
        // Function to calculate an expression with simple fractions.
        public static string SimpFracCalcAll(string s)
        {
            // Fin and calculate brackets.
            CalculateBrackets(s);
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
    }
}
