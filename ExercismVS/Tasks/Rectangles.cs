using System;

public static class Rectangles
{
    public static int Count(string[] rows)
    {
        var peaks = GetPeaks(rows);
        
        var result = new List<((int x, int y) A, (int x, int y) B, (int x, int y) C, (int x, int y) D)> ();

        foreach (var peak in peaks)
        {
            var x = peak.Item1;
            var y = peak.Item2;

            var xMatches = peaks.Select(tuple => tuple).Where(tuple => tuple.Item1 == x && tuple.Item2 != y);
            var yMatches = peaks.Select(tuple => tuple).Where(tuple => tuple.Item2 == y && tuple.Item1 != x);

            foreach (var xPoint in xMatches)
            {
                foreach (var yPoint in yMatches)
                {
                    var expectedPoint = (yPoint.Item1, xPoint.Item2);
                    if (peaks.Exists(tuple => tuple == expectedPoint))
                    {
                        var Rectangle = new List<(int, int)>();
                        Rectangle.Add(peak);
                        Rectangle.Add(xPoint);
                        Rectangle.Add(yPoint);
                        Rectangle.Add(expectedPoint);

                        var OrderedRectangle = Rectangle.OrderBy(tuple => tuple.Item1).ThenBy(tuple => tuple.Item2).ToArray();

                        var tupleRectangle = (OrderedRectangle[0], OrderedRectangle[1], OrderedRectangle[2],
                            OrderedRectangle[3]);
                        
                        if (!result.Exists(tuple => tuple == tupleRectangle))
                            result.Add(tupleRectangle);

                    }
                }
            }
        }

        ValidateResult(ref result, rows);
        
        return result.Count;
    }

    private static bool CheckRectangle(((int x, int y) A, (int x, int y) B, (int x, int y) C, (int x, int y) D) rectangle,
        string[] rows)
    {

        var isValid = true;

        for (int i = rectangle.A.y + 1; i < rectangle.B.y; i++)
        {
            var currentSym = rows[rectangle.A.x][i];
            if (currentSym != '-' && currentSym != '+')
            {
                isValid = false;
                break;
            }
        }
            
        for (int i = rectangle.A.x + 1; i < rectangle.C.x; i++)
        {
            var currentSym = rows[i][rectangle.A.y];
            if (currentSym != '|' && currentSym != '+')
            {
                isValid = false;
                break;
            }
        }
            
        for (int i = rectangle.D.x - 1; i > rectangle.B.x; i--)
        {
            var currentSym = rows[i][rectangle.D.y];
            if (currentSym != '|' && currentSym != '+')
            {
                isValid = false;
                break;
            }
        }
            
        for (int i = rectangle.D.y - 1; i > rectangle.C.y; i--)
        {
            var currentSym = rows[rectangle.D.x][i];
            if (currentSym != '-' && currentSym != '+')
            {
                isValid = false;
                break;
            }
        }

        return isValid;

    }
    
    private static void ValidateResult(ref List<((int, int), (int, int), (int, int), (int, int))> rectangles,
        string[] rows)
    {

        List<((int, int), (int, int), (int, int), (int, int))> excPoints = new();
        
        foreach (var rectangle in rectangles)
        {
            if (CheckRectangle(rectangle, rows) == false)
                excPoints.Add(rectangle);
        }

        foreach (var exc in excPoints)
        {
            rectangles.Remove(exc);
        }
        
    }
    
    private static List<(int, int)> GetPeaks(string[] rows)
    {

        var result = new List<(int, int)>();

        for (int i = 0; i < rows.Length; i++)
        {
            for (int j = 0; j < rows[i].Length; j++)
            {
                if (rows[i][j] == '+')
                    result.Add((i, j));
            }
        }

        return result;
    }
}