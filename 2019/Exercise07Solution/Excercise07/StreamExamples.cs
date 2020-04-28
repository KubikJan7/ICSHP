using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise07
{
    public static class StreamExamples
    {
        public static void FileExample()
        {
            const string testPath01 = "d:\\test.txt";
            if (!File.Exists(testPath01))
            {
                using(StreamWriter sw = File.CreateText(testPath01))
                {
                    sw.Write("test text");
                }
            }

            FileInfo fileInfoTest1 = new FileInfo(testPath01);
            if (fileInfoTest1.Exists)
            {
                var sw = fileInfoTest1.Create();
                sw.Close();
            }

            DriveInfo di = new DriveInfo("C");
            var freeSpace = di.TotalFreeSpace;
        }
    }
}
