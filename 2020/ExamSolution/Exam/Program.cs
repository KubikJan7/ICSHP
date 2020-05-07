using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Threading;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class Cas :IComparable
    {
        public int Hodiny { get; set; }
        public int Minuty { get; set; }
        public int Sekundy { get; set; }

        public virtual void Vypis()
        {
            Console.WriteLine("Čas");

        }

        public int CompareTo(object obj)
        {
            return this.CompareTo(obj);
        }
    }

    class ZonovyCas :Cas
    {
        public override void Vypis()
        {
            Console.WriteLine("Zonový čas");
        }
    }
}
