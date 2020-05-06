using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise10
{
    public class Planner
    {
        private const int MACHINE_COUNT = 8;
        private const int TIME_SLOTS = 100;
        private Job[,] jobPlan;
        private int idCounter;
        public Planner()
        {
            jobPlan = new Job[MACHINE_COUNT, TIME_SLOTS];
            idCounter = 'A';
        }

        public int GetId
        {
            get
            {
                if (idCounter > 'Z')
                    idCounter = 'a';
                else if (idCounter > 'z')
                    idCounter = 'A';

                return idCounter++;
            }
        }

        public void FirstFit(List<Job> jobs)
        {
            foreach (var item in jobs)
            {
                List<int> machines = new List<int>();
                int num = 0;
                for (int i = 0; i < MACHINE_COUNT; i++)
                {
                    machines.Add(i);
                }

                for (int i = 0; i < TIME_SLOTS; i++)
                {
                    List<int> tempMachines = new List<int>();
                    for (int j = 0; j < MACHINE_COUNT; j++)
                    {
                        if (jobPlan[j, i] != null) // Slot contains a task
                            machines.Remove(j); // Machine starts to work on the task
                        else if (!machines.Contains(j))
                            tempMachines.Add(j);
                    }
                    num++;

                    if (machines.Count < item.MachineCount)
                    {
                        if (machines.Count + tempMachines.Count >= item.MachineCount)
                        {
                            num = 1;
                            machines.AddRange(tempMachines);
                        }
                        else
                        {
                            num = 0;
                            machines.Clear();
                            for (int k = 0; k < MACHINE_COUNT; k++)
                            {
                                machines.Add(k);
                            }
                        }
                    }

                    if(num == item.Duration)
                    {
                        int t = i - num + 1;

                        AddToJobPlan((t < 0) ? 0 : t, machines, item);
                        break;
                    }
                }

            }
        }

        public void AddToJobPlan(int num, List<int> machines, Job job)
        {
            for (int i = 0; i < job.Duration; i++)
            {
                int add = 0;
                foreach (var item in machines)
                {
                    if(add<job.MachineCount)
                    {
                        jobPlan[num, i + num] = job;
                        add ++;
                    }
                }
            }
            job.Id = GetId;
        }

        public static List<Job> LoadJobsFromFile(int user, string fileName)
        {
            List<Job> jobs = new List<Job>();
            using (StreamReader file = new StreamReader(fileName))
            {
                string ln;
                string[] words;

                while ((ln = file.ReadLine()) != null)
                {
                    words = ln.Split(',');
                    int.TryParse(words[1], out int creationTime);
                    int.TryParse(words[2], out int machineCount);
                    int.TryParse(words[3], out int time);

                    Job job = new Job(user, creationTime, machineCount, time);
                    jobs.Add(job);
                    jobs.Sort((a, b) => a.CreationTime - b.CreationTime);
                }
                file.Close();
            }
            return jobs;
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < MACHINE_COUNT; i++)
            {
                for (int j = 0; j < TIME_SLOTS; j++)
                {
                    if (jobPlan[i, j] == null)
                        str += '-';
                    else
                        str += (char)jobPlan[i, j].Id;
                }
                str += "\n";
            }
            return str;
        }
    }
}
