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
            List<int> decimalNumbers = new List<int>();
            int totalNumberOfInputs = 3;
            int totalOnes = 0;
            int totalZeroes = 0;
            int powerOfTwoCount = 0;
            int strictlyIncreasingCount = 0;

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

                // Counts the total number of zeroes and ones of each decimal number
                foreach (char digit in binaryNumber)
                {
                    if (digit == '1')
                        totalOnes++;
                    else
                        totalZeroes++;
                }

                // Convert binary to decimal
                int decimalNumber = Convert.ToInt32(binaryNumber, 2);
                decimalNumbers.Add(decimalNumber);

                if (isPowerOfTwo(decimalNumber))
                {
                    powerOfTwoCount++;
                }

                if (IsStrictlyIncreasing(decimalNumber))
                {
                    strictlyIncreasingCount++;
                }
            }

            // Sort and print the decimal numbers
            decimalNumbers.Sort();
            Console.WriteLine("The decimal numbers in increasing order: ");
            foreach (int decimalNumber in decimalNumbers)
            {
                Console.WriteLine(decimalNumber);
            }

            // Calculate the average number of ones and zeroes
            double averageZeroes = totalZeroes / totalNumberOfInputs;
            double averageOnes = totalOnes / totalNumberOfInputs;

            // Print the average number of ones and zeroes
            Console.WriteLine($"The average number of zeroes is: {averageZeroes}");
            Console.WriteLine($"The average number of ones is: {averageOnes}");

            // Print the number of decimal numbers that are a power of 2
            Console.WriteLine($"{powerOfTwoCount} of the input decimal numbers are a power of 2.");

            // Prints the number of strictly increasing chars in a decimal number
            Console.WriteLine($"{strictlyIncreasingCount} of the input decimal numbers are a strictly icreasing number(by it's chars)");

            // Prints the largest and smallest numbers
            Console.WriteLine($"The smallest number is {decimalNumbers[0]}");
            Console.WriteLine($"The largest number is {decimalNumbers[decimalNumbers.Count - 1]}");
        }

        static bool isPowerOfTwo(int i_number)
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
