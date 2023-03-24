using System;
using System.Text;
using System.Linq;
public static class AffineCipher
{
    private const int AlphabetLength = 26;
    private const int StartCode = 97;
    private const int EndCode = 122;
    private const int EncodingLength = 5;

    private static bool IsCoprime(int a, int b) => GCD(a, b) == 1;
    private static int Ex(int a, int b, int i) => (a * i + b) % AlphabetLength;

    private static char? Encryption(char symbol, int a, int b)
    {
        if (!IsCoprime(a, AlphabetLength)) throw new ArgumentException();
        if (!(char.IsLetter(symbol) || char.IsNumber(symbol))) return null;
        if (symbol < StartCode || symbol > EndCode) return symbol;

        var i = Convert.ToInt32(symbol) - StartCode;
        return Convert.ToChar(Ex(a, b, i) + StartCode);
    }

    private static char? Decryption(char symbol, int a, int b)
    {
        if (!IsCoprime(a, AlphabetLength)) throw new ArgumentException();
        if (symbol == ' ') return null;
        if (symbol < StartCode || symbol > EndCode) return symbol;

        var i = Convert.ToInt32(symbol) - StartCode;
        b = b <= AlphabetLength ? b : b - AlphabetLength;
        i = i >= b ? i : i + AlphabetLength;
        var decryptedCode = ModInverse(a, AlphabetLength) * (i - b) % AlphabetLength;
        return Convert.ToChar(decryptedCode + StartCode);
    }

    public static string Encode(string plainText, int a, int b) =>
        string.Join(" ", plainText.ToLower()
            .Select(sym => Encryption(sym, a, b))
            .Where(encrypted => encrypted != null)
            .Select((c, i) => new {Char = c, Group = i / EncodingLength})
            .GroupBy(x => x.Group, x => x.Char)
            .Select(g => string.Join("", g.ToArray())));


    public static string Decode(string cipheredText, int a, int b) =>
        string.Join("", cipheredText.ToLower()
            .Select(sym => Decryption(sym, a, b))
            .Where(decrypted => decrypted != null).ToArray());

    private static int ModInverse(int a, int m)
    {
        // Use the extended Euclidean algorithm to find the modular inverse
        int m0 = m, t, q;
        int x0 = 0, x1 = 1;

        if (m == 1)
        {
            return 0;
        }

        while (a > 1)
        {
            // q is quotient
            q = a / m;
            t = m;

            // m is remainder now, process same as Euclid's algorithm
            m = a % m;
            a = t;

            t = x0;
            x0 = x1 - q * x0;
            x1 = t;
        }

        // Make x1 positive
        if (x1 < 0)
        {
            x1 += m0;
        }

        return x1;
    }

    private static int GCD(int a, int b)
    {
        if (b == 0)
        {
            return a;
        }
        return GCD(b, a % b);
    }

}