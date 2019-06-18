using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanDecoding
{
    public class HuffmanTree<T>
    {
        private Node rootNode;
        private Dictionary<T, string> encodeDict = new Dictionary<T, string>();
        private string strToEncode;

        public class Node
        {
            public int freq; // number of letters contained in the given string
            public T data;
            public Node left;
            public Node right;

            public Node(int freq, T data)
            {
                this.freq = freq;
                this.data = data;
            }
        }

        public HuffmanTree()
        {
            rootNode = null;
        }

        public void Insert(int freq, T data)
        {
            if (rootNode == null)
                rootNode = new Node(freq, data);
            else
            {
                Node node = new Node(freq, data);

            }

        }

        public void Build(string input)
        {
            strToEncode = input;
            Node currentNode;
            string currentBinStr = "";
            string charBinStr = "";
            if (input == string.Empty || input == null)
            {
                Console.WriteLine("Zadaný řetězec je prázdný");
                return;
            }

            rootNode = new Node(input.Length, default(T));
            currentNode = rootNode;

            while (input != string.Empty)
            {
                char mostFreqChar = input.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
                int frequency = input.Count(x => x == mostFreqChar);
                input = new string(input.Where(c => !mostFreqChar.ToString().Contains(c)).ToArray());
                
                if (frequency < input.Length)
                {
                    if (input.Length == 1)
                    {
                        currentNode.left = new Node(frequency, (T)Convert.ChangeType(mostFreqChar, typeof(T)));
                        currentNode.right = new Node(input.Length, (T)Convert.ChangeType(input[0], typeof(T)));
                        encodeDict.Add((T)Convert.ChangeType(mostFreqChar, typeof(T)), currentBinStr+"0");
                        encodeDict.Add((T)Convert.ChangeType(input[0], typeof(T)), currentBinStr+"1");
                        return;
                    }

                    currentNode.left = new Node(frequency, (T)Convert.ChangeType(mostFreqChar, typeof(T)));
                    currentNode.right = new Node(input.Length, default(T));
                    currentNode = currentNode.right;
                    charBinStr = currentBinStr + "0";
                    currentBinStr += "1";
                }
                else
                {
                    if (input.Length == 1)
                    {
                        currentNode.left = new Node(input.Length, (T)Convert.ChangeType(input[0], typeof(T)));
                        currentNode.right = new Node(frequency, (T)Convert.ChangeType(mostFreqChar, typeof(T)));
                        encodeDict.Add((T)Convert.ChangeType(input[0], typeof(T)), currentBinStr + "0");
                        encodeDict.Add((T)Convert.ChangeType(mostFreqChar, typeof(T)), currentBinStr + "1");
                        return;
                    }

                    currentNode.left = new Node(input.Length, default(T));
                    currentNode.right = new Node(frequency, (T)Convert.ChangeType(mostFreqChar, typeof(T)));
                    currentNode = currentNode.left;
                    charBinStr = currentBinStr + "1";
                    currentBinStr += "0";
                }
                encodeDict.Add((T)Convert.ChangeType(mostFreqChar, typeof(T)), charBinStr);
            }
        }

        public void DisplayTree()
        {
            Stack<Node> nodes = new Stack<Node>();
            nodes.Push(rootNode);

            while (nodes.Count != 0)
            {
                Node node = nodes.Pop();
                if (node.data.Equals(default(T)))
                    Console.Write($"(\u03C6, {node.freq}) ");
                else
                    Console.Write($"({node.data}, {node.freq}) ");
                if (node.right != null)
                    nodes.Push(node.right);
                if (node.left != null)
                    nodes.Push(node.left);
            }
        }

        public void EncodeString()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(strToEncode);
            for (int i = 0; i < strToEncode.Length; i++)
            {
                Console.Write($"{encodeDict[(T) Convert.ChangeType(strToEncode[i],typeof(T))]} ");
            }

        }
    }
}
