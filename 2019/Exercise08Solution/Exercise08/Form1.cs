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
        private FolderBrowserDialog fbd;
        private string directoryPath = ".";
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

                    directoryPath = fbd.SelectedPath;
                }
            }
        }

        private void AnalyseBtn_Click(object sender, EventArgs e)
        {
            infoListBox.Items.Clear();

            if (saveToFileCheckBox.Checked)
            {
                DirectoryAnalysis.WriteInfosIntoFile = true;
            }
            else
                DirectoryAnalysis.WriteInfosIntoFile = false;


            DirectoryAnalysis.Analyze(directoryPath);

            if (showDirInfoCheckBox.Checked)
            {
                foreach (var item in DirectoryAnalysis.DirectoryInfoList)
                {
                    infoListBox.Items.Add(item);
                }
            }
        }
    }
}
