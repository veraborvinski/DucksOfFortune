using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace DuckOfFortune
{
    public partial class Wheel : Form
    {
        string[] Prizes;
        Random r = new Random();
        public Wheel(string[] prizes)
        {
            Prizes = prizes; ;
            InitializeComponent();
        }

        private void Wheel_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Text = "stop";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            button3.Text = Prizes[r.Next(3)];
        }
    }
}
