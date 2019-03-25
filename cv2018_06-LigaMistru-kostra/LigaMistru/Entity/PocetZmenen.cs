using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaMistru
{
    public delegate void PocetZmenenEventHandler(object sender, PocetZmenenEventArgs args);

    public class PocetZmenenEventArgs: EventArgs
    {
        public int PuvodniPocet { get; set; }
    }
}
