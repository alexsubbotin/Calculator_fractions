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
            
            string X = "";
            string Y = "";
            string operation = "";

            int currentIndex = 0;

            while (Char.IsDigit(s[currentIndex]) || s[currentIndex] == '(' || s[currentIndex] == '.')
            {
                if (s[currentIndex] == '(')
                {
                    X += Calculate(s.Substring(currentIndex + 1, s.Length - currentIndex), ref currentIndex);
                }
                else
                {
                    X += s[currentIndex];
                    currentIndex++;
                }
            }

            operation += s[currentIndex];
            currentIndex++;

            while (Char.IsDigit(s[currentIndex]) || s[currentIndex] == '(' || s[currentIndex] == ')' || s[currentIndex] == '.')
            {
                if (Char.IsDigit(s[currentIndex]) || s[currentIndex] == '.')
                {
                    Y += s[currentIndex];
                    currentIndex++;
                }

                if(s[currentIndex] == '(')
                {
                    Y += Calculate(s.Substring(currentIndex + 1, s.Length - currentIndex), ref currentIndex);
                }

                if(s[currentIndex] == ')')
                {
                    currentIndex++;
                }
            }

            globalIndex += currentIndex;

            switch (operation)
            {
                case "+":
                    //buf =  X + Y;
                    break;
                case "-":
                    //buf = X - Y;
                    break;
                case "*":
                    //buf = X * Y;
                    break;
                case "/":
                    //buf = X / Y;
                    break;
            }
        }
    }
}
