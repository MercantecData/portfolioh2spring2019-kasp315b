using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            opgave1();
            opgave2();
            opgave3();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }


        public delegate void opgave1_delegate();
        public static void opgave1()
        {
            opgave1_delegate del = () => Console.WriteLine("Opgave 1 delegate blev kaldt.");

            del();
        }


        public delegate float opgave2_delegate();
        public static void opgave2()
        {
            opgave2_delegate del = () => 1.0F;

            Console.WriteLine($"Opgave 2 delegate blev kaldt: {del()}");
        }


        public delegate void opgave3_delegate(string s1, string s2, string s3);
        public static void opgave3()
        {
            opgave3_delegate del = (s1, s2, s3) => Console.WriteLine($"Opgave 3 delegate blev kaldt {{1:{s1}, 2:{s2}, 3:{s3}}}");

            del("First", "Second", "Third");
        }
    }
}
