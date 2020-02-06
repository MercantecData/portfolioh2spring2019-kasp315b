using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassesAndInterfaces.Opgave2
{
    public class Opgave2
    {
        public static void Run()
        {
            Console.WriteLine("\nOPGAVE 2:\n\n");

            Dog dog = new Dog();
            dog.SetName("Berry");
            Console.WriteLine($"The dogs name is {dog.GetName()}");
            Console.WriteLine($"The dogs old name is {dog.ReplaceName("Betty")} but is now named {dog.GetName()}.");

            Bird bird = new Bird();
            bird.SetName("Pippy");
            Console.WriteLine($"The birds name is {bird.GetName()}");
            Console.WriteLine($"The birds old name is {bird.ReplaceName("Darth Plagueis the wise")} but is now named {bird.GetName()}.");
        }
    }

    public interface INameable
    {
        string GetName();
        void SetName(string name);
        string ReplaceName(string name);
    }

    public class Dog : INameable
    {
        private string name;

        public Dog()
        {
            SetName("Nameless");
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string ReplaceName(string name)
        {
            string oldName = this.name;
            this.name = name;
            return oldName;
        }
    }

    public class Bird : INameable
    {
        private string name;

        public Bird()
        {
            SetName("Nameless");
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string ReplaceName(string name)
        {
            string oldName = this.name;
            this.name = name;
            return oldName;
        }
    }
}
