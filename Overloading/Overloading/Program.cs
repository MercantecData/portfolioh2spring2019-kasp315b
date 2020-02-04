using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloading
{
    class Program
    {
        static void Main(string[] args)
        {
            // Nice
        }
    }

    public class MyMath
    {
        public static int Plus(int i1, int i2)
        {
            return i1 + i2;
        }

        public static float Plus(float f1, float f2)
        {
            return f1 + f2;
        }

        public static double Plus(string s1, string s2)
        {
            return double.Parse(s1) + double.Parse(s2);
        }

        public static int Minus(int i1, int i2)
        {
            return i1 - i2;
        }

        public static float Minus(float f1, float f2)
        {
            return f1 - f2;
        }

        public static double Minus(string s1, string s2)
        {
            return double.Parse(s1) - double.Parse(s2);
        }

        public static int Divider(int i1, int i2)
        {
            return i1 / i2;
        }

        public static float Divider(float f1, float f2)
        {
            return f1 / f2;
        }

        public static double Divider(string s1, string s2)
        {
            return double.Parse(s1) / double.Parse(s2);
        }

        public static int Gange(int i1, int i2)
        {
            return i1 * i2;
        }

        public static float Gange(float f1, float f2)
        {
            return f1 * f2;
        }

        public static double Gange(string s1, string s2)
        {
            return double.Parse(s1) * double.Parse(s2);
        }

        public static int KvadratRod(int i)
        {
            return (int)Math.Sqrt(i);
        }

        public static float KvadratRod(float f)
        {
            return (float)Math.Sqrt(f);
        }

        public static double KvadratRod(string s)
        {
            return Math.Sqrt(double.Parse(s));
        }

        public static int Potens(int i1, int i2)
        {
            return (int)Math.Pow(i1, i2);
        }

        public static float Potens(float f1, float f2)
        {
            return (float)Math.Pow(f1, f2);
        }

        public static double Potens(string s1, string s2)
        {
            return Math.Pow(double.Parse(s1), double.Parse(s2));
        }
    }
}
