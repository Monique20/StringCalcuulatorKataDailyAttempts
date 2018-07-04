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
            var listOfNumbers = AddNumbersToAList(splitNumbers);
            CheckForNegativeNumbers(listOfNumbers);

            return listOfNumbers.Sum();
        }

        private static void CheckForNegativeNumbers(List<int> listOfNumbers)
        {
            var negativeNumbers = listOfNumbers.Where(x => x < 0);
            if (negativeNumbers.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(" ", negativeNumbers)}");
            }
        }

        private static List<int> AddNumbersToAList(string[] splitNumbers)
        {
            var listOfNumbers = new List<int>();
            foreach (var value in splitNumbers)
            {
                var number = int.Parse(value);
                listOfNumbers.Add(number);
                if(number > 1000)
                {
                    listOfNumbers.Remove(number);
                }
            }

            return listOfNumbers;
        }

        private static string[] SplitNumbers(string numbers)
        {
            return numbers.Split(new[] { ",", "\n", "/", ";", "[", "*", "%", "#", "!", "&", "]", "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
