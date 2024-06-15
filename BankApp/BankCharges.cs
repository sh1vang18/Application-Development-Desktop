using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class BankCharges
    {
        private const decimal ServiceCharge = 10.00m; // Monthly service charge
        private const decimal CheckFeeBelow20 = 0.10m; // Fee per check for less than 20 checks
        private const decimal CheckFee20to39 = 0.08m; // Fee per check for 20 to 39 checks
        private const decimal CheckFee40to59 = 0.06m; // Fee per check for 40 to 59 checks
        private const decimal CheckFee60Above = 0.04m; // Fee per check for 60 or more checks

        private decimal endingBalance;
        private int numChecksWritten;

        public BankCharges(decimal balance, int checksWritten)
        {
            endingBalance = balance;
            numChecksWritten = checksWritten;
        }
        public decimal CalculateCheckFees()
        {
            decimal totalCheckFees = 0.0m;

            if (numChecksWritten < 20)
            {
                totalCheckFees = numChecksWritten * CheckFeeBelow20;
            }
            else if (numChecksWritten <= 39)
            {
                totalCheckFees = numChecksWritten * CheckFee20to39;
            }
            else if (numChecksWritten <= 59)
            {
                totalCheckFees = numChecksWritten * CheckFee40to59;
            }
            else
            {
                totalCheckFees = numChecksWritten * CheckFee60Above;
            }
            return totalCheckFees;
        }

        public decimal CalculateServiceCharges()
        {

            decimal totalCheckFees = CalculateCheckFees();
            decimal serviceCharges = ServiceCharge;

            if (endingBalance < 400.00m)
            {
                serviceCharges += 15.00m; // Additional $15 fee if balance falls below $400
            }

            return serviceCharges + totalCheckFees;
        }
    }

}
