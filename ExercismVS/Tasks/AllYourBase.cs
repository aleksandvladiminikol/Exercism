using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if (inputBase <= 1 || outputBase <= 1)
            throw new ArgumentException("Base should be positive");
        if (inputDigits.Any(_ => _ < 0 || _ >= inputBase)) 
            throw new ArgumentException("Digits should be positive");;
        
        var res = new List<int>();
        var dec = ToDecimal(inputBase, inputDigits);
        
        while (dec >= outputBase)
        {
            var div = dec / outputBase;
            var rem = dec - div*outputBase;
            res.Insert(0, rem);
            dec = div;
        }
        res.Insert(0, dec);
        return res.ToArray();
    }

    public static int ToDecimal(int inputBase, int[] inputDigits)
    {
        var dec = 0;
        var degree = inputDigits.Length - 1;
        foreach (var item in inputDigits)
        {
            dec += item * (int) Math.Pow(inputBase, degree);
            degree--;
        }

        return dec;
        // dec.ToString().Select(_ => int.Parse(_.ToString())).ToArray();
    }

}