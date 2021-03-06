﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers) || string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }
            CheckForNegatives(numbers);

            
            var listOfNumbers = AddSplitNumbersToList(numbers);
            return listOfNumbers.Sum();
        }

        private static void CheckForNegatives(string numbers)
        {
            if (numbers.Contains("-"))
            {
                throw new Exception("negatives not allowed:" + numbers);
            }
        }

        private static List<int> AddSplitNumbersToList(string numbers)
        {
            var splitNumbers = SplitNumbers(numbers);
            var listOfNumbers = new List<int>();

            foreach (var value in splitNumbers)
            {
                var number = int.Parse(value);
                listOfNumbers.Add(number);
            }

            return listOfNumbers;
        }

        private static string[] SplitNumbers(string numbers)
        {
            return numbers.Split(new[] { ",", "\n", "/", ";" }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
