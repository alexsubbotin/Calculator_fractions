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
        public static string Calculate(string s, ref int globalIndex)
        {
            // The first element.
            string X = "";

            // The second element.
            string Y = "";

            // The operation between the elements.
            string operation = "";

            // Current index in the string.
            int currentIndex = 0;

            // The result.
            string result = "";

            // Indicates that the X was found.
            bool Xfound = false;

            // Indiciates that it's the end of the brackets.
            bool getOut = false;

            while (currentIndex < s.Length && !getOut)
            {
                // While the current symbol is a digit / '(' / '.'
                while (currentIndex < s.Length && !Xfound && 
                    (Char.IsDigit(s[currentIndex]) || s[currentIndex] == '(' || s[currentIndex] == '.'))
                {
                    // If it's the '(' then send the rest to the Calculate method.
                    if (s[currentIndex] == '(')
                    {
                        X += Calculate(s.Substring(currentIndex + 1, s.Length - currentIndex - 1), ref currentIndex);
                    }
                    // If it's a digit/ '.' then store it.
                    else
                    {
                        X += s[currentIndex];
                        currentIndex++;
                    }
                }

                // If all the string was gone through.
                if (currentIndex == s.Length)
                    break;

                // X found.
                Xfound = true;

                // Store the symbol of an operation.
                operation = s[currentIndex].ToString();

                // Going to the next symbol.
                currentIndex++;

                // While the current symbol is a digit / '(' / ')' / '.'
                while (currentIndex < s.Length &&
                    (Char.IsDigit(s[currentIndex]) || s[currentIndex] == '(' || s[currentIndex] == ')' || s[currentIndex] == '.'))
                {

                    // If it's the '(' then send the rest to the Calculate method.
                    if (s[currentIndex] == '(')
                    {
                        Y += Calculate(s.Substring(currentIndex + 1, s.Length - currentIndex - 1), ref currentIndex);
                    }
                    else
                    {
                        // If it's a digit '.' then store it.
                        if (Char.IsDigit(s[currentIndex]) || s[currentIndex] == '.')
                        {
                            Y += s[currentIndex];
                        }

                        currentIndex++;
                    }
                }

                // In the string which used the Calculate method we skip (currentindex + 1) symbols.
                globalIndex += currentIndex + 1;

                // Operations.
                switch (operation)
                {
                    case "+":
                        result = (Convert.ToInt32(X) + Convert.ToInt32(Y)).ToString();
                        break;
                    case "-":
                        result = (Convert.ToInt32(X) - Convert.ToInt32(Y)).ToString();
                        break;
                    case "*":
                        result = (Convert.ToInt32(X) * Convert.ToInt32(Y)).ToString();
                        break;
                    case "/":
                        result = (Convert.ToInt32(X) / Convert.ToInt32(Y)).ToString();
                        break;
                }

                // Writing the result to the X.
                X = result;

                // Clearing the Y.
                Y = "";

                // IF the previous is the ')' then get out of the cycle.
                if (s[currentIndex - 1] == ')')
                    getOut = true;
            }

            return X;
        }
    }
}
