using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise05Task01
{
    public static class FootballClubInfo
    {
        readonly public static int Count = 6;

        public static string GetNazev(int constant)
        {
            return ((FootballClub)constant).ToString().Replace("_", " ");
        }

        public static FootballClub GetEnumType(string nazev)
        {
            Enum.TryParse(nazev.Replace(" ", "_"), out FootballClub enumType);
            return enumType;
        }
    }
}
