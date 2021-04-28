using System;

namespace StringCalculatorKata
{
    public class StringCalculator
    {    
        public static int Add(string numbers)
        {
            string[] parts = numbers.Split(',');
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
