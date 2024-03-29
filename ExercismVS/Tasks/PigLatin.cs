using System;
using System.Text.RegularExpressions;
public static class PigLatin
{
    private static readonly Regex VowelRegex = new(@"(?<begin>^|\s+)(?<vowel>a|e|i|o|u|yt|xr)(?<rest>\w+)", RegexOptions.Compiled);
    private static readonly Regex ConsonantRegex = new(@"(?<begin>^|\s+)(?<consonant>ch|qu|thr|th|rh|sch|yt|\wqu|\w)(?<rest>\w+)", RegexOptions.Compiled);
    private const string VowelReplacement = "${begin}${vowel}${rest}ay";
    private const string ConsonantReplacement = "${begin}${rest}${consonant}ay";
    public static string Translate(string sentence) =>
        VowelRegex.IsMatch(sentence)
            ? VowelRegex.Replace(sentence, VowelReplacement)
            : ConsonantRegex.Replace(sentence, ConsonantReplacement);
}