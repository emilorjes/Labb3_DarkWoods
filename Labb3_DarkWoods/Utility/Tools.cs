using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3_DarkWoods.Utility
{
    class Tools
    {
        static public void RedTextWr(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(input);
            Console.ResetColor();
        }
        static public void YellowTextWr(string input)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(input);
            Console.ResetColor();
        }
       
}
