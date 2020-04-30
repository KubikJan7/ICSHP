using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03Task01
{
    class Student
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public Faculty Faculty { get; set; }

        public Student(int id, string name, Faculty faculty)
        {
            this.Id = id;
            this.Name = name;
            this.Faculty = faculty;
        }
    }
}
