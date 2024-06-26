﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex01_02;

namespace Ex01_03
{
    internal class Program3
    {
        public static void Main(String[] args)
        {
            int sizeOfDiamond = checkInputOddOrEven(getUserInput());
            Ex01_02.Program2.printDiamond(sizeOfDiamond);
        }

        private static int getUserInput()
        {
            int sizeOfDiamond = 0;
            Console.WriteLine("Please enter the size of the diamond you want:");
            string userInput = Console.ReadLine();

            while (!IsValidInput(userInput))
            {
                Console.WriteLine("Invalid input. Please enter a number of the size of the diamond you want:");
                userInput = Console.ReadLine();
            }

            sizeOfDiamond = int.Parse(userInput);
            return sizeOfDiamond;
        }

        private static int checkInputOddOrEven(int input)
        {
            if (IsEven(input))
            {
                return input / 2;
            }
            return input / 2 + 1;
        }

        private static bool IsEven(int num) 
        {
            if (num % 2 == 0)
            {
                return true;
            }    
            return false;
        }

        public static bool IsValidInput(string i_sizeOfDiamond)
        {
            for (int i = 0; i < i_sizeOfDiamond.Length; i++)
            {
                if (char.IsDigit(i_sizeOfDiamond[i]) == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
