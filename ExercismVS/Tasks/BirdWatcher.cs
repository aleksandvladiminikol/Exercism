using System.Diagnostics;

namespace Exercism;

using System;

class BirdCount
{
    private int[] birdsPerDay;
    private int Day = 0;
    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        int[] result = new int[] { 0, 2, 5, 3, 7, 8, 4 };
        return result;
    }

    public int Today()
    {
        return birdsPerDay[^(Day+1)];
    }

    public void IncrementTodaysCount()
    {
        birdsPerDay[^(Day+1)] += 1;
    }

    public bool HasDayWithoutBirds()
    {
        foreach (var VARIABLE in birdsPerDay)
        {
            if (VARIABLE == 0)
            {
                return true;
            }
        }

        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int sum = 0;
        for (int i = 0; i < numberOfDays; i++)
        {
            sum += birdsPerDay[i];
        }

        return sum;
    }

    public int BusyDays()
    {
        int count = 0;
        foreach (var VARIABLE in birdsPerDay)
        {
            if (VARIABLE >= 5)
            {
                count++;
            }
        }

        return count;
    }
}
