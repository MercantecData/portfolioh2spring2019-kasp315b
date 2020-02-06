using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassesAndInterfaces.Opgave1
{
    public class Opgave1
    {
        public static void Run()
        {
            Console.WriteLine("\nOPGAVE 1:\n\n");

            Car prius = new ToyotaPrius();
            prius.Drive();
            prius.Brake();

            Car berlingo = new CitroenBerlingo();
            berlingo.Drive();
            berlingo.Brake();

            Car punto = new FiatPunto();
            punto.Drive();
            punto.Brake();
        }
    }

    public abstract class Car
    {
        public string Manufacturer { private set; get; }
        public string Model { private set; get; }
        public double TopSpeed { private set; get; }
        public double Weight { private set; get; }
        public double FueltankCapacity { private set; get; }
        public int GearCount { private set; get; }

        public Car(string manufacturer, string model, double topSpeed, double weight, double fueltankCapacity, int gearCount)
        {
            Manufacturer = manufacturer;
            Model = model;
            TopSpeed = topSpeed;
            Weight = weight;
            FueltankCapacity = fueltankCapacity;
            GearCount = gearCount;
        }

        public abstract void Drive();
        public void Brake()
        {
            Console.WriteLine($"The {Manufacturer} {Model} brakes.");
        }
    }

    public class ToyotaPrius : Car
    {
        public ToyotaPrius() : base("Toyota", "Prius 2019", 180.0F, 1395.0F, 0.0F, 0)
        {
        }

        public override void Drive()
        {
            Console.WriteLine($"The {Manufacturer} {Model} doesn't make much noise, as it's an electric.");
        }
    }

    public class FiatPunto : Car
    {
        public FiatPunto() : base("Fiat", "Punto 1999", 172.0F, 910.0F, 47.0F, 6)
        {
        }

        public override void Drive()
        {
            Console.WriteLine($"The {Manufacturer} {Model} goes wroom, but it's kind of depressing. It's not fast.");
        }
    }

    public class CitroenBerlingo : Car
    {
        public CitroenBerlingo() : base("Citroen", "Berlingo 1997", 160.0F, 1145.0F, 55.0F, 6)
        {
        }

        public override void Drive()
        {
            Console.WriteLine($"The {Manufacturer} {Model} goes mmMMMMm. It really isn't impressing anyone.");
        }
    }
}
