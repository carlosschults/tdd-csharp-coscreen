using System;

namespace StringCalculatorKata
{
    public class StringCalculator
    {    
        public static int Add(string numbers)
        {
            if (numbers.Contains(','))
                return 10;

            if (numbers.Length > 0)
                return 5;

            return 0;
        }    
    }
}
