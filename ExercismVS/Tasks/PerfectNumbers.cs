using System;
using System.Collections.Generic;
using System.Linq;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static IEnumerable<int> Factors(int number)
    {
        var result = new List<int>();
        for (int i = 1; i < number; i++)
        {
            if (number%i == 0)
                result.Add(i);
        }
        return result;
    }

    public static Classification Classify(int number)
    {
        if (number <= 0)
            throw new ArgumentOutOfRangeException();
        var aliquotCriteria = number - Factors(number).Sum();

        return aliquotCriteria == 0 ? Classification.Perfect :
            aliquotCriteria > 0 ? Classification.Deficient :
            Classification.Abundant;


    }
}