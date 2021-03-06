﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSHP_cv_03.SamplesLibrary
{
    internal class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Person(int iD, string name)
        {
            ID = iD;
            this.Name = name;
        }
        public Person(int iD)
        {
            ID = iD;
        }

        public override string ToString()
        {
            return ID + Name;
        }

        public static implicit operator Person(int v)
        {
            return new Person(v);
        }

        public static implicit operator int(Person person)
        {
            return person.ID;
        }


    }

    public static class ConversionTest
    {
        public static void DoIt()
        {
            Double realNumber = 3.14;
            realNumber = Math.PI;
            realNumber = 10;
            realNumber = 10.0;
            realNumber = (double)10;

            int integerNumber = 3;
            integerNumber = (int)3.14;
            integerNumber = (int)realNumber;
            integerNumber = (int)Math.PI;

            Person person = new Person(1);
            Person person02 = (Person)integerNumber;
            int integerNumber2 = person02; //OK

            Object person2 = new Person(2);
            (person2 as Person).Name = "Jarda";
            if (person2 is Person)

                if (person2 is Person person3)
                {

                }
            //if(person2.GetType() == typeof(Person))
            //{

            //}
        }
    }
}
