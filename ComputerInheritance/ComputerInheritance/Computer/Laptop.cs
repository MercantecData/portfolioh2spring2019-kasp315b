using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ComputerInheritance.Computer.Components;
using ComputerInheritance.Computer.Components.Screen;

namespace ComputerInheritance.Computer
{
    public class Laptop : Computer
    {
        public Screen screen;
        public Camera camera;
        public Touchpad touchpad;

        public void OpenLid()
        {
            Console.WriteLine("Laptop lid was opened");
        }

        public void CloseLid()
        {
            Console.WriteLine("Laptop lid was closed");
        }
    }
}
