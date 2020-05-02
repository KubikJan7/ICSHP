using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise05Task01
{
    public partial class ChampionsLeagueForm : Form
    {
        public Players players;
        public bool addingProcedure;
        public ChampionsLeagueForm()
        {
            InitializeComponent();
            players = new Players(100);
        }

        private void CountChangedHandler(int count)
        {
            if (addingProcedure)
                detailsListBox.Items.Add("Player count was changed. Former value: " + count + ". New value: " + ++count + ".");
            else
                detailsListBox.Items.Add("Player count was changed. Former value: " + count + ". New value: " + --count + ".");
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

        private void QuitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
