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
    public partial class Wheel : Form
    {
        string[] Prizes;
        Random r = new Random();
        int curr;
        public Wheel(string[] prizes)
        {
            Prizes = prizes;
            InitializeComponent();
            curr = 1;
        }

        private void Wheel_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            button2.Show();
            timer1.Enabled = true;
            button2.Text = "stop";
            button1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Hide();
            
            var lastLine = File.ReadLines("currentplayer.txt").Last();
            string[] getscore = lastLine.Split(',');
            var playerscore = getscore[1];
            var playername = getscore[0];

            int playerscore2 = Int32.Parse(playerscore);

            timer1.Enabled = false;
            button2.Text = "";
            button3.Text = Prizes[r.Next(Prizes.Length)];


            if (button3.Text.Equals("£1")) {
                playerscore2 = playerscore2 + 1;
                Console.WriteLine("1");
            }
            if (button3.Text.Equals("£100"))
            {
                playerscore2 = playerscore2 + 100;
                Console.WriteLine("100");
            }
            if (button3.Text.Equals("£250"))
            {
                playerscore2 = playerscore2 + 250;
                Console.WriteLine("250");
            }
            if (button3.Text.Equals("£500"))
            {
                playerscore2 = playerscore2 + 500;
                Console.WriteLine("500");
            }
            if (button3.Text.Equals("£1000"))
            {
                playerscore2 = playerscore2 + 1000;
                Console.WriteLine("1000");
            }
            if (button3.Text.Equals("double"))
            {
                playerscore2 = playerscore2*2;
                Console.WriteLine("x2");
            }
            if (button3.Text.Equals("minigame"))
            {
                Console.WriteLine("mini");
            }
            if (button3.Text.Equals("(-£100)"))
            {
                playerscore2 = playerscore2 - 100;
                Console.WriteLine("-100");
            }
            if (button3.Text.Equals("(-£250)"))
            {
                playerscore2 = playerscore2 - 250;
                Console.WriteLine("-250");
            }
            if (button3.Text.Equals("(-£500)"))
            {
                playerscore2 = playerscore2 - 500;
                Console.WriteLine("-500");
            }
            if (button3.Text.Equals("(-£1000)"))
            {
                playerscore2 = playerscore2 - 1000;
                Console.WriteLine("-1000");
            }
            if (button3.Text.Equals("halve"))
            {
                playerscore2 = playerscore2/2;
                Console.WriteLine("/2");
            }
            if (button3.Text.Equals("give £1,000,000 to Amazon"))
            {
                playerscore2 = playerscore2 - 1000000;
                Console.WriteLine("amazon");
            }

            System.IO.File.WriteAllText(@"currentplayer.txt", playername+","+playerscore2);
            var lastLine2 = File.ReadLines("currentplayer.txt").Last();
            string[] getscore2 = lastLine2.Split(',');
            lblScore.Text = "You have: £" + getscore2[1];
            int checkscore = Int32.Parse(getscore2[1]);
            bool negative = checkscore < 0;
            if (negative == true)
            {
                var message = "You have lost";
                MessageBox.Show(message);
                this.Hide();
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
            }

            else
            {
                Thread.Sleep(2000);
                this.Hide();
                GuessGame guessGame = new GuessGame();
                guessGame.Show();
            }

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            button3.Text = Prizes[r.Next(Prizes.Length)];
            if (curr == 1)
            {
                button3.Image = DuckOfFortune.Properties.Resources._2;
                curr++;
            }
            else if (curr == 2)
            {
                button3.Image = DuckOfFortune.Properties.Resources._3;
                curr++;
            }
            else if (curr == 3)
            {
                button3.Image = DuckOfFortune.Properties.Resources._4;
                curr++;
            }
            else if (curr == 4)
            {
                button3.Image = DuckOfFortune.Properties.Resources._1;
                curr = 1;
            }
        }

        private void Wheel_Load_1(object sender, EventArgs e)
        {
            button2.Hide();
            button1.Show();
            var lastLine = File.ReadLines("currentplayer.txt").Last();
            string[] getscore = lastLine.Split(',');
            lblScore.Text = "You have: £" + getscore[1];
        }
    }
}