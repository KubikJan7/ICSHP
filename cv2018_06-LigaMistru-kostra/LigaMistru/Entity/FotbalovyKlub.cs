using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaMistru
{
    public enum FotbalovyKlub
    {
        None,
        FCPorto,
        Arsenal,
        RealMadrid,
        Chelsea,
        Barcelona
    }

    public static class FotbalovyKlubInfo
    {
        public static readonly int Pocet = Enum.GetValues(typeof(FotbalovyKlub)).Length;

        public static string DejNazev(FotbalovyKlub fotbalovyKlub)
        {
            switch (fotbalovyKlub)
            {
                case FotbalovyKlub.None:
                    return "";

                case FotbalovyKlub.FCPorto:
                    return "FC Porto";

                case FotbalovyKlub.Arsenal:
                    return "Arsenal";

                case FotbalovyKlub.RealMadrid:
                    return "Real Madrid";

                case FotbalovyKlub.Chelsea:
                    return "Chelsea";

                case FotbalovyKlub.Barcelona:
                    return "Barcelona";
            }

            throw new Exception("Neplatna volba");
        }
    }


}
