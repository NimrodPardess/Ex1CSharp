using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex01_01
{
    internal class Program
    {
        static void Main()
        {
            List<int> decimalNumbers = GetDecimalNumbersFromUser();
            PrintDecimalNumbers(decimalNumbers);
            PrintAverageZeroesAndOnes(decimalNumbers);
            PrintPowerOfTwoCount(decimalNumbers);
            PrintStrictlyIncreasingCount(decimalNumbers);
            PrintSmallestAndLargestNumbers(decimalNumbers);
        }

        static List<int> GetDecimalNumbersFromUser()
        {
            List<int> decimalNumbers = new List<int>();
            int totalNumberOfInputs = 3;

            for (int i = 0; i < totalNumberOfInputs; i++)
            {
                Console.WriteLine($"Please enter a binary {i + 1} (9 digits)");
                string binaryNumber = Console.ReadLine();

                // Validate the input
                while (!IsValidBinary(binaryNumber))
                {
                    Console.WriteLine("Invalid input. Please enter a 9-digit binary number:");
                    binaryNumber = Console.ReadLine();
                }

                // Convert binary to decimal
                int decimalNumber = Convert.ToInt32(binaryNumber, 2);
                decimalNumbers.Add(decimalNumber);
            }

            return decimalNumbers;
        }

        static void PrintDecimalNumbers(List<int> decimalNumbers)
        {
            // Sort and print the decimal numbers
            decimalNumbers.Sort();
            Console.WriteLine("The decimal numbers in increasing order: ");
            foreach (int decimalNumber in decimalNumbers)
            {
                Console.WriteLine(decimalNumber);
            }
        }

        static void PrintAverageZeroesAndOnes(List<int> decimalNumbers)
        {
            int totalZeroes = 0;
            int totalOnes = 0;

            foreach (int decimalNumber in decimalNumbers)
            {
                string binaryNumber = Convert.ToString(decimalNumber, 2);

                totalZeroes += binaryNumber.Count(digit => digit == '0');
                totalOnes += binaryNumber.Count(digit => digit == '1');
            }

            // Calculate the average number of ones and zeroes
            double averageZeroes = totalZeroes / (double)decimalNumbers.Count;
            double averageOnes = totalOnes / (double)decimalNumbers.Count;

            // Print the average number of ones and zeroes
            Console.WriteLine($"The average number of zeroes is: {averageZeroes}");
            Console.WriteLine($"The average number of ones is: {averageOnes}");
        }

        static void PrintPowerOfTwoCount(List<int> decimalNumbers)
        {
            // Print the number of decimal numbers that are a power of 2
            int powerOfTwoCount = decimalNumbers.Count(IsPowerOfTwo);
            Console.WriteLine($"{powerOfTwoCount} of the input decimal numbers are a power of 2.");
        }

        static void PrintStrictlyIncreasingCount(List<int> decimalNumbers)
        {
            // Prints the number of strictly increasing chars in a decimal number
            int strictlyIncreasingCount = decimalNumbers.Count(IsStrictlyIncreasing);
            Console.WriteLine($"{strictlyIncreasingCount} of the input decimal numbers are a strictly increasing number(by it's chars)");
        }

        static void PrintSmallestAndLargestNumbers(List<int> decimalNumbers)
        {
            // Prints the largest and smallest numbers
            Console.WriteLine($"The smallest number is {decimalNumbers.Min()}");
            Console.WriteLine($"The largest number is {decimalNumbers.Max()}");
        }

        static bool IsPowerOfTwo(int i_number)
        {
            return (int)(Math.Ceiling((Math.Log(i_number) / Math.Log(2))))
                  == (int)(Math.Floor(((Math.Log(i_number) / Math.Log(2)))));
        }

        static bool IsStrictlyIncreasing(int i_number)
        {
            string checkNumber = i_number.ToString();
            for (int i = 0; i < checkNumber.Length - 1; i++)
            {
                if (int.Parse(checkNumber[i].ToString()) >= int.Parse(checkNumber[i + 1].ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        static bool IsValidBinary(string binaryNumber)
        {
            if (binaryNumber.Length != 9)
                return false;

            foreach (char digit in binaryNumber)
            {
                if (digit != '0' && digit != '1')
                    return false;
            }

            return true;
        }
    }
}
