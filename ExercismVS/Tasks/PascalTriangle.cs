namespace Exercism;

public static class PascalTriangle
{
    public static int[] GetPascalLine(int[] prevLine, int degree)
    {
        var currentLine = new int[degree];
        for (var elementIndex = 0; elementIndex < degree; elementIndex++)
        {
            var maxIndex = prevLine.Length - 1;
            var currentValue = (elementIndex > maxIndex || elementIndex == 0) ? 1 : prevLine[elementIndex] + prevLine[elementIndex - 1];
            currentLine[elementIndex] = currentValue;
        }
        return currentLine;
    }
    
    
    public static IEnumerable<IEnumerable<int>> Calculate(int maxdegree)
    {
        var result = new List<int[]>();
        var prevLine = new int[]{};
        for (int degree = 1; degree <= maxdegree; degree++)
        {
            var currentLine = GetPascalLine(prevLine, degree);
            result.Add(currentLine);
            prevLine = currentLine;
        }

        return result;
    }

}