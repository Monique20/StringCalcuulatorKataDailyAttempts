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

            var splitNumbers = SplitNumbers(numbers);
            var listOfNumbers = AddNumbersToList(splitNumbers);

            CheckForNegatives(numbers);
            
            return listOfNumbers.Sum();
        }

        private static void CheckForNegatives(string numbers)
        {
            if (numbers.Contains("-"))
            {
                throw new Exception("negatives not allowed: " + numbers);
            }
        }

        private static List<int> AddNumbersToList(string[] splitNumbers)
        {
            var listOfNumbers = new List<int>();

            foreach (var value in splitNumbers)
            {
                var number = int.Parse(value);
                listOfNumbers.Add(number);
                CheckIfGreaterThan1000(listOfNumbers, number);
            }

            return listOfNumbers;
        }

        private static void CheckIfGreaterThan1000(List<int> listOfNumbers, int number)
        {
            if (number > 1000)
            {
                listOfNumbers.Remove(number);
            }
        }

        private static string[] SplitNumbers(string numbers)
        {
            return numbers.Split(new[] { ",", "\n" , "/", "*", ";", "[", "]", "%" }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
