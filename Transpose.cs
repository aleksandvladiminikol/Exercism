using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Exercism;

public static class Transpose
{
    
    public static string String(string input)
    {
        var inputArray = input.Split('\n').ToList();
        var result = new StringBuilder();

        var h = inputArray.Count;
        var l = inputArray.Max(str=> str == null ? 0 : str.Length);

        for (int i = 0; i < l; i++)
        {
            var resultStr = "";

            for (int j = 0; j < h; j++)
            {
                var stop = false;
                var currentString = inputArray[j];

                if (i < currentString.Length)
                {
                    resultStr = resultStr + inputArray[j][i];
                    resultStr = resultStr.Replace("$KEY$", " ");
                    stop = false;
                }
                else if (!stop)
                {
                    resultStr = resultStr + "$KEY$";
                    stop = true;
                }
            }

            result.AppendLine(resultStr.Replace("$KEY$", ""));
        }
        
        return result.ToString().TrimEnd();

    }
    
    public static string String123(string input)
    {
        var inputArray = input.Split('\n');
        var l = inputArray.Length;
        var h = inputArray[0].Length;

        var result = new char[h,l];

        
        for (int i = 0; i < l; i++)
        {
            for (int j = 0; j < h; j++)
            {
                result[j, i] = inputArray[i][j];
            }
        }

        var res = new StringBuilder();
        
        for (int i = 0; i < h; i++)
        {
            var stringResult = "";
            for (int j = 0; j < l; j++)
            {
                stringResult = stringResult + result[i, j];
            }

            res.AppendLine(stringResult);
        }
        
        return res.ToString().TrimEnd();

    }
    
}