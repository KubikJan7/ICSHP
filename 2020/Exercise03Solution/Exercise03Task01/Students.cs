using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03Task01
{
    class Students
    {
        private Student[] Array;
        private int Count;

        public Students(int arrayLength)
        {
            Array = new Student[arrayLength];
        }
        public void AddStudent(Student s)
        {
            Array[Count] = s;
            Count++;
        }
        public void WriteStudents()
        {
            Console.WriteLine("Students:\n");
            for (int i = 0; i < Array.Length; i++)
            {
                Console.WriteLine("Id: " + Array[i].Id + " Name: " + Array[i].Name + " Faculty: " + Array[i].Faculty);
            }
        }
        public void SortById()
        {
            for (int i = 0; i < Array.Length - 1; i++)
            {
                for (int j = 0; j < Array.Length - i - 1; j++)
                {
                    if (Array[j + 1].Id < Array[j].Id)
                    {
                        Student tmp = Array[j + 1];
                        Array[j + 1] = Array[j];
                        Array[j] = tmp;
                    }
                }
            }
            Console.WriteLine("Students were sorted by id");
        }
        public void SortByName()
        {
            for (int i = 0; i < Array.Length - 1; i++)
            {
                for (int j = 0; j < Array.Length - i - 1; j++)
                {
                    if (string.Compare(Array[j + 1].Name, Array[j].Name) == -1)
                    {
                        Student tmp = Array[j + 1];
                        Array[j + 1] = Array[j];
                        Array[j] = tmp;
                    }
                }
            }
            Console.WriteLine("Students were sorted by name");
        }
        public void SortByFaculty()
        {
            for (int i = 0; i < Array.Length - 1; i++)
            {
                for (int j = 0; j < Array.Length - i - 1; j++)
                {
                    if (string.Compare(Array[j + 1].Faculty.ToString(), Array[j].Faculty.ToString()) == -1)
                    {
                        Student tmp = Array[j + 1];
                        Array[j + 1] = Array[j];
                        Array[j] = tmp;
                    }
                }
            }
            Console.WriteLine("Students were sorted by faculty");
        }
    }
}
