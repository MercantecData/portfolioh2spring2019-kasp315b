using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KHHAHashMap;

namespace AccessModifiers
{
    public class Registry
    {
        private List<Person> people;
        private HashMap<Person, List<Bike>> bikeOwnerships;

        public Registry()
        {
            people = new List<Person>();
            bikeOwnerships = new HashMap<Person, List<Bike>>(50);
        }
        
        public void AddBikeToPerson(Person person, Bike bike)
        {
            if (bikeOwnerships[person] == null) bikeOwnerships[person] = new List<Bike>(); // Create list if null

            if(!bikeOwnerships[person].Contains(bike)) // Dont add the same bike more than once
            {
                bikeOwnerships[person].Add(bike);
            }
        }

        public void RemoveBikeFromPerson(Person person, Bike bike)
        {
            if(bikeOwnerships[person] != null) // Dont try to remove a bike from a non-existent list
            {
                bikeOwnerships[person].Remove(bike);
            }
        }

        public ICollection<Bike> GetPersonsBikes(Person person)
        {
            if(bikeOwnerships[person] != null)
            {
                return bikeOwnerships[person].AsReadOnly();
            }
            else
            {
                return null;
            }
        }

        public void AddPerson(Person person)
        {
            people.Add(person);
        }

        public bool RemovePerson(Person person)
        {
            return people.Remove(person);
        }

        public ICollection<Person> GetPeople()
        {
            return people.AsReadOnly();
        }
    }
}
