using System.Text;

namespace Exercism;

using System;

public class RailFenceCipher
{
    private readonly int _rails;
    public RailFenceCipher(int rails)
    {
        _rails = rails;
    }

    public string Encode(string input)
    {
        var rules = EncodingRules(input.Length);
        var resultArray = new Char[input.Length];
        var inputArray = input.ToCharArray();
        var result = new StringBuilder();
        foreach (var pair in rules)
        {
            result.Append(inputArray[pair.Item1]);
        }
        return result.ToString();

    }

    public string Decode(string input)
    {
        var rules = EncodingRules(input.Length, true);
        var resultArray = new Char[input.Length];
        var inputArray = input.ToCharArray();
        foreach (var pair in rules)
        {
            resultArray[pair.Item1] = inputArray[pair.Item2];
        }

        var result = new StringBuilder();
        foreach (var item in resultArray)
        {
            result.Append(item);
        }
        
        return result.ToString();
    }
    
    public static void FillArray<T>(T[,] array, T value)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = value;
            }
        }
    }
    

    public List<Tuple<int, int>> EncodingRules(int strSize, bool isDecode = false)
    {
        var result = new List<Tuple<int, int>>();
        var template = new int[_rails, strSize];
        FillArray<int>(template, -1);
        bool direct = true;

        int j = 0;
        var counter = 0;
        for (int i = 0; i < strSize; i++)
        {
            template[j, i] = counter;
            counter++;
            if (direct)
                j++;
            else
                j--;
            if (j == _rails - 1)
                direct = false;
            else if (j == 0)
                direct = true;
        }


        counter = 0;
        for (int i = 0; i < _rails; i++)
        {
            for (int k = 0; k < strSize; k++)
            {
                var value = template[i, k];
                if (value >= 0)
                {
                    result.Add(new Tuple<int, int>(value, counter));
                    counter++;
                }
            }
        }

        return result;
    }

}