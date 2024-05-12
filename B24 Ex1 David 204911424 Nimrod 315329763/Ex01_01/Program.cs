using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex01_01
{
    public class Program
    {
        private static StringBuilder m_SortedDecimalNumbers = new StringBuilder();
        private static double m_AverageNumberOfZeros;
        private static double m_AverageNumberOfOnes;
        private static int m_CountPowerOfTwo = 0;
        private static int m_CountStrictlyIncreasingDecimalInputs = 0;
        private static int m_SmallestDecimalNumber;
        private static int m_LargestDecimalNumber;

        static void Main()
        {
            List<int> decimalNumbers = getNumbersFromUserSorted();
            getDecimalNumbers(decimalNumbers);
            getAverageZeroesAndOnes(decimalNumbers);
            countPowerOfTwoCount(decimalNumbers);
            countStrictlyIncreasing(decimalNumbers);
            getSmallestAndLargestNumbers(decimalNumbers);
            printResults();
        }

        private static List<int> getNumbersFromUserSorted()
        {
            List<int> decimalNumbers = new List<int>();
            int totalNumberOfInputs = 3;

            for (int i = 0; i < totalNumberOfInputs; i++)
            {
                Console.WriteLine($"Please enter a binary {i + 1} (9 digits)");
                string binaryNumber = Console.ReadLine();

                // Validate the input
                while (!isValidBinary(binaryNumber))
                {
                    Console.WriteLine("Invalid input. Please enter a 9-digit binary number:");
                    binaryNumber = Console.ReadLine();
                }

                // Convert binary to decimal
                int decimalNumber = Convert.ToInt32(binaryNumber, 2);
                decimalNumbers.Add(decimalNumber);
                decimalNumbers.Sort();
            }

            return decimalNumbers;
        }

        private static void getDecimalNumbers(List<int> i_DecimalNumbers)
        {
            m_SortedDecimalNumbers.Append(i_DecimalNumbers[0] + ", "
                                        + i_DecimalNumbers[1] + ", "
                                        + i_DecimalNumbers[2]);
        }

        private static void getAverageZeroesAndOnes(List<int> decimalNumbers)
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
            m_AverageNumberOfZeros = totalZeroes / (double)decimalNumbers.Count;
            m_AverageNumberOfOnes = totalOnes / (double)decimalNumbers.Count;
        }

        private static void countPowerOfTwoCount(List<int> decimalNumbers)
        {
           m_CountPowerOfTwo = decimalNumbers.Count(isPowerOfTwo);
        }

        private static void countStrictlyIncreasing(List<int> decimalNumbers)
        {
            m_CountStrictlyIncreasingDecimalInputs = decimalNumbers.Count(isStrictlyIncreasing);
        }

        private static void getSmallestAndLargestNumbers(List<int> decimalNumbers)
        {
            m_SmallestDecimalNumber = decimalNumbers.Min();
            m_LargestDecimalNumber = decimalNumbers.Max();
        }

        private static bool isPowerOfTwo(int i_number)
        {
            return (int)(Math.Ceiling((Math.Log(i_number) / Math.Log(2))))
                  == (int)(Math.Floor(((Math.Log(i_number) / Math.Log(2)))));
        }

        private static bool isStrictlyIncreasing(int i_number)
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

        private static bool isValidBinary(string i_binaryNumber)
        {
            if (i_binaryNumber.Length != 9)
                return false;

            foreach (char digit in i_binaryNumber)
            {
                if (digit != '0' && digit != '1')
                    return false;
            }

            return true;
        }

        private static void printResults()
        {
            string results = String.Format("The numbers are: {0}.\n" +
                                           "{1} of the numbers are power of 2.\n" +
                                           "{2} of the numbers are strictly increasing sequence.\n" +
                                           "The average of zeroes is {3}.\n" +
                                           "The average of ones is {4}.\n" +
                                           "The largest number is {5}.\n" +
                                           "The smallest number is {6}.",
                                           m_SortedDecimalNumbers, m_CountPowerOfTwo,
                                           m_CountStrictlyIncreasingDecimalInputs, m_AverageNumberOfZeros,
                                           m_AverageNumberOfOnes, m_LargestDecimalNumber, m_SmallestDecimalNumber);

            Console.WriteLine(results);
        }
    }
}
