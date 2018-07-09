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
            var listOfNumbers = AddNumbersToList(splitNumbers);
            CheckForNegativeNumbers(listOfNumbers);

            return listOfNumbers.Sum();
        }

        private static void CheckForNegativeNumbers(List<int> listOfNumbers)
        {
            var negativeNumbers = listOfNumbers.Where(x => x < 0);
            if (negativeNumbers.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(",", negativeNumbers)}");
            }
        }

        private static List<int> AddNumbersToList(string[] splitNumbers)
        {
            var listOfNumbers = new List<int>();
            var numb = splitNumbers.Select(number => int.Parse(number));
            listOfNumbers.AddRange(numb);
            //foreach (var value in splitNumbers)
            //{
            //    var number = int.Parse(value);
            //    listOfNumbers.Add(number);
            //    RemoveIfGreaterThan1000(listOfNumbers, number);
            //}
            //var validNumbers = listOfNumbers.Where(n => n < 1000).ToList();
            return listOfNumbers.Where(n => n <= 1000).ToList();
        }

        //private static void RemoveIfGreaterThan1000(List<int> listOfNumbers, int number)
        //{
        //    if (number > 1000)
        //    {
        //        listOfNumbers.Remove(number);
        //    }
        //}

        private static string[] SplitNumbers(string numbers)
        {
            return numbers.Split(new[] { ",", "\n", "/", ";", "[", "*", "%", "#", "!", "&", "]", "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
