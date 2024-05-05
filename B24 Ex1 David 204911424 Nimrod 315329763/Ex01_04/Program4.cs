using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_04
{
    public class Program4
    {
        protected static string m_UserInput;

        public static void Main(String[] args)
        {
            getUserInput();
            CheckIfPalindrome();
            CheckIfDivisibleByFour();
            CountLowerCaseCharacters();
        }

        private static void CheckIfPalindrome()
        {
            bool isPalindrome = IsPalindrome(m_UserInput, 0, m_UserInput.Length - 1);
            if (isPalindrome)
            {
                Console.WriteLine($"{m_UserInput} is a Palindrome.");
            }
            else
            {
                Console.WriteLine($"{m_UserInput} is NOT a Palindrome.");
            }
        }

        private static void CheckIfDivisibleByFour()
        {
            if (IsAlldigits(m_UserInput))
            {
                bool isDivisableByFour = IsDivisableByFour(long.Parse(m_UserInput));
                if (isDivisableByFour)
                {
                    Console.WriteLine($"{m_UserInput} is divisable by 4.");
                }
            }
            else
            {
                Console.WriteLine($"{m_UserInput} is NOT divisable by 4.");
            }
        }

        private static void CountLowerCaseCharacters()
        {
            if (IsAllLetters(m_UserInput))
            {
                int lowerCaseCount = CountLowerCaseCharacters(m_UserInput);
                Console.WriteLine($"{m_UserInput} has {lowerCaseCount} lowercase characters.");
            }
            else
            {
                Console.WriteLine($"{m_UserInput} is not an English string.");
            }
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

        public static bool IsAlldigits(string i_input)
        {
            foreach (char digit in i_input) 
            {
                if (!char.IsDigit(digit))
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

        private static bool IsDivisableByFour(long i_Num)
        {
            if (i_Num % 4 == 0)
            {
                return true;
            }

            return false;
        }

        private static int CountLowerCaseCharacters(string i_input)
        {
            int lowerCaseCount = 0;

            foreach (char letter in i_input)
            {
                if (char.IsLower(letter))
                {
                    lowerCaseCount++;
                }
            }
            return lowerCaseCount;
        }

    }
}
