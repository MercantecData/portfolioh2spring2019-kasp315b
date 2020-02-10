using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpsummeringUge1.RettetTIl
{
    public class DailyPaidJob : Job
    {
        private int DailyPay;

        public override int GetMonthlyPay()
        {
            return DailyPay * 31; // pay * days in month
        }
    }
}
