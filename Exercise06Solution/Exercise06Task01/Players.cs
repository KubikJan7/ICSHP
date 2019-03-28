using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise06Task01
{
    public class Players
    {
        public delegate void CountChangedEventHandler(int count);
        public int Count { set; get; }

        private LinkedList<Player> List;
        public event CountChangedEventHandler CountChanged;

        public void Remove(int index)
        {
            OnCountChanged(Count);
            List.RemoveAt(index);
            Count = List.Count;
        }
        public void Add(Player p)
        {
            OnCountChanged(Count);
            List.Add(p);
            Count = List.Count;
        }
        public Player this[int index]
        {
            get => List.GetDataOf(index);
            set
            {
                List.GetDataOf(index).Name = value.Name;
                List.GetDataOf(index).Club = value.Club;
                List.GetDataOf(index).GoalCount = value.GoalCount;
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
                    if (List.GetDataOf(j).Club.Equals(FootballClubInfo.GetEnumType(FootballClubInfo.GetNazev(i))))
                    {
                        count += List.GetDataOf(j).GoalCount;
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
        public Players()
        {
            List = new LinkedList<Player>();
            this.Count = List.Count;
        }
    }
}
