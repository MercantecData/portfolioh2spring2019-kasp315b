using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassesAndInterfaces
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Opgave1.Opgave1.Run();
            Opgave2.Opgave2.Run();
            Opgave3.Opgave3.Run();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}
