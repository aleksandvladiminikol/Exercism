using System;
using System.Text.RegularExpressions;
using System.Linq;

public static class Wordy
{
    private const string DigitPattern = @"\-?\d+";
    private const string OperationPattern = @"(multiplied by|plus|minus|divided by|raised to the)";
    private const int LastNumberShift = 2;
    private static int Calculate(int a, int b, string operation) => operation switch
    {
        "plus" => a + b,
        "minus" => a - b,
        "multiplied by" => a * b,
        "divided by" => a / b,
        "raised to the" => (int) Math.Pow(a, b)
    };

    public static int Answer(string question)
    {
        var digits = Regex.Matches(question, DigitPattern);
        var operations = Regex.Matches(question, OperationPattern);

        if (digits.Count == 0 
            || operations.Count != digits.Count - 1 
            || Enumerable
                .Range(0, operations.Count)
                .Any(index => digits[index].Index > operations[index].Index || digits[index + 1].Index < operations[index].Index)
            || digits[^1].Index + digits[^1].Length <= question.Length - LastNumberShift)
            throw new ArgumentException();
        
        if (Enumerable.Range(0, operations.Count).Any(index => digits[index].Index > operations[index].Index || digits[index + 1].Index < operations[index].Index))
        {
            throw new ArgumentException();
        }
        
        var value = int.Parse(digits[0].Value);

        return Enumerable
            .Range(0, operations.Count)
            .Aggregate(value, (current, index) 
                => Calculate(
                    current, 
                    int.Parse(digits[index + 1].Value), 
                    operations[index].Value));
    }
}