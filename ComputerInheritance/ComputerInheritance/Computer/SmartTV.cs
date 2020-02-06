using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ComputerInheritance.Computer.LogicalItems;
using ComputerInheritance.Computer.Components.Screen;
using ComputerInheritance.Computer.Components.Reciever;

namespace ComputerInheritance.Computer
{
    public class SmartTV : Computer
    {
        public Screen screen;
        public TVSignalReciever signalReciever;
        public InfraredSignalReciever infraredSignalReciever;

        public void ChangeChannel(Channel channel)
        {
            Console.WriteLine("Channel was changed on SmartTV to " + channel);
        }
    }
}
