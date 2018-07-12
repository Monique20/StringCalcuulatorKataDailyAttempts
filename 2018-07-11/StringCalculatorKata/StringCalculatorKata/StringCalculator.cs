using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }

            var splitNumbers = Split(numbers);
            var listOfNumbers = AddToList(splitNumbers);

            CheckForNegatives(listOfNumbers);
            
            return listOfNumbers.Sum();
        }

        private static void CheckForNegatives(List<int> listOfNumbers)
        {
            var negativeNumber = listOfNumbers.Where(x => x < 0);
            if (negativeNumber.Any())
            {
                throw new Exception($"negatives not allowed:{string.Join(",", negativeNumber)}");
            }
        }

        private static List<int> AddToList(string[] splitNumbers)
        {
            var listOfNumbers = new List<int>();
            var number = splitNumbers.Select(value => int.Parse(value)).Where(n => n <= 1000);
            listOfNumbers.AddRange(number);

            return listOfNumbers;
        }

        private static string[] Split(string numbers)
        {
            return numbers.Split(new[] { ",", "\n", ";", "/"}, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
