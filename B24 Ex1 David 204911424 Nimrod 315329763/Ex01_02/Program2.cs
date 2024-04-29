
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Ex01_02
{
    public class Program2
    {

        private static void drawAsterisk(int i_NumOfAsterisks)
        {
            if (i_NumOfAsterisks == 0)
            {
                return;
            }

            Console.Write("*");
            drawAsterisk(i_NumOfAsterisks - 1);
        }

        private static void drawSpace(int i_NumOfSpaces)
        {
            if (i_NumOfSpaces == 0) 
            {
                return;
            }
            
            Console.Write(" ");
            drawSpace(i_NumOfSpaces - 1);
        }

        // Prints the upper half of the diamond
        private static void printUpperSideOfDiamond(int i_Num0fSpaces, int i_NumOfAsterisks)
        {
            // Base case: 
            if (i_Num0fSpaces == 0)
            {
                return;
            }

            drawSpace(i_Num0fSpaces);
            drawAsterisk(2 * (i_NumOfAsterisks - i_Num0fSpaces) + 1);
            drawSpace(i_Num0fSpaces);
            Console.Write("\n");

            //recursion for upper side
            printUpperSideOfDiamond(i_Num0fSpaces - 1, i_NumOfAsterisks);
        }

        // Prints the lower half of the diamond 
        private static void printLowerSideOfDiamond(int i_Num0fSpaces, int i_NumOfAsterisks)
        {
            // Base case: 
            if (i_Num0fSpaces == 0)
            {
                return;
            }

            drawSpace(i_NumOfAsterisks - i_Num0fSpaces + 1);
            drawAsterisk(2 * i_Num0fSpaces - 1);
            drawSpace(i_NumOfAsterisks - i_Num0fSpaces + 1);
            Console.Write("\n");

            //recursion for lower side`
            printLowerSideOfDiamond(i_Num0fSpaces - 1, i_NumOfAsterisks);
        }

        // Prints a diamond
        public static void printDiamond(int i_NumberOfRows)
        {
            int numOfAstrisks = i_NumberOfRows;
            int numOfSpaces = i_NumberOfRows;

            printUpperSideOfDiamond(numOfSpaces, numOfAstrisks);
            printLowerSideOfDiamond(numOfSpaces - 1, numOfAstrisks);
        }

        public static void Main(String[] args)
        {
            int sizeOfDiamond = 5;
            printDiamond(sizeOfDiamond);
        }
        // Need to ask Pardess for what is the reference
        public static void HelloWorld()
        {
            Console.WriteLine("HelloWorld");
        }
    }
}
