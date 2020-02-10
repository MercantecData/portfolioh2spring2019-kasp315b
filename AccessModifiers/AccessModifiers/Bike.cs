using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    public class Bike
    {
        public string Model { private set; get; }
        public string Manufacturer { private set; get; }

        public Bike(string model, string manufacturer)
        {
            Model = model;
            Manufacturer = manufacturer;
        }
    }
}
