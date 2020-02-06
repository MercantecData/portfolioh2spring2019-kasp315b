using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ComputerInheritance.Computer.Components;
using ComputerInheritance.Computer.Components.Storage;

namespace ComputerInheritance.Computer
{
    public class Computer
    {
        public Processor processor;
        public Storage[] memory;
        public Storage[] storage;
        public Port[] IO;

        public void TurnOn()
        {
            Console.WriteLine("Computer was turned on");
        }

        public void TurnOff()
        {
            Console.WriteLine("Computer was turned off");
        }
    }
}
