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
    public partial class BestClubForm : Form
    {
        ChampionsLeagueForm MainForm;
        public BestClubForm(ChampionsLeagueForm ParentForm)
        {
            this.MainForm = ParentForm;
            InitializeComponent();
            FillDialog();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillDialog()
        {
            if (MainForm.players[0] == null)
            {
                goalsCountTextBox.Text = "0";
                clubListBox.Items.Clear();
                return;
            }

            var bestClubs = MainForm.players.FindBestClubs();
            goalsCountTextBox.Text = bestClubs.Item2.ToString();
            foreach (FootballClub v in bestClubs.Item1)
            {
                clubListBox.Items.Add(FootballClubInfo.GetNazev((int)v));
            }
        }
    }
}
