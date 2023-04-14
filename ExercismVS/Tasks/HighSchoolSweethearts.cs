using System;
using System.Text;
using System.Collections.Generic;
using System.Globalization;

public static class HighSchoolSweethearts
{
    private const int _singleLineLength = 61;

    private const string _bannerTemplate = @"     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     L. G.  +  P. R.     **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *";
    public static string DisplaySingleLine(string studentA, string studentB)
    {
        var whiteSpaceAmount = _singleLineLength - studentA.Length - studentB.Length - 3;
        var whiteSpaceLeft = new string(' ', whiteSpaceAmount / 2 - 1);
        var whiteSpaceRight = new string(' ', whiteSpaceAmount / 2 + 1);
        var singleLine = $"{whiteSpaceLeft}{studentA} ♡ {studentB}{whiteSpaceRight}";
        return singleLine;
    }
    public static string DisplayBanner(string studentA, string studentB)
    {
        return string.Format(_bannerTemplate, studentA, studentB);
    }

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours)
    {
        // => "Norbert and Heidi have been dating since 22.01.2019 - that's 1.535,22 hours"
        var sb = new StringBuilder();
        sb.Append($"{studentA} and {studentB} have been dating since {start.ToString("dd.MM.yyyy")} - that's {hours.ToString("#,##0.00", new CultureInfo("de-DE"))} hours");
        return sb.ToString();
    }
}