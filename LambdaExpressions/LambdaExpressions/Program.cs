using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressions
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


        delegate int IntManipulatorDelegate(int i);
        static void opgave1()
        {
            IntManipulatorDelegate del = (i) => i * 2;

            Console.WriteLine(del(10));
        }


        delegate float FloatManipulatorDelegate(params float[] floats);
        static void opgave2()
        {
            FloatManipulatorDelegate del = (f) => f.Sum();

            Console.WriteLine(del(10, 10, 10));
        }


        delegate string StringDelegate();
        static void opgave3()
        {
            StringDelegate del = () => "Hello World";

            Console.WriteLine(del());
        }
    }
}
