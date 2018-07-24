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
            if (NullOrWhiteSpace(numbers))
            {
                return 0;
            }

            var splitNumbers = SplitNumbers(numbers);
            var listOfNumbers = AddToList(splitNumbers);

            CheckForNegatives(listOfNumbers);

            return listOfNumbers.Sum();
        }

        private static bool NullOrWhiteSpace(string numbers)
        {
            return string.IsNullOrWhiteSpace(numbers);
        }

        private static void CheckForNegatives(List<int> listOfNumbers)
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
            var number = splitNumbers.Select(numb => int.Parse(numb));
            listOfNumbers.AddRange(number);

            return listOfNumbers.Where(x => x <=1000).ToList();
        }

        private static string[] SplitNumbers(string numbers)
        {
            return numbers.Split(new[] { ",", "\n", "/", ";", "[", "*", "%", "#", "!", "&", "]", "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
