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
                if (int.TryParse(part, out int integer))
                    result += integer;
            }

            return result;
        }
    }
}
