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
            if(string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }

            var splitNumbers = numbers.Split(new[] { "," , "\n", ";" }, StringSplitOptions.RemoveEmptyEntries);
            var listOfNumbers = new List<int>();

            foreach (var value in splitNumbers)
            {
                var number = int.Parse(value);
                listOfNumbers.Add(number);
            }
            
            return listOfNumbers.Sum();
        }
    }
}
