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
            getUserInput();
            Console.WriteLine(IsPalindrome(m_UserInput, 0, m_UserInput.Length - 1));

        }
        private static void getUserInput()
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

        private static bool IsPalindrome(string i_input, int i_StartOfInput, int i_EndOfInput)
        {
            // Base case
            if (i_StartOfInput >= i_EndOfInput)
            {
                return true;
            }

            if (i_input[i_StartOfInput] == i_input[i_EndOfInput])
            {
                return IsPalindrome(i_input, i_StartOfInput + 1, i_EndOfInput - 1);
            }

            return false;
        }

        private static bool IsDivisableByFour(int i_Num)
        {
            if (i_Num % 4 == 0)
            {
                return true;
            }

            return false;
        }

    }
}
