namespace Exercism;

public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        var result = new int[size, size];

        var maxLimitI = size - 1;
        var minLimitI = 0;
        var maxLimitJ = maxLimitI;
        var minLimitJ = 0;
        
        var i = 0;
        var j = 0;
        var count = 1;
        var direction = 0; 
        while (count <= size*size)
        {
            if (result[j, i] == 0)
            {
                result[j, i] = count;  
            }

            if (count == size * size)
            {
                break;
            }
            
            if (direction == 0)
            {
                if (i < maxLimitI)
                {
                    count++;
                    i++;
                }
                else
                {
                    minLimitJ++;
                    direction = 1;
                }
                
            }
            else if (direction == 1)
            {
                if (j < maxLimitJ)
                {
                    count++;
                    j++;
                }
                else
                {
                    maxLimitI--;
                    direction = 2;
                }
            }
            else if (direction == 2)
            {
                if (i > minLimitI)
                {
                    count++;
                    i--;
                }
                else
                {
                    maxLimitJ--;
                    direction = 3;
                }
            }
            else if (direction == 3)
            {
                if (j > minLimitJ)
                {
                    count++;
                    j--;
                }
                else
                {
                    minLimitI++;
                    direction = 0;
                }
            }
        }
        return result;
    }
}