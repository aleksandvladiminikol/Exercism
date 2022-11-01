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
}