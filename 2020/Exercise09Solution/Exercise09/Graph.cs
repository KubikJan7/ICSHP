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
        private List<Node> selfLinkNodes;
        public Node Root { get; private set; }
        private int Count { get; set; }
        public Graph()
        {
            nodes = new Dictionary<int, Node>();
            selfLinkNodes = new List<Node>();
            Count = 0;
        }

        public void AddNode(int id, string label)
        {
            Node node = new Node(id, label);
            if (Root == null)
                Root = node;

            nodes.Add(Count++, node);
        }

        public void AddEdge(int sourceId, int targetId)
        {
            Node source = nodes[sourceId];
            Node target = nodes[targetId];
            source.Targets.Add(target);
            target.Sources.Add(source);
            if (sourceId == targetId)
                selfLinkNodes.Add(source);
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



        private Node GetNodeWithLabel(string label)
        {
            foreach (var item in nodes)
            {
                if (item.Value.Label == label)
                    return item.Value;
            }
            return null;
        }

        private List<List<Node>> FindUnreachableNodes(string nodeLabel)
        {
            List<List<Node>> unreachable = new List<List<Node>>();
            Node defaultNode = GetNodeWithLabel(nodeLabel);

            if (defaultNode == null)
                throw new NullReferenceException("Graph does not contain any node with given label!");

            List<Node> reachable = VisitNodes(defaultNode); 

            //Will find nodes which are connected to the default node only via the source edge
            List<Node> unreachSources = FindSourcesAndTargets(defaultNode, reachable, false);
            unreachSources.Remove(defaultNode); // Exclude the chosen default node
            unreachSources.Sort((node, node1) => node.Id - node1.Id);

            unreachable.Add(unreachSources);

            foreach (var nodeVal in nodes.Values)
            {
                if (nodeVal == defaultNode || reachable.Contains(nodeVal))
                    continue;

                bool contains = false;
                foreach (var list in unreachable)
                    if (list.Contains(nodeVal))
                        contains = true;

                // If a node is not part of any list, new list will be created and filled with its sources and targets
                if (!contains)
                {
                    List<Node> toAdd = FindSourcesAndTargets(nodeVal, reachable, true);
                    toAdd.Sort((node, node1) => node.Id - node1.Id);
                    unreachable.Add(toAdd);
                }
            }
            return unreachable;
        }

        /// <summary>
        /// Performs iterative DFS on graph starting from defaultNode
        /// </summary>
        /// <param name="defaultNode"></param>
        /// <returns>
        /// List of visited nodes
        /// </returns>
        private List<Node> VisitNodes(Node defaultNode)
        {
            List<Node> visited = new List<Node>();
            Stack<Node> stack = new Stack<Node>();

            // Add default node to the stack
            stack.Push(defaultNode);
            while (stack.Count != 0)
            {
                Node node = stack.Pop();
                if (visited.Contains(node))
                    continue;

                visited.Add(node);

                // Visit every target edge
                foreach (var item in node.Targets)
                    if (!visited.Contains(item))
                        stack.Push(item);
            }
            return visited;
        }

        private List<Node> FindSourcesAndTargets(Node defaultNode, List<Node> nodesToAvoid, bool findTargets)
        {
            List<Node> sourcesAndTargets = new List<Node>();
            Stack<Node> stack = new Stack<Node>();

            sourcesAndTargets.Add(defaultNode);

            foreach (var node in defaultNode.Sources)
                stack.Push(node);

            if (findTargets) // If true => will ignore all targets of the default node
                foreach (var node in defaultNode.Targets)
                    stack.Push(node);

            while (stack.Count != 0)
            {
                Node node = stack.Pop();
                if (!sourcesAndTargets.Contains(node) && !nodesToAvoid.Contains(node))
                {
                    sourcesAndTargets.Add(node);
                    foreach (var source in node.Sources)
                        stack.Push(source);
                    foreach (var target in node.Targets)
                        stack.Push(target);
                }
            }
            return sourcesAndTargets;
        }

        /// <summary>
        /// Will convert node values of all list into string
        /// </summary>
        /// <param name="nodeLabel"></param>
        /// <returns> 
        /// String with unreachable node values
        /// </returns>
        public string GetUnreachableNodes(string nodeLabel)
        {
            List<List<Node>> unreachableNodes = FindUnreachableNodes(nodeLabel);

            if (unreachableNodes.Count == 0)
                throw new NullReferenceException("Given graph does not contain any unreachable nodes!");

            string nodeLabels = "";
            foreach (var list in unreachableNodes)
            {
                if (list.Count != 0)
                {
                    nodeLabels += "=> ";
                    foreach (var item in list)
                    {
                        nodeLabels += item.Label + " ";
                    }
                    nodeLabels += "\n";
                }
            }
            return nodeLabels;
        }

        public string GetSelfLinkNodes()
        {
            if (selfLinkNodes.Count == 0)
                return "Given graph does not contain any self link nodes!";

            string nodeLabels = "";
            foreach (var item in selfLinkNodes)
            {
                nodeLabels += item.Label + ", ";
            }
            return nodeLabels.Substring(0, nodeLabels.Length - 2);
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
