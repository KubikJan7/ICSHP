using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise04Task01
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        Stats stats = new Stats();

        public Form1()
        {
            InitializeComponent();

            stats.UpdatedStats += UpdatedStatsHandler;
        }
        private void UpdatedStatsHandler(object sender, EventArgs evnentArgs)
        {
            correctLabel.Text = " " + stats.Correct.ToString();
            missedLabel.Text = " " + stats.Missed.ToString();
            accuracyLabel.Text = " " + stats.Accuracy.ToString() + " %";
        }

        private void Tick(object sender, EventArgs e)
        {

        }

        private void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
                gameListBox.Items.Add("dfsdf");
        }
    }
}
