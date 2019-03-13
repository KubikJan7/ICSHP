using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSHP_cv03_p_01
{
    class Student
    {
        private string name;
        private int id;
        private Faculty faculty;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public Faculty Faculty
        {
            get { return faculty; }
            set { faculty = value; }
        }

        public Student(int id, string name, Faculty faculty)
        {
            this.id = id;
            this.name = name;
            this.faculty = faculty;
        }
    }
}
