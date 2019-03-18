using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise05Task01
{
    public class Players
    {
        public delegate void CountChangedEventHandler();
        public int Count { get; }

        private Player[] Array;
        public event CountChangedEventHandler CountChanged;

        public void Remove(int index)
        {

        }
        public void Add()
        {
        }
        public Player this[int index]
        {
            get => Array[index];
        }
        public FootballClub[] FindBestClubs(FootballClub[] clubs, int goalCount)
        {
            return new FootballClub[5];
        }

    }
}
