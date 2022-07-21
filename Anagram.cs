namespace Exercism;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;

public class Anagram
{
    private readonly string _baseword;
    public Anagram(string baseWord)
    {
        this._baseword = baseWord.ToLower();
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        var index = 0;
        var result = new List<string>();
        foreach (var word in potentialMatches)
        {
            if (UseWord(word))
            {
                result.Add(word);
                index++;
            }
        }

        return result.ToArray();
    }

    private bool UseWord(string word)
    {
        if (word.ToLower() == _baseword)
        {
            return false;
        }
        
        var useWord = true;
        var symbols = word.ToLower().ToList();
        foreach (var sym in _baseword)
        {
            useWord = symbols.Exists(i => i == sym);
            if (useWord == false)
            {
                break;
            }
            else
            {
                symbols.Remove(sym);
            }
        }
        return (useWord && symbols.Count == 0);
    }
}