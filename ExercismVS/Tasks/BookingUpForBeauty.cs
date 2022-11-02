using System.ComponentModel;
using System.Globalization;

namespace Exercism;

using System;
using static DateTimeConverter;

static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        return DateTime.Parse(appointmentDateDescription);
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        return (DateTime.Compare(DateTime.Now, appointmentDate) > 0);
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        return appointmentDate.Hour is >= 12 and < 18;
    }

    public static string Description(DateTime appointmentDate)
    {
        string result = $"You have an appointment on {appointmentDate}.";
        return result;
    }

    public static DateTime AnniversaryDate()
    {
        int year = DateTime.Now.Year;
        return new DateTime(year, 9, 15);
    }
}
