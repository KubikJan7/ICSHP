using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Source : https://www.hackerrank.com/challenges/jack-goes-to-rapture/problem
 * 
 * Jack has just moved to a new city called Rapture. He wants to use the public public transport system. The fare rules are as follows:

    1. Each pair of connected stations has a fare assigned to it regardless of direction of travel.
    2. If a passenger travels from station A to station B, he only has to pay the difference between the fare from A to B and the 
       cumulative fare that he has paid to reach station A [fare(A,B) - total fare to reach station A]. If the difference is negative, he 
       can travel free of cost from A to B.

 * Jack is low on cash and needs your help to figure out the most cost efficient way to go from the first station to the last station. 
 * Given the number of stations g_nodes  (numbered from 1 to g_nodes), and the fare between the g_edges pairs of stations 
 * that are connected, determine the lowest fare from station 1 to station g_nodes.
 * 
 * For example, there are g_nodes = 4 stations with undirected connections at the costs indicated:

                                                             2
                                                          -    -
                                                  (20) -          -  (30)
                                                    -               -
                                                  1                   4
                                                    -               -
                                                       -          - (40)
                                                    (5)   -     -
                                                             3
                                                             

 * Travel from station 1 -> 2 -> 4 costs 20 for the first segment (1 -> 2) then the cost differential, an additional 30 - 20 = 10
 * for the remainder. The total cost is 30. Travel from station 1 -> 3 -> 4 costs 5 for the first segment, then an additional  
 * 40 - 5 = 35 for the remainder, a total cost of 40. The lower priced option costs 30.
 * 
 * The program should print the cost of the lowest priced route from station 1 to station g_nodes. If there is no route, print NO PATH EXISTS.


*/
namespace JackGoesToRapture
{
    class Program
    {
        static List<int> ReadFromBinaryFile(string fileName)
        {
            using (BinaryReader binReader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                List<int> intAr = new List<int>();
                while (binReader.BaseStream.Position != binReader.BaseStream.Length)
                {
                    intAr.Add(binReader.ReadInt32());
                }
                return intAr;
            }
        }

        public static void getCost(int gNodes, List<int> gFrom, List<int> gTo, List<int> gWeight)
        {
            List<int> weightSums = new List<int>();
            List<int> gToUsed = new List<int>();
            for (int i = 0; i < gFrom.Count; i++)
            {
                if (gFrom[i] == 1)
                {
                    weightSums.Add(gWeight[i]);
                    gToUsed.Add(gTo[i]);
                }
            }

            for (int i = 0; i < gToUsed.Count; i++)
            {
                for (int j = 0; j < gFrom.Count; j++)
                {
                    if (gTo[i] == gFrom[j])
                    {
                        weightSums[i] += gWeight[j] - weightSums[i];
                    }
                }
            }

            Console.Write(weightSums.Min());
        }

        static void Main(string[] args)
        {
            List<int> intAr = ReadFromBinaryFile("bin_file.bin");

            int gNodes = Convert.ToInt32(intAr[0]);
            int gEdges = Convert.ToInt32(intAr[1]);

            List<int> gFrom = new List<int>();
            List<int> gTo = new List<int>();
            List<int> gWeight = new List<int>();

            int num = 1;
            for (int i = 0; i < gEdges; i++)
            {
                gFrom.Add(intAr[++num]);
                gTo.Add(intAr[++num]);
                gWeight.Add(intAr[++num]);
            }
            getCost(gNodes, gFrom,gTo, gWeight);
        }
    }
}
