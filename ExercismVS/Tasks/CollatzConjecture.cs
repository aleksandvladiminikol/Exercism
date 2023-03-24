using System;
using System.Collections.Concurrent;
using Exercism;
using System.Text;
using System.Collections.Generic;

public static class CollatzConjecture
{
    public static int ProcessNumber(int n) => (n % 2 == 0) ? n / 2 : n * 3 + 1;
    public static int Steps(int number)
    {
        if (number < 1)
            throw new ArgumentOutOfRangeException("Only posititve numbers!");
        var res = number;
        var counter = 0;
        while (res != 1)
        {
            res = ProcessNumber(res);
            counter++;
        }
        return counter;
    }
}

