using Exercism;
using System;
class Programm
{
    static void Main()
    {
        var matrix = new[,]
       {{4, 5, 4}, {3, 5, 5}, {1, 5, 4}};

        foreach (var row in SaddlePoints.Calculate(matrix))
        {
            Console.WriteLine(row.ToString());
        }
                
    }
}