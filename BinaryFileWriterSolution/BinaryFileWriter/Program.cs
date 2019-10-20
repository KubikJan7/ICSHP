using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryFileWriter
{
    class Program
    {
        static void WriteToBinaryFile(string fileName)
        {
            using (BinaryWriter binWriter = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                binWriter.Write(4);binWriter.Write(4);
                binWriter.Write(1); binWriter.Write(2); binWriter.Write(20);
                binWriter.Write(1); binWriter.Write(3); binWriter.Write(5);
                binWriter.Write(2); binWriter.Write(4); binWriter.Write(30);
                binWriter.Write(3); binWriter.Write(4); binWriter.Write(40);
            }
        }

        static void Main(string[] args)
        {
            string fileName = "bin_file.bin";
            WriteToBinaryFile(fileName);
        }
    }
}
