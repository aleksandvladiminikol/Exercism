using System;

public static class Rectangles
{
    public static int Count(string[] rows)
    {
        var peaks = new List<(int, int)> ();

        for(int i = 0; i < rows.Length; i++)
        {
            for(int j = 0; j < rows[i].Length; j++)
            {
                if (rows[i][j] == '+')
                    peaks.Add((i, j));
            }
        }
        return 0;
    }
}