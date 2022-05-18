using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism
{
    class RemoteControlCar
    {
        private int battery = 100;
        private int distance = 0;

        public static RemoteControlCar Buy()
        {
            return new RemoteControlCar();
        }

        public string DistanceDisplay()
        {
            return $"Driven {distance} meters";
        }

        public string BatteryDisplay()
        {
            string result = "Battery empty";
            if (battery > 0) result = $"Battery at {battery}%";
            return result;
        }

        public void Drive()
        {
            if (battery == 0) return;
            battery -= 1;
            distance += 20;
        }
    }
}
