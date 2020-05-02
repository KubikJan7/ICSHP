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
        Random random;
        Stats stats;
        public Form1()
        {
            random = new Random();
            stats = new Stats();
            InitializeComponent();

            stats.UpdatedStats += UpdatedStatsHandler;
        }

        private void UpdatedStatsHandler(object sender, EventArgs evnentArgs)
        {
            correctLabel.Text = "Correct: " + stats.Correct.ToString();
            missedLabel.Text = "Missed: " + stats.Missed.ToString();
            accuracyLabel.Text = "Accuracy: " + stats.Accuracy.ToString() + " %";
        }

        bool gameOver;
        private void Tick(object sender, EventArgs e)
        {
            gameListBox.Items.Add((Keys)random.Next(65, 91));
            if (gameListBox.Items.Count > 6)
            {
                timer1.Stop();
                gameListBox.Items.Clear();
                gameListBox.Items.Add("Game over!");
                gameOver = true;
            }
        }

        private void KeyDownEvent(object sender, KeyEventArgs e)
        {
            if (!gameOver)
                if (gameListBox.Items.Contains(e.KeyCode))
                {
                    stats.Update(true);
                    gameListBox.Items.Remove(e.KeyCode);
                    gameListBox.Refresh();
                    if (timer1.Interval > 400)
                        timer1.Interval -= 60;
                    else if (timer1.Interval > 250)
                        timer1.Interval -= 15;
                    else if (timer1.Interval > 150)
                        timer1.Interval -= 8;

                    int difficulty = 800 - timer1.Interval;
                    if (difficulty > 800)
                        difficulty = 800;
                    else if (difficulty < 0)
                        difficulty = 0;
                    difficultyProgressBar.Value = difficulty;

                }
                else
                    stats.Update(false);

        }
    }
}
