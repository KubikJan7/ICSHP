using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanEncoding
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "ABRACADABRA";
            HuffmanTree<char> tree = new HuffmanTree<char>();
            tree.Build(input);
            tree.DisplayTree();
            tree.EncodeString();
        }
    }
}
