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
    using System.IO;
    using System.Threading.Tasks;
    public partial class StartScreen : Form
    {
        private string name;

        public StartScreen()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            name = nameBox.Text;
            btnConfirm.Hide();
            nameBox.Hide();
            btnYes.Show();
            btnNo.Show();
            nameLbl.Show();
            nameLbl.Text = "Are you sure your name is: " + name;

        }

        private void StartScreen_Load(object sender, EventArgs e)
        {
            btnConfirm.Show();
            nameBox.Show();
            btnYes.Hide();
            btnNo.Hide();
            nameLbl.Hide();

        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            btnConfirm.Show();
            nameBox.Show();
            btnYes.Hide();
            btnNo.Hide();
            nameLbl.Hide();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            File.AppendAllText(@"Scores.txt", name + ",0" + Environment.NewLine);

            this.Hide();
            var guessgame = new GuessGame();
            guessgame.Closed += (s, args) => this.Close();
            guessgame.Show();

        }
    }
}
