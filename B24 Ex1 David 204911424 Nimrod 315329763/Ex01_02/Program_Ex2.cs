using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex01_02
{
    internal class Program
    {
        static void Main()
        {
            // Change this number to print a larger or smaller pattern. The main line is 2 * (input) + 1. For example: 4 as input is main line of 9 astericks.
            PrintDiamondPattern(4);  
        }

        static void PrintDiamondPattern(int numberOfAstericksDecider, int i_counter = 0)
        {
            if (i_counter > numberOfAstericksDecider)
            {
                for (int j = numberOfAstericksDecider - 1; j >= 0; j--)
                {
                    Console.WriteLine(new String(' ', 2 * (numberOfAstericksDecider - j)) + String.Join(" ", new String('*', 2 * j + 1).ToCharArray()));
                    Console.WriteLine();
                }
                return;
            }
            Console.WriteLine(new String(' ', 2 * (numberOfAstericksDecider - i_counter)) + String.Join(" ", new String('*', 2 * i_counter + 1).ToCharArray()));
            Console.WriteLine();
            PrintDiamondPattern(numberOfAstericksDecider, i_counter + 1);
        }
    }
}
