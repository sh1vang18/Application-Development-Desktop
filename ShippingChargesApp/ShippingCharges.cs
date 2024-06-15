using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingChargesApp
{
    public class ShippingCharges
    {
        private const decimal RateBelow2kg = 1.10m;
        private const decimal Rate2to6kg = 2.20m;
        private const decimal Rate6to10kg = 3.70m;
        private const decimal RateAbove10kg = 4.80m;

        public ShippingCharges(decimal weight, int distanceMiles)
        {
            Weight = weight;
            DistanceMiles = distanceMiles;
        }

        public decimal Weight { get; set; }
        public int DistanceMiles { get; set; }

        public decimal CalculateCharges()
        {
            decimal baseRate = 0.0m;

            if (Weight <= 2.0m)
            {
                baseRate = RateBelow2kg;
            }
            else if (Weight <= 6.0m)
            {
                baseRate = Rate2to6kg;
            }
            else if (Weight <= 10.0m)
            {
                baseRate = Rate6to10kg;
            }
            else
            {
                baseRate = RateAbove10kg;
            }

            int segments = (DistanceMiles + 499) / 500;
            decimal totalCharge = baseRate * segments;

            return totalCharge;
           
        }
    }

}
