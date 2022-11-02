using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism
{
    static class Leap
    {
        public static bool IsLeapYear(int year)
        {
            double double_year = (double)year;
            return (double_year % 4 == 0 && double_year % 100 != 0 || double_year % 400 == 0);
        }
    }
}
