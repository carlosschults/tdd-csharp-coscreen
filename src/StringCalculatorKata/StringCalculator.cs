using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculatorKata
{
    public class StringCalculator
    {    
        public static int Add(string numbers)
        {
            var (delimiters, rest) = ExtractDelimitersAndNumbers(numbers);

            return rest
                    .Split(delimiters, StringSplitOptions.None)
                    .Select(ParseOrZero)
                    .Sum();
        }

        private static (string[], string) ExtractDelimitersAndNumbers(string numbers)
        {
            var delimiters = new List<string>() {",", "\n"};
            
            if (!numbers.StartsWith("//"))
                return (delimiters.ToArray(), numbers);

            var parts = numbers.Split('\n');
            numbers = parts[1];
            var candidateDelimiters = parts[0]
                .Replace("/", "");
            
            if (candidateDelimiters.Contains("["))
            {
                var matches = Regex.Matches(candidateDelimiters, "[\\[!@#$%¨&*\\]+]{1}");
                foreach (Match match in matches)
                    delimiters.Add(match.Value);
            }
            
            delimiters.Add(candidateDelimiters);
        
            return (delimiters.ToArray(), numbers);
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
