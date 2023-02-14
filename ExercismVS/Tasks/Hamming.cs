using System;
using System.Linq;
public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length)
            throw new ArgumentException("Strands lentgh should be equal!");
        return Enumerable.Zip(firstStrand, secondStrand).Where(_ => _.First != _.Second).Count();
    }
}

