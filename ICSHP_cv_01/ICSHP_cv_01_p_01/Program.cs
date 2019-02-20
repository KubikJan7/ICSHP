using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSHP_cv_01_p_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Address a = new Address();
            a.Street = "Jindřišská";
            a.Number = "16";
            a.City = "Praha 1";
            a.Postcode = "111 50";

            Person p = new Person();
            p.FirstName = "Josef";
            p.LastName = "Novák";
            p.Address = a;

            Console.WriteLine(p.FirstName + " " + p.LastName);
            Console.WriteLine(p.Address.Street + " " + p.Address.Number);
            Console.WriteLine(p.Address.Postcode + ", " + p.Address.City);
        }
    }

    class Person
    {
        public string FirstName;
        public string LastName;
        public Address Address;
    }
    class Address
    {
        public string Street;
        public string Number;
        public string City;
        public string Postcode;
    }
}
