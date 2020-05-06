using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise09
{
    public class Graph
    {
        private Dictionary<int, Node> nodes;

        public Graph()
        {
            nodes = new Dictionary<int, Node>();
        }

        public void AddNode(int id, string label)
        {
            try
            {
                nodes.Add(id, new Node(id, label));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void AddEdge(int sourceId, int targetId)
        {
            try
            {
                Node source = nodes[sourceId];
                Node target = nodes[targetId];
                source.Targets.Add(target);
                target.Sources.Add(source);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void LoadGraphFromFile(string fileName)
        {
            using (StreamReader file = new StreamReader(fileName))
            {
                string ln;
                string[] words;

                while ((ln = file.ReadLine()) != null)
                {
                    words = ln.Split(null);

                    if (words.Length > 2)
                    {
                        if (words[2].Equals("id"))
                        {
                            int.TryParse(words[3], out int id);
                            string label = file.ReadLine().Split(null)[3].Trim('"');
                            AddNode(id, label);
                        }
                        if (words[2].Equals("source"))
                        {
                            int.TryParse(words[3], out int source);
                            int.TryParse(file.ReadLine().Split(null)[3], out int target);
                            AddEdge(source, target);
                        }
                    }
                }
                file.Close();
            }
        }

        public List<Node> FindUnreachableNodes(Node root)
        {
            return default;
        }

        public List<Node> FindSelfLinkNodes()
        {
            foreach (var item in nodes)
            {

            }
            return default;
        }

        public class Node
        {
            public int Id { get; set; }
            public string Label { get; set; }
            public List<Node> Sources { get; set; }
            public List<Node> Targets { get; set; }
            public Node(int id, string label)
            {
                this.Id = id;
                this.Label = label;
                Sources = new List<Node>();
                Targets = new List<Node>();
            }
        }
    }
}
