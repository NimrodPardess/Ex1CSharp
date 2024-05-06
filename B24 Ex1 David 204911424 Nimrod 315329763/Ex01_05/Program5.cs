using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Ex01_04;

namespace Ex01_05
{
    public class Program5
    {
        protected static string m_UserInput;
        protected static int m_LeastSignificantDigit;
        protected static int m_AllDigitsSmallerFromLSD;
        protected static int m_AllDigitsDivisibleByThree;
        protected static int m_MaxDigit;
        protected static float m_AvgDigit;
        public static void Main(string[] args)
        {
            getUserInput();
            m_LeastSignificantDigit = getLeastSignificantDigit(m_UserInput);
            m_AllDigitsSmallerFromLSD = countAllDigitsSmallerFromLSD();
            m_AllDigitsDivisibleByThree = countAllDigitsDivisibleByThree();
            m_MaxDigit = getMaxDigit();
            m_AvgDigit = getAvgDigit();
            printResults();
        }

        private static void getUserInput() 
        {
            Console.WriteLine("Please insert a 8 digit number:");
            m_UserInput = Console.ReadLine();

            while (!isValidInput(m_UserInput))
            {
                Console.WriteLine("Invalid input. Please insert a 8 digit number:");
                m_UserInput = Console.ReadLine();
            }
        }

        public static bool isValidInput(string i_Input)
        {
            bool validLength = i_Input.Length == 8;
            return validLength && Ex01_04.Program4.IsAlldigits(i_Input);
        }

        private static int getLeastSignificantDigit(string i_Number)
        {
            return int.Parse(i_Number[i_Number.Length - 1].ToString());
        }

        private static int countAllDigitsSmallerFromLSD()
        {
            int count = 0;

            foreach (char digit in m_UserInput)
            {
                if (int.Parse(digit.ToString()) <  m_LeastSignificantDigit)
                {
                    count++;
                }
            }
           return count;
        }

        private static int countAllDigitsDivisibleByThree() 
        {
            int count = 0;

            foreach (char digit in m_UserInput)
            {
                if (int.Parse(digit.ToString()) % 3 == 0)
                {
                    count++;
                }
            }
            return count;
        }

        private static int getMaxDigit()
        {
            int maxDigit = 0;

            foreach (char digit in m_UserInput)
            {
                maxDigit = Math.Max(maxDigit, int.Parse(digit.ToString()));
            }

            return maxDigit;
        }

        private static float getAvgDigit() 
        {
            float avgAllDigits;
            float sumAllDigits = 0;
            

            foreach (char digit in m_UserInput)
            {
                sumAllDigits += int.Parse(digit.ToString());
            }

            avgAllDigits = sumAllDigits / m_UserInput.Length; 
            return avgAllDigits;
        }

        private static void printResults()
        {
            string results = String.Format("The input {0} is valid.\n" +
                                           "The right most digit is {1}.\n" +
                                           "The maximum digit is {2}.\n" +
                                           "There are {3} digits that are divisible by 3\n" +
                                           "There are {4} digits that are smaller than {1}.\n" +
                                           "The average of all the digits is {5}.", 
                                           m_UserInput, m_LeastSignificantDigit, m_MaxDigit,m_AllDigitsDivisibleByThree, m_AllDigitsSmallerFromLSD, m_AvgDigit);

            Console.WriteLine(results);
        }
    }
}