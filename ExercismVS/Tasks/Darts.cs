namespace Exercism;

public static class Darts
{
    public static int Score(double x, double y)
    {

        var length = getLength(x, y); 
        
        if (length > 10)
        {
            return 0;
        }
        else if (length > 5 && length <= 10)
        {
            return 1;
        }
        else if (length > 1 && length <= 5)
        {
            return 5;
        }
        else
        {
            return 10;
        }
        
    }

    public static double getLength(double x, double y)
    {
        return Math.Sqrt(x * x + y * y);
    }
    
}