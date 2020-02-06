using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ComputerInheritance.Computer.Components;

namespace ComputerInheritance.Computer
{
    public class Desktop : Computer
    {
        public Case pcCase;
        public ATXPowersupply powersupply;
        public CoolingSystem cooler;
    }
}
