 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ComputerInheritance.Computer.Components;
using ComputerInheritance.Computer.Components.Storage;
using ComputerInheritance.Computer.PhysicalItems;

namespace ComputerInheritance.Computer
{
    public class GamingConsole : Computer
    {
        public Storage internalStorage;
        public DiscReader discReader;
        public Controller controller;

        public void ChangeDisc(Disc disc)
        {
            Console.WriteLine("Disc was changed in gaming console");
        }
    }
}
