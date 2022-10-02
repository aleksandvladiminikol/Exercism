namespace Exercism;

using System;
public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    private readonly int _month;
    private readonly int _year;
    private readonly int _teenthMin = 13;
    private readonly int _teenthMax = 19;

    public Meetup(int month, int year)
    {
        _month = month;
        _year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        var currentSchedule = 1;
        var result = new DateTime(_year, _month, currentSchedule);
        var expectedSchedule = schedule.GetHashCode();
        
        while (result.DayOfWeek != dayOfWeek || currentSchedule != expectedSchedule)
        {
            if (result.DayOfWeek != dayOfWeek)
            {
                result = result + TimeSpan.FromDays(1);
                continue;
            }

            var preResult = result + TimeSpan.FromDays(7);
            
            if (preResult.Month != _month)
                break;
            
            if ((currentSchedule < expectedSchedule) || (expectedSchedule == 0 &&
                                                         (result.Day < _teenthMin || result.Day > _teenthMax)))
            {
                result = preResult;
                currentSchedule++;
            }
            else
            {
                break;
            }
        }
        return result;
    }
}