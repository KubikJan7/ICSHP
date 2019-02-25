using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class ComplexNumber
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int? Third { get; set; }

        public ComplexNumber()
        {

        }
        public ComplexNumber(int first, int second)
        {
            First = first;
            Second = second;
        }
        public ComplexNumber(int first, int second, int? third)
        {
            First = first;
            Second = second;
            Third = third;
        }
        public ComplexNumber(ComplexNumber source)
        {
            First = source.First;
            Second = source.Second;
        }
        public override string ToString()
        {
            //return "[" + First.ToString() + "; " + Second.ToString() + "]";
            return "[" + First + "; " + Second + "; " + Third + "]";
        }
    }
}
