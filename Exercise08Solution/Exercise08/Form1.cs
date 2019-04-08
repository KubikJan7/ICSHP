using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise08
{
    public partial class Form1 : Form
    {
        private FileInfo[] files;
        private string[] subDirectories;
        private FolderBrowserDialog fbd;
        private DirectoryInfo d;
        private string currentPath;
        public Form1()
        {
            InitializeComponent();
        }

        private void chooseDirBtn_Click(object sender, EventArgs e)
        {
            using (fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    chosenDirTextBox.Text = fbd.SelectedPath;

                    currentPath = fbd.SelectedPath;
                    d = new DirectoryInfo(currentPath);

                }
            }
        }

        private void AnalyseBtn_Click(object sender, EventArgs e)
        {
            string[] fileExtensions = new string[20];

            infoListBox.Items.Clear();
            if (d == null)
            {
                currentPath = ".";
                d = new DirectoryInfo(currentPath);
            }

            files = d.GetFiles();
            subDirectories = Directory.GetDirectories(currentPath);

            foreach (var dir in Directory.GetDirectories(currentPath))
            {

            }

            foreach (FileInfo file in files)
            {
                for (int i = 0; i < fileExtensions.Length; i++)
                {
                    if (file.Extension != fileExtensions[i])
                    {

                    }
                }

            }

            if (showDirInfoCheckBox.Checked)
            {
                infoListBox.Items.Add(files.Length.ToString());
                for (int i = 0; i < files.Length; i++)
                {
                    infoListBox.Items.Add(files[i].Name);
                }
                for (int i = 0; i < subDirectories.Length; i++)
                {
                    infoListBox.Items.Add(subDirectories[i]);

                }
            }

            if (saveToFileCheckBox.Checked)
            {
                using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(currentPath + "\\AnalysisInfo.txt"))
                {
                    file.WriteLine(files.Length.ToString());
                    for (int i = 0; i < files.Length; i++)
                    {
                        file.WriteLine(files[i].Name);
                    }
                }
            }
        }
    }
}
