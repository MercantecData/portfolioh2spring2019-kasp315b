using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    public class Person
    {
        public string Name { private set; get; }
        public int Age { private set; get; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void SetAge(int age)
        {
            Age = age;
        }
    }
}
