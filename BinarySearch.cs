using System;
using System.Linq;
public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        var currentArray = input;
        var delta = 0;
        while (currentArray.Length > 1)
        {
            var count = currentArray.Length;
            var middleIndex = count / 2;

            var comparisonValue = currentArray[middleIndex];

            if (comparisonValue == value)
                return middleIndex + delta;

            var leftPart = comparisonValue > value;
            
            var newArray  = currentArray.Select((Value, Index) => new {Value, Index})
                .Where((arg => leftPart ? (arg.Index < middleIndex) : arg.Index > middleIndex)).Select(arg => arg.Value).ToArray();

            if (!leftPart)
                delta += currentArray.Length - newArray.Length;
            
            currentArray = newArray;

        }

        return (currentArray.Length != 0 && currentArray[0] == value) ? delta : -1;

    }
}