using Exercise06Task01;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise05Task01
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
            Count++;
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
            int[] goalCountOfAllClubs = new int[FootballClubInfo.Count];
            #region Count goals in all clubs
            for (int i = 0; i < FootballClubInfo.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < Count; j++)
                {
                    // Check if players belongs to the same club
                    if (List.GetDataOf(j).Club.Equals(FootballClubInfo.GetEnumType(FootballClubInfo.GetNazev(i))))
                    {
                        count += List.GetDataOf(j).GoalCount;
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
            List = new LinkedList<Player>();
            this.Count = List.Count;
        }
    }
}
