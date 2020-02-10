using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpsummeringUge1.RettetTIl
{
    public class HourlyPaidJob : Job
    {
        private int HourlyPay;

        public override int GetMonthlyPay()
        {
            return HourlyPay * 8 * 31; // pay * work hours per day * days in month
        }
    }
}
