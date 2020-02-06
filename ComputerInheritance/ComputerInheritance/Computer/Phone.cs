using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ComputerInheritance.Computer.LogicalItems;
using ComputerInheritance.Computer.Components;
using ComputerInheritance.Computer.Components.Screen;
using ComputerInheritance.Computer.Components.Reciever;

namespace ComputerInheritance.Computer
{
    public class Phone : Computer
    {
        public TouchScreen screen;
        public Camera[] cameras;
        public EMSIReciever reciever;

        public void Lock()
        {
            Console.WriteLine("Mobile phone was locked");
        }

        public void Unlock()
        {
            Console.WriteLine("Mobile phone was unlocked");
        }

        public void SendMessage(Message message)
        {
            Console.WriteLine("Message was sent from mobile phone " + message);
        }

        public void RecieveMessage(Message message)
        {
            Console.WriteLine("Message was recieved on mobile phone " + message);
        }

        public void MakeCall(Contact contact)
        {
            Console.WriteLine("Call was created on mobile phone");
        }

        public void RecieveCall(Contact contact)
        {
            Console.WriteLine("Call was recieved on mobile phone");
        }
    }
}
