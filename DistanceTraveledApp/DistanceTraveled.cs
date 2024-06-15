using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceTraveledApp
{
    public class DistanceTraveled
    {
        private double speed;
        private double time;

        public DistanceTraveled(double speed, double time)
        {
            this.speed = speed;
            this.time = time;
        }
        public double GetDistance()
        {
            return speed * time;
        }


        public double GetDistance(int hours)
        {
            return this.speed * hours;
        }
    }

}
