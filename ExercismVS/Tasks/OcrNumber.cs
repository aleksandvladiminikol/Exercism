using System;
using System.Collections.Generic;
using System.Linq;
public static class OcrNumbers
{
    private const int UpLineIndex = 0;
    private const int MidLineIndex = 1;
    private const int BotLineIndex = 2;
    private const int Width = 3;
    private const int Length = 4;
    private const char UnparsedNumberResult = '?';

    private const string InputValidationErrorMessage = "Wrong input data";

    private static readonly Dictionary<string, IEnumerable<char>> UpLinePattern = new()
    {
        {"_", new[] {'2', '3', '5', '6', '7', '8', '9', '0'}},
        {"", new[] {'1', '4'}},
    };
    
    private static readonly Dictionary<string, IEnumerable<char>> MidLinePattern = new()
    {
        {"|", new[] {'1', '7'}},
        {"|_", new[] {'5', '6'}},
        {"_|", new[] {'2', '3'}},
        {"|_|", new[] {'4', '8', '9'}},
        {"| |", new[] {'0'}},
    };
    
    private static readonly Dictionary<string, IEnumerable<char>> BotLinePattern = new()
    {
        {"|", new[] {'1', '4', '7'}},
        {"|_", new[] {'2'}},
        {"_|", new[] {'3', '5', '9'}},
        {"|_|", new[] {'6', '8', '0'}},
    };


    public static string Convert(string input)
    {
        var lines = input
            .Split("\n")
            .Select((value, index) => new { value, index })
            .GroupBy(x => x.index / Length)
            .Select(g => g.Select(x => x.value).ToArray())
            .ToArray();

        if (lines.Any(_ => _.Length % Length != 0))
            throw new ArgumentException(InputValidationErrorMessage);
        if (lines.Any(_ => _.Any(c => (c.Length) % Width != 0)))
            throw new ArgumentException(InputValidationErrorMessage);
        
        return string.Join(",", lines.Select(line => ConvertSeparateNumber(string.Join("\n", line))));
    }

    private static string ConvertSeparateNumber(string input)
    {
        var numbers = new List<string[]>();
        var inputArray = input.TrimEnd().Split("\n");

        for (var number = 1; number <= inputArray[0].Length / Width; number++)
        {
            numbers.Add((
                    from inputLine in inputArray 
                    let minIndex = (number - 1) * Width 
                    let maxIndex = number * Width 
                    select string.Concat(inputLine
                        .Where((c, i) => (i >= minIndex && i < maxIndex))))
                .ToArray());
        }
        return string.Concat(numbers.Select(ParseNumber));
    }
    
    private static char ParseNumber(IReadOnlyList<string> input)
    {
        UpLinePattern.TryGetValue(input[UpLineIndex].Trim(), out var upLineNumbers);
        MidLinePattern.TryGetValue(input[MidLineIndex].Trim(), out var midLineNumbers);
        BotLinePattern.TryGetValue(input[BotLineIndex].Trim(), out var botLineNumbers);

        if (upLineNumbers == null || midLineNumbers == null || botLineNumbers == null)
            return UnparsedNumberResult;

        var intersectionResult = upLineNumbers!.Intersect(midLineNumbers!).Intersect(botLineNumbers!);

        return intersectionResult.Count() == 1 
            ? intersectionResult.ElementAt(0)
            : UnparsedNumberResult;
    }
}
