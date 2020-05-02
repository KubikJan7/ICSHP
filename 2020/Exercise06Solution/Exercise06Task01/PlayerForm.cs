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
    public partial class PlayerForm : Form
    {
        ChampionsLeagueForm MainForm;
        private Player formerPlayer;
        public PlayerForm(ChampionsLeagueForm ParentForm)
        {
            InitializeComponent();
            clubComboBox.DataSource = FillClubComboBox();
            this.MainForm = ParentForm;
            if (!ParentForm.addingProcedure)
            {
                formerPlayer = ParentForm.GetSelectedRow();
                nameTextBox.Text = formerPlayer.Name;
                clubComboBox.SelectedItem = FootballClubInfo.GetNazev((int)formerPlayer.Club);
                goalCountUpDown.Value = formerPlayer.GoalCount;
            }

        }
        private List<string> FillClubComboBox()
        {
            List<string> clubList = new List<string>();
            for (int i = 0; i < FootballClubInfo.Count; i++)
            {
                clubList.Add(FootballClubInfo.GetNazev(i));
            }
            return clubList;
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text == "")
            {
                MessageBox.Show(
                    "Please fill the name.", "Input Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            if (MainForm.addingProcedure)
                AddPlayer();
            else
                ModifyPlayer();

            MainForm.RefreshGridView();
            this.Close();
        }

        private void StornoBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModifyPlayer()
        {
            for (int i = 0; i < MainForm.players.Count; i++)
            {
                if (MainForm.players[i].Equals(formerPlayer))
                {
                    MainForm.players[i].Name = nameTextBox.Text;
                    MainForm.players[i].Club = FootballClubInfo.GetEnumType(clubComboBox.Text);
                    MainForm.players[i].GoalCount = (int)goalCountUpDown.Value;
                }
            }

        }
        private void AddPlayer()
        {
            MainForm.players.Add(new Player(nameTextBox.Text, FootballClubInfo.GetEnumType(clubComboBox.Text), (int)goalCountUpDown.Value));
        }
    }
}
