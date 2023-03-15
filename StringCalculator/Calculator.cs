using System.Globalization;

namespace StringCalculator;

public class Calculator
{
    public int Add(string numbers)
    {
        var splitNumbers = numbers.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

        if (!splitNumbers.Any())
        {
            return 0;
        }

        if (splitNumbers.Length == 1)
        {
            return int.Parse(splitNumbers[0]);
        }

        int theInt = int.Parse(splitNumbers[0]) + int.Parse(splitNumbers[1]);
        return theInt;
    }


    public int AddUpToAnyNumber_(string numbers)
    {
        //StringSplitOptions.RemoveEmptyEntries, which tells the method to remove any empty substrings from the resulting array.


        //he Select method is then used to convert each element of the resulting array of substrings from a string to an integer,
        //using the int.Parse method.
        //This produces an IEnumerable<int> sequence of integers.
        var splitNumbers = numbers.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);


        return splitNumbers.Sum();
    }


    public int AddsNumbersUsingNewLineDelimiter(string numbers)
    {
        var delimiters = new[] { ',', '\n' };
        var splitNumbers = numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);


        return splitNumbers.Sum();
    }


    public int AddsNumbersUsingCustomDelimiter(string numbers)
    {
        var delimiters = new List<char> { ',', '\n' };

        if (numbers.StartsWith("//"))
        {
            var splitOnFirstNewLine = numbers.Split(new[] { '\n' }, 2);
            var customDelimiter = splitOnFirstNewLine[0].Replace("//", string.Empty).Single();
            delimiters.Add(customDelimiter);
            numbers = splitOnFirstNewLine[1];
        }

        var splitNumbers = numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);


        return splitNumbers.Sum();
    }


    public int Add_ShouldThrowAnException(string numbers)
    {
        var delimiters = new List<char> { ',', '\n' };

        if (numbers.StartsWith("//"))
        {
            var splitOnFirstNewLine = numbers.Split(new[] { '\n' }, 2);
            var customDelimiter = splitOnFirstNewLine[0].Replace("//", string.Empty).Single();
            delimiters.Add(customDelimiter);
            numbers = splitOnFirstNewLine[1];
        }

        var splitNumbers = numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);

        var negativeNumbers = splitNumbers.Where(x => x < 0).ToList();
        
        
        foreach (var potentiallyNegativeNumber in splitNumbers)
        {
            if (potentiallyNegativeNumber < 0)
            {
                negativeNumbers.Add(potentiallyNegativeNumber);                
            }
        }

        if (negativeNumbers.Any())
        {
            throw new Exception("Negative numbers are not allowed: " + string.Join(",", negativeNumbers));
        }
        return splitNumbers.Sum();
    }
}