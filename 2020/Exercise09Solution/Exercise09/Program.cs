using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise09
{
    class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine();

                Graph graph = new Graph();
                graph.LoadGraphFromFile("vstup.dat");
                Console.WriteLine("Nodes with these labels are unreachable: ");
                Console.WriteLine(graph.GetUnreachableNodes(graph.Root.Label));
                Console.WriteLine("The given graph contains these self link nodes: ");
                Console.WriteLine(graph.GetSelfLinkNodes());
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
