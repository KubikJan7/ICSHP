using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise05Task01
{
    public class Player
    {
        public string Name { set; get; }
        public FootballClub Club { set; get; }
        public int GoalCount { set; get; }

        public Player() { }

        public Player(string name, FootballClub club, int goalCount)
        {
            Name = name;
            Club = club;
            GoalCount = goalCount;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Player p = (Player)obj;
            return Name == p.Name && Club == p.Club && GoalCount == p.GoalCount;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}
