using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_04
{
    internal class Program4
    {
        protected static string m_UserInput;

        public static void Main(String[] args)
        {
            getuserInput();

        }
        private static void getuserInput()
        {
            Console.WriteLine("Please insert an input of 10 characters:");
            m_UserInput = Console.ReadLine();

            while (!IsValidInput(m_UserInput))
            {
                Console.WriteLine("Invalid input. Please insert an input of 10 characters:");
                m_UserInput = Console.ReadLine();
            }
        }

        private static bool IsValidInput(string i_UserInput)
        {
            if (i_UserInput.Length != 10)
            {
                return false;
            }

            return IsAlldigits(i_UserInput) || IsAllLetters(i_UserInput);
        }

        private static bool IsAllLetters(string i_input)
        {
            foreach (char letter in i_input)
            {
                if (!Char.IsLetter(letter))
                {
                    return false;
                }
            }

            return true;    
        }

        private static bool IsAlldigits(string i_input)
        {
            foreach (char digit in i_input) 
            {
                if (!Char.IsDigit(digit))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
