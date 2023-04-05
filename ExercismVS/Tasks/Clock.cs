using System;

public class Clock : IEquatable<Clock>
{
    public int Hours { get; private set; }
    public int Minutes { get; private set; }

    public Clock(int hours, int minutes)
    {
        var time = AdaptTime(hours, minutes);
        Hours = time.hours;
        Minutes = time.minutes;
    }
    
    private static int ChangeHours(int hours, int addHours)
    {
        var result = hours + addHours;
        result = result switch
        {
            < 0 => result % 24 + 24,
            > 23 => result % 24,
            _ => result
        };

        return result;
    }
    private static (int hours, int minutes) AdaptTime(int hours, int minutes)
    {
        var resultHours = ChangeHours(hours, 0);
        resultHours = ChangeHours(resultHours, minutes / 60);
        var resultMinutes = minutes % 60;
        if (resultMinutes >= 0) return (resultHours, resultMinutes);
        resultMinutes = minutes % 60 + 60; 
        resultHours = ChangeHours(resultHours, -1);
        return (resultHours, resultMinutes);
    }

    public bool Equals(Clock? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Hours == other.Hours && Minutes == other.Minutes;
    }

    public override string ToString()
    {
        return $"{Hours:00}:{Minutes:00}";
    }
    
    public Clock Add(int minutesToAdd)
    {
        var time = AdaptTime(Hours, Minutes + minutesToAdd);
        return new Clock(time.hours, time.minutes);
    }

    public Clock Subtract(int minutesToSubtract)
    {
        var time = AdaptTime(Hours, Minutes - minutesToSubtract);
        return new Clock(time.hours, time.minutes);
    }
    
    public int GetHashCode(Clock obj)
    {
        return HashCode.Combine(obj.Hours, obj.Minutes);
    }
}
