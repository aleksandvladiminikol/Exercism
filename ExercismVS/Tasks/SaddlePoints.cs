using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism
{
    public static class SaddlePoints
    {
        public static IEnumerable<(int, int)> Calculate(int[,] matrix)
        {
            {
                List<(int, int)> result = new();

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (IsGreaterThanAnyNumberInRow(matrix, i, j))
                            continue;
                        else
                            if (IsLessThanAnyNumberInColumn(matrix, i, j))
                            continue;

                        result.Add((i + 1, j + 1));
                    }
                }
                return result;
            }
            
        }
        private static bool IsLessThanAnyNumberInColumn(int[,] myArray, int i, int j)
        {
            bool result = false;
            for (int k = 0; k < myArray.GetLength(0); k++)
            {
                result = myArray[i, j] > myArray[k, j] || result;
            }

            return result;        
        }

        private static bool IsGreaterThanAnyNumberInRow(int[,] myArray, int i, int j)
        {
            bool result = false;
            for (int k = 0; k < myArray.GetLength(1); k++)
                result = myArray[i, j] < myArray[i, k] || result;
            return result;
        }
    }

}
