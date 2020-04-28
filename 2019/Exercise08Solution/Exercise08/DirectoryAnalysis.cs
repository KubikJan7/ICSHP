using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise08
{
    public static class DirectoryAnalysis
    {
        private static readonly IDictionary<string, int> fileExtensionDict = new Dictionary<string, int>();
        private static StreamWriter fileWriter = null;
        public static bool WriteInfosIntoFile { get; set; }
        public static IList<string> Warnings { get; } = new List<string>();

        public static IList<string> DirectoryInfoList { get; set; } = new List<string>();

        public static void Analyze(string directoryName)
        {
            fileExtensionDict.Clear();
            try
            {
                using (fileWriter =
            new StreamWriter(directoryName + "\\AnalysisInfo.txt"))
                {
                    ProcessDirectory(new DirectoryInfo(directoryName));
                    PrintFilesCounts();
                }
            }
            catch (Exception e)
            {
                Warnings.Add(e.Message);
            }
        }
        private static void ProcessDirectory(DirectoryInfo directory)
        {
            if (WriteInfosIntoFile)
                WriteDirectoryInfoIntoFile(directory);
            if (!directory.Exists)
                return;
            SaveDirectoryInfoIntoList(directory);
            ProcessFiles(directory);
            ProcessSubdirectories(directory);
        }
        private static void WriteDirectoryInfoIntoFile(DirectoryInfo directory)
        {
            fileWriter.WriteLine($"Directory '{directory.FullName}' exists: {directory.Exists}");
            if (!directory.Exists)
                return;

            fileWriter.WriteLine($"Directory name: {directory.Name}");
            fileWriter.WriteLine($"Directory root: {directory.Root}");
            fileWriter.WriteLine($"Directory parent: {directory.Parent}");
            fileWriter.WriteLine($"Directory attributes: {directory.Attributes}");
            fileWriter.WriteLine($"Directory creation time: {directory.CreationTime}");
            fileWriter.WriteLine($"Directory last write time: {directory.LastWriteTime}");
        }

        private static void SaveDirectoryInfoIntoList(DirectoryInfo directory)
        {
            DirectoryInfoList.Add($"Directory '{directory.FullName}' exists: { directory.Exists}");
            DirectoryInfoList.Add($"Directory name: {directory.Name}");
            DirectoryInfoList.Add($"Directory root: {directory.Root}");
            DirectoryInfoList.Add($"Directory parent: {directory.Parent}");
            DirectoryInfoList.Add($"Directory attributes: {directory.Attributes}");
            DirectoryInfoList.Add($"Directory creation time: {directory.CreationTime}");
            DirectoryInfoList.Add($"Directory last write time: {directory.LastWriteTime}");
        }

        private static void ProcessSubdirectories(DirectoryInfo directory)
        {
            foreach (var subdirectory in directory.GetDirectories())
            {
                ProcessDirectory(subdirectory);
            }
        }

        private static void ProcessFiles(DirectoryInfo directory)
        {
            foreach (var file in directory.GetFiles())
            {
                ProcessFile(file);
            }
        }

        private static void ProcessFile(FileInfo file)
        {
            ProcessFileExtension(file);
            if (WriteInfosIntoFile)
                WriteFileInfoIntoFile(file);
            SaveFileInfoIntoList(file);
        }

        private static void ProcessFileExtension(FileInfo file)
        {
            if (fileExtensionDict.ContainsKey(file.Extension))
                fileExtensionDict[file.Extension]++;
            else
                fileExtensionDict.Add(file.Extension, 1);
        }

        private static void WriteFileInfoIntoFile(FileInfo file)
        {
            fileWriter.WriteLine($"File name: {file.Name}");
            fileWriter.WriteLine($"File extension: {file.Extension}");
            fileWriter.WriteLine($"File is readonly: {file.IsReadOnly}");
            fileWriter.WriteLine($"File last access time: {file.LastAccessTime}");
            fileWriter.WriteLine($"File last write time: {file.LastWriteTime}");
            fileWriter.WriteLine($"File has size: {file.Length} bytes");
        }

        private static void SaveFileInfoIntoList(FileInfo file)
        {
            DirectoryInfoList.Add($"File name: {file.Name}");
            DirectoryInfoList.Add($"File extension: {file.Extension}");
            DirectoryInfoList.Add($"File is readonly: {file.IsReadOnly}");
            DirectoryInfoList.Add($"File last access time: {file.LastAccessTime}");
            DirectoryInfoList.Add($"File last write time: {file.LastWriteTime}");
            DirectoryInfoList.Add($"File has size: {file.Length} bytes");
        }

        private static void PrintFilesCounts()
        {
            fileWriter.WriteLine();
            fileWriter.WriteLine("Files extensions counts:");
            foreach (var item in fileExtensionDict)
            {
                fileWriter.WriteLine($"*{item.Key}: {item.Value}");
            }
        }

    }
}
