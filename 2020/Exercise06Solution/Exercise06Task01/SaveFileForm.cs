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

namespace Exercise05Task01
{
    public partial class SaveFileForm : Form
    {
        ChampionsLeagueForm MainForm;
        public SaveFileForm(ChampionsLeagueForm ParentForm)
        {
            this.MainForm = ParentForm;
            InitializeComponent();

            GetAllClubsInList();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (teamsToSaveListBox.SelectedItems.Count == 0)
            {
                MessageBox.Show(
                   "Please select at least one team.", "Input Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter wText = new StreamWriter(myStream);
                    for (int i = 0; i < teamsToSaveListBox.SelectedItems.Count; i++)
                    {
                        for (int j = 0; j < MainForm.players.Count; j++)
                        {
                            if (MainForm.players[j].Club.Equals(FootballClubInfo.GetEnumType((string)teamsToSaveListBox.SelectedItems[i])))
                                wText.WriteLine(MainForm.players[j].Name + " " + MainForm.players[j].Club + " " + MainForm.players[j].GoalCount);
                        }
                    }
                    wText.Close();
                    myStream.Close();
                }
            }
            this.Close();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetAllClubsInList()
        {
            for (int i = 0; i < FootballClubInfo.Count; i++)
            {
                for (int j = 0; j < MainForm.players.Count; j++)
                {
                    if (MainForm.players[j].Club.Equals(FootballClubInfo.GetEnumType(FootballClubInfo.GetNazev(i))))
                    {
                        teamsToSaveListBox.Items.Add(FootballClubInfo.GetNazev(i));
                        break;
                    }

                }
            }
        }
    }
}
