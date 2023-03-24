using System;
using System.Collections.Generic;
using System.Text;

public static class CryptoSquare
{
    private static string NormalizedPlaintext(string plaintext) =>
        string.Concat(plaintext.ToLower().Where(char.IsLetterOrDigit).ToArray());

    private static (int columns, int rows) GetEncodingParams(int plaintextLength)
    {
        var c = 1;
        var r = 1;
        while (r * c < plaintextLength)
        {
            c++;
            if (r * c < plaintextLength)
            {
                r++;
            }
        }

        return (c, r);
    }
    private static IEnumerable<string> PlaintextSegments(string plaintext)
    {
        var l = plaintext.Length;
        var _params = GetEncodingParams(plaintext.Length);
        
        var segments = new List<string>();
        for (var i = 0; i < _params.rows; i++)
        {
            var _s = i * _params.columns;
            var _l = Math.Min(_params.columns, l - _s);
            var segment = plaintext.Substring(_s, _l);
            while (segment.Length < _params.columns)
            {
                segment += " ";
            }
            segments.Add(segment);
        }

        return segments.ToArray();


    }

    private static string Encoded(string plaintext)
    {
        var segments = PlaintextSegments(NormalizedPlaintext(plaintext)).ToArray();
        if (plaintext.Length == 0)
        {
            return plaintext;
        }
        var r = segments.Length;
        var c = segments.Select(_ => _.Length).Max();
        var res = new List<string>();
        for (var i = 0; i < c; i++)
        {
            var word = "";
            for (var j = 0; j < r; j++)
            {
                word += segments[j][i];
            } 
            res.Add(word);
        }

        var b = new StringBuilder();

        return b.AppendJoin(' ', res.ToArray()).ToString();
    }

    public static string Ciphertext(string plaintext)
    {
        return Encoded(plaintext);
    }
}