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
    public partial class Wheel : Form
    {
        string[] Prizes;
        Random r = new Random();
        public Wheel(string[] prizes)
        {
            Prizes = prizes;
            InitializeComponent();
        }

        private void Wheel_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            button2.Text = "stop";
            button1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            button2.Text = "";
            button3.Text = Prizes[r.Next(Prizes.Length)];
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            button3.Text = Prizes[r.Next(Prizes.Length)];
        }
    }
}