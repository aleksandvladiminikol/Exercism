using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism
{
     class AssemblyLine
     {
        public static double SuccessRate(int speed)
        {
            double result = 0;
            if (speed >= 1 && speed <= 4)
            {
                result = 1;
            }
            else if (speed >= 5 && speed <= 8)
            {
                result = 0.9;
            }
            else if (speed == 9)
            {
                result = 0.8;
            }
            else if (speed == 10)
            {
                result = 0.77;
            }
            return result;
        }

        public static double ProductionRatePerHour(int speed)
        {
            const int countperhour = 221;
            return speed * countperhour * SuccessRate(speed);
        }

        public static int WorkingItemsPerMinute(int speed)
        {
            const int MinutesInHour = 60;
            int result = (int)ProductionRatePerHour(speed) / MinutesInHour;
            return result;
        }
     }
}
