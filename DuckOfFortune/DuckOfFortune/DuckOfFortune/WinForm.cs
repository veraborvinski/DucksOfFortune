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
    public partial class WinForm : Form
    {
        public WinForm()
        {
            InitializeComponent();
            label1.Text = "You have won";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HighScore highscore = new HighScore();
            highscore.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
