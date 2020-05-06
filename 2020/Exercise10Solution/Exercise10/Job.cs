using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise10
{
    public class Job
    {
        public int Id { get; set; }
        public int User { get; set; }
        public int CreationTime { get; set; }
        public int MachineCount { get; set; }
        public int Duration { get; set; }

        public Job(int user,int creationTime, int machineCount, int duration)
        {
            this.User = user;
            this.CreationTime = creationTime;
            this.Duration = duration;
            this.MachineCount = machineCount;
        }

        public override string ToString()
        {
            return (char) Id +" ("+"u:"+ User + ", share:" + MachineCount + ", duration:" + Duration + ", createdat:" + CreationTime + ")";
        }
    }
}
