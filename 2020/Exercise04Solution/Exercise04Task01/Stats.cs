using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04Task01
{
    public delegate void UpdatedStatsEventHandler(object sender, EventArgs e);
    public class Stats
    {
        public int Correct { get; private set; }
        public int Missed { get; private set; }
        public double Accuracy { get; private set; }
        public event UpdatedStatsEventHandler UpdatedStats;

        private void OnUpdatedStats()
        {
            UpdatedStats?.Invoke(this, new EventArgs());
        }

        public void Update(bool correctKey)
        {
            if (correctKey)
                Correct++;
            else
                Missed++;

            double inTotal = Correct + Missed;
            Accuracy = Math.Round(Correct / (inTotal) * 100);
            OnUpdatedStats();
        }
    }
}
