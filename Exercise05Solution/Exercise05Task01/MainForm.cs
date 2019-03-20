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
        public ChampionsLeagueForm()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            PlayerForm pf = new PlayerForm();
            pf.ShowDialog();
        }

        private void bestClubBtn_Click(object sender, EventArgs e)
        {
            BestClubForm bf = new BestClubForm();
            bf.ShowDialog();
        }
    }
}
