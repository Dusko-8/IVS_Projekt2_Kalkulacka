﻿using System;
using System.Collections.Generic;
using MathematicaLibraryIVS;


namespace StandardDeviation
{
    internal class Program
    {
        /// <summary>
        /// Function reads input, deletes white spaces and coverts strings to decimal
        /// </summary>
        /// <returns>List of decimal numbers</returns>
        static List<decimal> readInput()
        {
            List<decimal> numInput = new List<decimal>();
            decimal parsedNum;
            string inputLine;
            string[] splitLine;

            while ((inputLine = Console.ReadLine()) != null)
            {
                splitLine = inputLine.Split();
                foreach (string strNum in splitLine)
                {
                    if (decimal.TryParse(strNum, out parsedNum))
                    {
                        numInput.Add(parsedNum);
                    }
                    else
                    {
                        Console.WriteLine("Failed to parse: {0}", strNum);
                    }
                }
            }
            return numInput;
        }

        /// <summary>
        /// Fuction calculates standard deviation
        /// </summary>
        /// <param name="numList">List of decimal numbers</param>
        /// <returns>decimal standard deviation</returns>
        static decimal calcSDeviation(List<decimal> numList)
        {
            decimal finalResult = 0;
            decimal mean = 0;
            decimal deviation = 0;
            decimal bracket = 0;
            decimal count = numList.Count;

            for (int i = 0; i < count; i++)
            {
                mean = ML.plus(mean, numList[i]);
                deviation = ML.plus(deviation, ML.power(numList[i], 2));
            }

            mean = ML.divide(mean, count);

            bracket = ML.minus(deviation, ML.multiply(ML.power(mean, 2), count)); // (sum x^2 - n * avg^2)
            finalResult = ML.root(ML.divide(bracket, ML.minus(count, 1)), 2); //sqrt(bracket / n - 1)

            return finalResult;
        }

        /// <summary>
        /// Function generates random numbers for profiling
        /// </summary>
        /// <param name="count">how many numbers should be generated</param>
        /// <returns></returns>
        static List<decimal> genRandNum(int count)
        {
            List<decimal> numList = new List<decimal>();
            Random r = new Random();

            for (int i = 0; i < count; i++)
            {
                numList.Add(r.Next(0, 1000));
                Console.WriteLine(numList[i]);
            }

            return numList;
        }



        static void Main(string[] args)
        {
            List<decimal> numList = new List<decimal>();
            decimal deviationResult;

            numList = genRandNum(10);
            //numList = genRandNum(100);
            //numList = genRandNum(1000);
            //numList = readInput();

            deviationResult = calcSDeviation(numList);

            Console.WriteLine(deviationResult);

            Console.ReadKey();
        }
    }
}


