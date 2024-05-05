using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex01_04;

namespace Ex01_05
{
    public class Program5
    {
        protected static string m_UserInput;
        protected static int m_LeastSignificantDigit;
        public static void Main(string[] args)
        {
            getUserInput();
            setLeastSignificantDigit(m_UserInput);
            countAllDigitsSmallerFromLSD();
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

        private static void setLeastSignificantDigit(string i_Number)
        {
            m_LeastSignificantDigit = int.Parse(i_Number[i_Number.Length - 1].ToString());
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
            Console.WriteLine(count);
            return count;   
        }
    }
}
