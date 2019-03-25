using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaMistru
{
    public class Hrac
    {
        public string Jmeno { get; set; }
        public FotbalovyKlub Klub { get; set; }
        public int GolPocet { get; set; }

        public override string ToString()
        {
            return $"{Jmeno} (klub: {Klub}, golu: {GolPocet})";
        }
    }
}
