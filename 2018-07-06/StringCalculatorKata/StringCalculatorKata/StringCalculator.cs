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

            var splitNumbers = SplitNumbers(numbers);
            var listOfNumbers = AddToList(splitNumbers);
            CheckForNegatives(numbers, listOfNumbers);

            return listOfNumbers.Sum();
        }

        private static void CheckForNegatives(string numbers, List<int> listOfNumbers)
        {
            var negativeNumbers = listOfNumbers.Where(x => x < 0);
            if (negativeNumbers.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(",", negativeNumbers)}");
            }
        }

        private static List<int> AddToList(string[] splitNumbers)
        {
            var listOfNumbers = new List<int>();

            foreach (var value in splitNumbers)
            {
                var number = int.Parse(value);
                listOfNumbers.Add(number);
                RemoveIfGreaterThan1000(listOfNumbers, number);
            }

            return listOfNumbers;
        }

        private static void RemoveIfGreaterThan1000(List<int> listOfNumbers, int number)
        {
            if (number > 1000)
            {
                listOfNumbers.Remove(number);
            }
        }

        private static string[] SplitNumbers(string numbers)
        {
            return numbers.Split(new[] { ",", "\n", ";", "[", "]", "*", "%", "#", "!", "&", "(", ")", "/" }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}