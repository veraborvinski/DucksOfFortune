using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuckOfFortune
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.Hide();
            var startscreen = new StartScreen();
            startscreen.Closed += (s, args) => this.Close();
            startscreen.Show();
        }

        private void btnScores_Click(object sender, EventArgs e)
        {
            this.Hide();
            HighScore highscore = new HighScore();
            highscore.Show();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
