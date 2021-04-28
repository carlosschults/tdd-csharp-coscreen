using System;
using System.Collections.Generic;

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

            string[] parts = numbers.Split(delimiters.ToArray());
            var result = 0;
            
            foreach (string part in parts)
            {
                var number = ParseOrZero(part);

                if (number < 0)
                    throw new ArgumentException($"negatives not allowed: {number}");

                result += number;                
            }

            return result;
        }

        private static int ParseOrZero(string candidate)
        {
            bool failure =  !int.TryParse(candidate, out int result);

            if (failure || result > 1000)
                return 0;
                
            return result;
        }
    }
}
