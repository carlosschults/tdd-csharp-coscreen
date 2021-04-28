using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {    
        public static int Add(string numbers)
        {
            var delimiters = new List<char>() {',', '\n'};
            if (numbers.StartsWith('/'))
            {
                delimiters.Add(numbers[2]);
                numbers = numbers.Split('\n')[1];
            }

            return numbers
                    .Split(delimiters.ToArray())
                    .Select(ParseOrZero)
                    .Sum();
        }

        private static int ParseOrZero(string candidate)
        {
            bool failure =  !int.TryParse(candidate, out int result);

            if (failure || result > 1000)
                return 0;

            if (result < 0)
                throw new ArgumentException($"negatives not allowed: {result}");

            return result;
        }
    }
}
