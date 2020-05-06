using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise10
{
    class Program
    {
        static void Main(string[] args)
        {
            Planner planner = new Planner();
            List<Job> jobs = new List<Job>();

            var files = Directory.GetFiles("planner");
            int userId = 0;
            foreach (var item in files)
                try
                {
                    jobs.AddRange(Planner.LoadJobsFromFile(userId++,item));
                }
                catch (Exception)
                {
                    Console.WriteLine("A problem was encountered while processing given files.");
                }


            jobs.Sort((a, b) => a.CreationTime - b.CreationTime);
            planner.FirstFit(jobs);
            Console.WriteLine(planner.ToString());
            foreach (var item in jobs)
            {
                Console.WriteLine(item);
            }
            
        }
    }
}
