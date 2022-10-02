namespace Exercism;

using System;
using System.Collections.Generic;

public static class Languages
{
    public static List<string> NewList() =>
        new List<string>();

    public static List<string> GetExistingLanguages() => 
        new List<string>() {"C#", "Clojure", "Elm"};

    public static List<string> AddLanguage(List<string> languages, string language)
    {
        languages.Add(language);
        return languages;
    }

    public static int CountLanguages(List<string> languages) => 
        languages.Count;

    public static bool HasLanguage(List<string> languages, string language) => 
        languages.Exists(s => s == language);
    

    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse();
        return languages;
    }

    public static bool IsExciting(List<string> languages)
    {
        var index = languages.FindIndex(s => s == "C#");
        return (index == 0 || (index == 1 && languages.Count <= 3));
    }

    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        languages.Remove(language);
        return languages;
    }

    public static bool IsUnique(List<string> languages)
    {
        return (languages.GroupBy(x => x).Where(g => g.Count() > 1).Select(i => i.Key).ToList()).Count == 0;
    }
}
