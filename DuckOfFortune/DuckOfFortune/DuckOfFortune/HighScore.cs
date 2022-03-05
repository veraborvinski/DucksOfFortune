using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuckOfFortune
{
    public partial class HighScore : Form
    {
        string[] lines = File.ReadAllLines("Scores.txt");
        public HighScore()
        {
            InitializeComponent();
        }

        private void HighScore_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                label1.Text = lines[i];
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
