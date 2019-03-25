using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise05Task01
{
    public class Players
    {
        public delegate void CountChangedEventHandler(int count);
        public int Count { set; get; }

        private Player[] Array;
        public event CountChangedEventHandler CountChanged;

        public void Remove(int index)
        {
            OnCountChanged(Count);
            Array[index] = Array[--Count];
            Array[Count] = null;
        }
        public void Add(Player p)
        {
            OnCountChanged(Count);
            Array[Count] = p;
            Count++;
        }
        public Player this[int index]
        {
            get => Array[index];
            set
            {
                Array[index].Name = value.Name;
                Array[index].Club = value.Club;
                Array[index].GoalCount = value.GoalCount;
            }
        }
        public (FootballClub[], int) FindBestClubs()
        {
            FootballClub[] clubs = new FootballClub[FootballClubInfo.Count];
            int maxCount = 0;
            int[] playerCount = new int[FootballClubInfo.Count];
            #region Count players in all clubs
            for (int i = 0; i < FootballClubInfo.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < Count; j++)
                {
                    if (Array[j].Club.Equals(FootballClubInfo.GetEnumType(FootballClubInfo.GetNazev(i))))
                    {
                        count += Array[j].GoalCount;
                    }
                }
                if (count > maxCount)
                    maxCount = count;
                playerCount[i] = count;
            }
            #endregion
            #region Add clubs with the highest number of players 
            int clubsCount = 0;
            for (int i = 0; i < playerCount.Length; i++)
            {
                if (maxCount == playerCount[i])
                {
                    clubs[clubsCount] = FootballClubInfo.GetEnumType(FootballClubInfo.GetNazev(i));
                    clubsCount++;
                }
            }
            #endregion
            FootballClub[] c = new FootballClub[clubsCount];
            for (int i = 0; i < clubsCount; i++)
            {
                c[i] = clubs[i];
            }
            return (c, maxCount);
        }
        private void OnCountChanged(int count)
        {
            CountChanged?.Invoke(Count);
        }
        public Players(int arrayLength)
        {
            Array = new Player[arrayLength];
        }
    }
}
