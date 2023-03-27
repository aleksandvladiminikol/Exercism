using System;
using System.Linq;
public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        return number
            .ToString()
            .Select(
                _ => (int) Math.Pow(
                    char.GetNumericValue(_), 
                    number.ToString().Length)
                )
            .Sum() 
               == number;
    }
}