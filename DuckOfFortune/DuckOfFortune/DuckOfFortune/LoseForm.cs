using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DuckOfFortune
{
    public partial class LoseForm : Form
    {
        public LoseForm()
        {
            InitializeComponent();
            var lastLine2 = File.ReadLines("currentplayer.txt").Last();
            string[] getscore2 = lastLine2.Split(',');
            label1.Text = "You have lost £" + ( Int32.Parse(getscore2[1]) * -1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            HighScore highscore = new HighScore();
            highscore.Show();
            //highscore.ForeColor = Color.Aqua;
        }

        private void LoseForm_Load(object sender, EventArgs e)
        {

        }
    }
}
