using Exercism;
using System;
class Programm
{
    static void Main()
    {
        var result = PythagoreanTriplet.TripletsWithSum(1000);

        foreach (var triplet in result)
        {
            Console.WriteLine(triplet);
        }
    }
}