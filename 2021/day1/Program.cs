using static System.Console;
using System;

namespace Day1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WriteLine("This file contains both answers to day 1 advent of code. Which one do you wish to use (1/2): ");
            char choice = ReadKey().KeyChar;
            int numberOfIncreasingReports = 0;
            if (choice == '1')
            {

                // Part one
                WriteLine("This is the answer to part one:");
                for (int i = 1; i < args.Length; i++)
                {
                    int prevInput = int.Parse(args[i - 1]);
                    int input = int.Parse(args[i]);
                    if (input > prevInput)
                    {
                        numberOfIncreasingReports++;
                    }
                }
            }
            else if (choice == '2')
            {
                // Part two
                WriteLine("This is the answer to part two:");
                for (int i = 3; i < args.Length; i++)
                {
                    int pMeasurement1 = int.Parse(args[i-1-2]);
                    int pMeasurement2 = int.Parse(args[i-1-1]);
                    int pMeasurement3 = int.Parse(args[i-1]);
                    int pSum = pMeasurement1 + pMeasurement2 + pMeasurement3;

                    int measurement1 = int.Parse(args[i-2]);
                    int measurement2 = int.Parse(args[i-1]);
                    int measurement3 = int.Parse(args[i]);
                    int sum = measurement1 + measurement2 + measurement3;

                    if (sum > pSum)
                    {
                        numberOfIncreasingReports++;
                    }
                }
            }
            else
            {
                Environment.Exit(0);
            }

            WriteLine($"{numberOfIncreasingReports} reports have been larger than the previous");


        }

    }
}

