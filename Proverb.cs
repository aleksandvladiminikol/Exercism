using System;
using System.Text;
using System.Collections.Generic;

public static class Proverb
{

    private const string CommonTemplate = "For want of a {0} the {1} was lost.";
    private const string ResultTemplate = "And all for the want of a {0}.";
    
    
    public static string[] Recite(string[] subjects)
    {
        if (subjects.Length == 0) {
            return new string[0];
        }
        return subjects
            .Zip(subjects.Skip(1),
                (a, b) =>  $"For want of a {a} the {b} was lost.")
            .Append($"And all for the want of a {subjects[0]}.")
            .ToArray();

    }
}