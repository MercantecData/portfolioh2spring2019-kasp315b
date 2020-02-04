using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            opgave1();
            opgave2();
            opgave3();

            Console.ReadLine();
        }

        public static void opgave1()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            for(int i = 0; i < 10; i++)
            {
                dictionary[$"num{i}"] = i;
            }

            foreach (KeyValuePair<string, int> kvp in dictionary) Console.WriteLine($"{kvp.Key} : {kvp.Value}");
        }

        public static void opgave2()
        {
            Dictionary<float, bool> dictionary = new Dictionary<float, bool>();

            for(int i = 0; i < 10; i++)
            {
                dictionary[i] = Math.Pow(i, i) % 10 > 5;
            }

            foreach (KeyValuePair<float, bool> kvp in dictionary) Console.WriteLine($"{kvp.Key} : {kvp.Value}");
        }

        public static void opgave3()
        {
            Dictionary<Student, bool> dictionary = new Dictionary<Student, bool>();

            Student kasper = new Student("Kasper", 20);
            Student logan = new Student("Logan", 18);
            Student viktor = new Student("Viktor", 8);
            Student sebastian = new Student("Sebastian", 25);

            dictionary[kasper] = true;
            dictionary[logan] = false;
            dictionary[viktor] = true;
            dictionary[sebastian] = false;

            foreach (KeyValuePair<Student, bool> kvp in dictionary) Console.WriteLine($"{kvp.Key} : {kvp.Value}");
        }
    }

    public class Student
    {
        public string Name;
        public int Age;

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return base.ToString() + $":{{Name:{Name}, Age:{Age}}}";
        }
    }
}
