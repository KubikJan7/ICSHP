using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            Person @for = new Person("Josef", "Novák", new Address("Jindrišská", 16, "Praha 1", "111 50"));
            Console.WriteLine($"{ @for.FirstName} {@for.LastName}\n{@for.Address.Street} {@for.Address.Number}");
            Console.Write($"{@for.Address.Postcode}, {@for.Address.City}");
        }
    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }

        public Person(string firstName, string lastName, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }
    }
    class Address
    {
        public string Street;
        public int Number;
        public string City;
        public string Postcode;

        public Address(string street, int number, string city, string postcode)
        {
            Street = street;
            Number = number;
            City = city;
            Postcode = postcode;
        }
    }
}
