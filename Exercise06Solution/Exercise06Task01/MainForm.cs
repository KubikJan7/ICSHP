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

namespace Exercise06Task01
{
    public partial class ChampionsLeagueForm : Form
    {
        public Players players;
        public bool addingProcedure;
        public ChampionsLeagueForm()
        {
            InitializeComponent();
            players = new Players();
        }

        private void CountChangedHandler(int count)
        {
            if (addingProcedure)
                detailsListBox.Items.Add("Player count was changed. Former value: " + count + ". New value: " + ++count + ".");
            else
                detailsListBox.Items.Add("Player count was changed. Former value: " + count + ". New value: " + --count + ".");
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            addingProcedure = true;
            PlayerForm pf = new PlayerForm(this);
            pf.ShowDialog();
        }

        private void BestClubBtn_Click(object sender, EventArgs e)
        {
            BestClubForm bf = new BestClubForm(this);
            bf.ShowDialog();
        }

        private void QuitBtn_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to quit?",
                                     "Confirm Exit!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        public void RefreshGridView()
        {
            playersGridView.Rows.Clear();
            for (int i = 0; i < players.Count; i++)
            {
                Player p = players[i];
                playersGridView.Rows.Add(p.Name, FootballClubInfo.GetNazev((int)p.Club), p.GoalCount);
                playersGridView.Update();
                playersGridView.Refresh();
            }
        }

        private void ModifyBtn_Click(object sender, EventArgs e)
        {
            addingProcedure = false;
            if (players[0] == null)
            {
                MessageBox.Show(
                    "Please add a player first.", "Modify Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            PlayerForm pf = new PlayerForm(this);
            pf.ShowDialog();
        }
        public Player GetSelectedRow()
        {
            Player p = new Player
            {
                Name = (string)playersGridView.CurrentRow.Cells[0].Value,
                Club = FootballClubInfo.GetEnumType((string)playersGridView.CurrentRow.Cells[1].Value),
                GoalCount = (int)playersGridView.CurrentRow.Cells[2].Value
            };
            return p;
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            addingProcedure = false;
            for (int i = 0; i < players.Count; i++)
            {
                if (GetSelectedRow().Equals(players[i]))
                {
                    players.Remove(i);
                }
            }
            RefreshGridView();
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            detailsListBox.Items.Add("Event handler was registered.");
            players.CountChanged += CountChangedHandler;
        }

        private void UnregisterBtn_Click(object sender, EventArgs e)
        {
            detailsListBox.Items.Add("Event handler was unregistered.");
            players.CountChanged -= CountChangedHandler;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SaveFileForm bf = new SaveFileForm(this);
            bf.ShowDialog();

        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;

                //Read the contents of the file into a stream
                var fileStream = openFileDialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string row;
                    while ((row = reader.ReadLine()) != null)
                    {
                        string[] words = row.Split(' ');
                        int.TryParse(words[2], out int goalCount);
                        players.Add(new Player(words[0], FootballClubInfo.GetEnumType(words[1]), goalCount));
                        RefreshGridView();
                    }
                    fileContent = reader.ReadToEnd();
                }
            }
        }
    }
}
