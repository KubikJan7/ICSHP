using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSHP_cv03_p_01
{
    delegate void SortCallback();
    class Program
    {
        static void Main(string[] args)
        {
            int option = 10;
            Students students = new Students(0);

            
            while (option != 0)
            {
                SortCallback sortCallback = null;
                Console.Clear();
                Console.WriteLine("Options: ");
                Console.WriteLine("1. Load students.");
                Console.WriteLine("2. Display students.");
                Console.WriteLine("3. Sort students by id.");
                Console.WriteLine("4. Sort students by name.");
                Console.WriteLine("5. Sort students by faculty.");
                Console.WriteLine("0. Close program.");
                Console.WriteLine("\n-------------------------------------------------------------");
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Type in number of students");
                        int.TryParse(Console.ReadLine(), out int arrayLength);
                        students = new Students(arrayLength);
                        for (int i = 0; i < arrayLength; i++)
                        {
                            Console.WriteLine("Type in attributes of student with number: " + (i + 1));
                            Console.Write("Id: ");
                            int.TryParse(Console.ReadLine(), out int id);
                            Console.Write("Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Faculty: ");
                            Faculty.TryParse(Console.ReadLine(), out Faculty f);
                            Student s = new Student(id, name, f);
                            students.AddStudent(s);
                        }
                        break;
                    case 2:
                        students.WriteStudents();
                        break;
                    case 3:
                        sortCallback = students.SortById;
                        break;
                    case 4:
                        sortCallback = students.SortByName;
                        break;
                    case 5:
                        sortCallback = students.SortByFaculty;
                        break;
                }
                sortCallback?.Invoke();
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("\nChoose an option: ");
                int.TryParse(Console.ReadLine(), out option);
            }

        }
    }
}
