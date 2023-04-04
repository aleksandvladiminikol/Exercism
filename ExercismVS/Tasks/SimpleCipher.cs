using System;
using System.Text;

public static class AsciiLetters
{
    private static int A = 97;
    private static int Z = 122;
    
    public static int Shift(int letter, int shift)
    {
        int result = letter + shift;
        if (result > Z)
        {
            result = A + (result - Z) - 1;
        }
        return result;
    }
    public static int Unshift(int letter, int shift)
    {
        int result = letter - shift;
        if (result < A)
        {
            result = Z - (A - result) + 1;
        }
        return result;
    }
    public static int GetShift(int key)
    {
        return key - A;
    }
    public static string GetRandomKey(int length)
    {
        var random = new Random();
        var result = new StringBuilder();
        for (int i = 0; i < length; i++)
        {
            result.Append((char)random.Next(A, Z));
        }

        return result.ToString();
    }
}

public class SimpleCipher
{
    private string _key = AsciiLetters.GetRandomKey(100);
    public SimpleCipher()
    {
    }

    public SimpleCipher(string key)
    {
        _key = key;
    }
    
    public string Key => _key;

    public string Encode(string plaintext)
    {
        var counter = 0;
        var limit = _key.Length;
        var res = new StringBuilder();
        foreach (var letter in plaintext.ToLower())
        {
            var shift = 0;
            if (counter == limit)
            {
                counter = 0;
            }
            shift = AsciiLetters.GetShift(_key[counter]);
            res.Append((char) AsciiLetters.Shift(letter, shift));
            counter++;
        }

        return res.ToString();
    }

    public string Decode(string ciphertext)
    {
        var counter = 0;
        var limit = _key.Length;
        var res = new StringBuilder();
        foreach (var letter in ciphertext.ToLower())
        {
            var shift = 0;
            if (counter == limit)
            {
                counter = 0;
            }
            shift = AsciiLetters.GetShift(_key[counter]);
            res.Append((char) AsciiLetters.Unshift(letter, shift));
            counter++;
        }

        return res.ToString();
    }
}