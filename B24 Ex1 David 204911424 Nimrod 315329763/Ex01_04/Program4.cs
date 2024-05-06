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
        protected static string m_InputIsPalindrome;
        protected static string m_DivisibleByFour;
        protected static string m_NumberOfLowerCaseLetters;

        public static void Main(String[] args)
        {
            getUserInput();
            checkIfPalindrome();
            checkIfDivisibleByFour();
            numberOfLowerCaseCharacters();
            printResult();
        }
        private static void getUserInput()
        {
            Console.WriteLine("Please insert an input of 10 characters:");
            m_UserInput = Console.ReadLine();

            while (!isValidInput(m_UserInput))
            {
                Console.WriteLine("Invalid input. Please insert an input of 10 characters:");
                m_UserInput = Console.ReadLine();
            }
        }

        private static void checkIfPalindrome()
        {
            bool isPalindrome = Program4.isPalindrome(m_UserInput, 0, m_UserInput.Length - 1);
            m_InputIsPalindrome = $"{(isPalindrome ? "is a palindrome." : "is Not a palindrome.")}";
        }

        private static void checkIfDivisibleByFour()
        {
            if (IsAlldigits(m_UserInput))
            {
                bool isDivisableByFour = Program4.isDivisableByFour(long.Parse(m_UserInput));
                m_DivisibleByFour = $"{(isDivisableByFour ? "is divisible by 4." : "is Not divisible by 4.")}";
            }
        }

        private static void numberOfLowerCaseCharacters()
        {
            if (isAllLetters(m_UserInput))
            {
                int lowerCaseCount = countLowerCaseCharacters(m_UserInput);
                m_NumberOfLowerCaseLetters = $"The input {m_UserInput} has {lowerCaseCount} lowercase characters.";
            }
        }

        private static bool isValidInput(string i_UserInput)
        {
            if (i_UserInput.Length != 10)
            {
                return false;
            }

            return IsAlldigits(i_UserInput) || isAllLetters(i_UserInput);
        }

        private static bool isAllLetters(string i_input)
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
            bool allCharactersAreDigits = long.TryParse(i_input, out long number);
            return allCharactersAreDigits;
        }

        private static bool isPalindrome(string i_input, int i_StartOfInput, int i_EndOfInput)
        {
            // Base case
            if (i_StartOfInput >= i_EndOfInput)
            {
                return true;
            }

            if (i_input[i_StartOfInput] == i_input[i_EndOfInput])
            {
                return isPalindrome(i_input, i_StartOfInput + 1, i_EndOfInput - 1);
            }

            return false;
        }

        private static bool isDivisableByFour(long i_Num)
        {
            if (i_Num % 4 == 0)
            {
                return true;
            }

            return false;
        }

        private static int countLowerCaseCharacters(string i_input)
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

        private static void printResult()
        {
            string result = string.Format("The input {0} {1}\n" +
                                          $"{(IsAlldigits(m_UserInput) ? "The input {0} {2}\n" : "{3}\n")}"
                                          , m_UserInput, m_InputIsPalindrome,m_DivisibleByFour, m_NumberOfLowerCaseLetters);
            Console.WriteLine(result);  
        }

    }
}
