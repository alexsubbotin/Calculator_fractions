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

            // While the current symbol is a digit / '(' / '.'
            while (Char.IsDigit(s[currentIndex]) || s[currentIndex] == '(' || s[currentIndex] == '.')
            {
                // If it't the '(' then send the rest to the Calculate method.
                if (s[currentIndex] == '(')
                {
                    X += Calculate(s.Substring(currentIndex + 1, s.Length - currentIndex), ref currentIndex);
                }
                // If it's a digit/ '.' then store it.
                else
                {
                    X += s[currentIndex];
                    currentIndex++;
                }
            }

            // Store the symbol of an operation.
            operation += s[currentIndex];

            // Going to the next symbol.
            currentIndex++;

            // While the current symbol is a digit / '(' / ')' / '.'
            while (Char.IsDigit(s[currentIndex]) || s[currentIndex] == '(' || s[currentIndex] == ')' || s[currentIndex] == '.')
            {
                // If it's a digit / '.' then store it.
                if (Char.IsDigit(s[currentIndex]) || s[currentIndex] == '.')
                {
                    Y += s[currentIndex];
                    currentIndex++;
                }

                // If it's the '(' then send the rest to the Calculate method.
                if(s[currentIndex] == '(')
                {
                    Y += Calculate(s.Substring(currentIndex + 1, s.Length - currentIndex), ref currentIndex);
                }

                // If it's the ')' then the Y is done.
                if(s[currentIndex] == ')')
                {
                    currentIndex++;
                }
            }

            // In the string which used the Calculate method we skip (currentindex + 1) letters.
            globalIndex += currentIndex;

            // Operations.
            string result = "";
            switch (operation)
            {
                case "+":
                    //result =  X + Y;
                    break;
                case "-":
                    //result = X - Y;
                    break;
                case "*":
                    //result = X * Y;
                    break;
                case "/":
                    //result = X / Y;
                    break;
            }

            return result;
        }
    }
}
