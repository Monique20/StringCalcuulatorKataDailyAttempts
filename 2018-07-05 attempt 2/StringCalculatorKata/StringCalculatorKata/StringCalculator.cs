using System;
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
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }

            var splitNumbers = Split(numbers);
            var listOfNumbers = AddToList(splitNumbers);
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

        private static List<int> AddToList(string[] splitNumbers)
        {
            var listOfNumbers = new List<int>();

            foreach (var value in splitNumbers)
            {
                var number = int.Parse(value);
                listOfNumbers.Add(number);
                RemoveNumbersGreaterThan1000(listOfNumbers, number);
            }

            return listOfNumbers;
        }

        private static void RemoveNumbersGreaterThan1000(List<int> listOfNumbers, int number)
        {
            if (number > 1000)
            {
                listOfNumbers.Remove(number);
            }
        }

        private static string[] Split(string numbers)
        {
            return numbers.Split(new[] { ",", "\n", ";", "/", "[", "]", "*", "%", "#", "!", "&", "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
