using System;
public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        var min = 0;
        var max = input.Length - 1;
        while (min < max)
        {
            var currentIndex = (max + min) / 2;
            var currentValue = input[currentIndex];
            if (currentValue > value)
                max = currentIndex - 1;
            else if (currentValue < value)
                min = currentIndex + 1;
            else
                return currentIndex;
        }
        
        return input.Length > 0 && min == max && input[min] == value ? min : -1;
    }
}