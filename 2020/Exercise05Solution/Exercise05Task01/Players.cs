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
            int[] goalCountOfAllClubs = new int[FootballClubInfo.Count];
            #region Count goals in all clubs
            for (int i = 0; i < FootballClubInfo.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < Count; j++)
                {
                    // Check if players belongs to the same club
                    if (Array[j].Club.Equals(FootballClubInfo.GetEnumType(FootballClubInfo.GetNazev(i))))
                    {
                        count += Array[j].GoalCount;
                    }
                }
                if (count > maxCount)
                    maxCount = count;
                goalCountOfAllClubs[i] = count;
            }
            #endregion
            #region Add clubs with the highest number of points 
            int clubCount = 0;
            for (int i = 0; i < goalCountOfAllClubs.Length; i++)
            {
                if (maxCount == goalCountOfAllClubs[i])
                {
                    clubs[clubCount] = FootballClubInfo.GetEnumType(FootballClubInfo.GetNazev(i));
                    clubCount++;
                }
            }
            #endregion
            // Will save the best clubs into a smaller array
            FootballClub[] c = new FootballClub[clubCount];
            for (int i = 0; i < clubCount; i++)
            {
                c[i] = clubs[i];
            }
            return (c, maxCount);
        }
        private void OnCountChanged(int count)
        {
            CountChanged?.Invoke(count);
        }
        public Players(int arrayLength)
        {
            Array = new Player[arrayLength];
        }
    }
}
