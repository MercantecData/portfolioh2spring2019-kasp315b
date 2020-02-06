using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassesAndInterfaces.Opgave3
{
    public class Opgave3
    {
        public static void Run()
        {
            Console.WriteLine("\nOPGAVE 3:\n\n");

            List<Person> unsorted = new List<Person>();
            unsorted.Add(new Person("Alberte", 28, Sex.Female));
            unsorted.Add(new Person("Sigurd", 21, Sex.Male));
            unsorted.Add(new Person("Liv", 22, Sex.Female));
            unsorted.Add(new Person("Kasper", 20, Sex.Male));
            unsorted.Add(new Person("Viktor", 18, Sex.Male));
            unsorted.Add(new Person("Logan", 18, Sex.Male));
            unsorted.Add(new Person("Susanne", 17, Sex.Female));
            unsorted.Add(new Person("Willy", 25, Sex.Male));
            unsorted.Add(new Person("Tove", 55, Sex.Female));
            unsorted.Add(new Person("Shaq", 33, Sex.Male));

            unsorted.Add(new Person("Kim", 22, Sex.Male));
            unsorted.Add(new Person("Kim", 23, Sex.Male));
            unsorted.Add(new Person("Kim", 22, Sex.Female));

            Console.WriteLine("Unsorted:");
            foreach (var p in unsorted) p.WhoAmI();

            List<Person> sorted = unsorted.ToList();
            sorted.Sort();

            Console.WriteLine("\n\nSorted:");
            foreach (var p in sorted) p.WhoAmI();

        }
    }

    public class Person : IComparable
    {
        public string Name { private set; get; }
        public int Age { private set; get; }
        public Sex Sex { private set; get; }

        public Person(string name, int age, Sex sex)
        {
            Name = name;
            Age = age;
            Sex = sex;
        }

        public void WhoAmI()
        {
            Console.WriteLine($"My name is {Name}, I am {Age} years old. I am {Enum.GetName(typeof(Sex), Sex)}");
        }

        public int CompareTo(Object p)
        {
            Person person = (Person)p;

            int result;

            result = Name.CompareTo(person.Name);
            
            if(result == 0) result = Age - person.Age;

            if (result == 0) result = Sex.CompareTo(person.Sex);

            return result;
        }

        /* Sorter efter alder, yngste først
        public int CompareTo(Object p) {
            Person person = (Person)p;
            return Age - person.Age;
        }
        */
    }

    public enum Sex // Don't tell anyone https://i.imgur.com/SIzEPHS.png
    {
        Male = 1,
        Female = 0
    }
}
