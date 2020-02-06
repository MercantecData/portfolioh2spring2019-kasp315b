using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ComputerInheritance.Computer.Components;
using ComputerInheritance.Computer.Components.Screen;

namespace ComputerInheritance.Computer
{
    public class Smartwatch : Computer
    {
        public TouchScreen screen;
        public Camera camera;

        public void Lock()
        {
            Console.WriteLine("Smartwatch was locked");
        }

        public void Unlock()
        {
            Console.WriteLine("Smartwatch was unlocked");
        }
    }
}
