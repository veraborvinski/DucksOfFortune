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

    public partial class GuessGame : Form
    {


        public GuessGame()
        {
            InitializeComponent();
        }


        static class Global
        {
            private static string guessesleft;
            

            public static string guesseslefty
            {
                get { return guessesleft; }
                set { guessesleft = value; }
            }

           
        }

        static class Global2
        {
            private static string giveupcheck;

            public static string giveupchecky
            {
                get { return giveupcheck; }
                set { giveupcheck = value; }
            }
        }

        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            var toconvert=Global2.giveupchecky;
            int giveupcheck2 = Int32.Parse(toconvert);
            Console.WriteLine(giveupcheck2);
            giveupcheck2++;
            if (giveupcheck2 == 1)
            {
                string message = "are you sure you want to spin the wheel of misfortune?";
                MessageBox.Show(message);
            }

            if (giveupcheck2 == 2)
            {
                var count2 = 0;
                while (count2 < 52)
                {
                    var chosenbox = "letterBox" + (count2 + 1);
                    Console.WriteLine(chosenbox);
                    TextBox tbx = this.Controls.Find(chosenbox, true).FirstOrDefault() as TextBox;
                    tbx.ForeColor = Color.White;
                    count2++;
                }
                Thread.Sleep(2000);
                this.Hide();
                string[] lines = File.ReadAllLines("misfortunes.txt");
                Wheel misWheel = new Wheel(lines);
                misWheel.Show();
            }

            
            Global2.giveupchecky = giveupcheck2.ToString();
        }

        private void guessBtn_Click(object sender, EventArgs e)
        {
            Global2.giveupchecky = "0";
            String guess = guessBox.Text;
            string guessupper = guess.ToUpper();
            string guesslower = guess.ToLower();
            bool guessCorrect = false;
            var count = 0;
            var count2 = 0;
            var thechecker = 0;

            while (count < 52)
            {
                var chosenbox = "letterBox" + (count + 1);
                Console.WriteLine(chosenbox);
                TextBox tbx = this.Controls.Find(chosenbox, true).FirstOrDefault() as TextBox;
                String check = tbx.Text;
                
                if (check.Equals(guessupper) || check.Equals(guesslower))
                {
                    guessCorrect = true;

                    tbx.ForeColor = Color.White;
                }

                count++;
            }

            while (count2 < 52)
            {
                var chosenbox = "letterBox" + (count2 + 1);
                Console.WriteLine(chosenbox);
                TextBox tbx = this.Controls.Find(chosenbox, true).FirstOrDefault() as TextBox;
                if (tbx.ForeColor == Color.Black)
                {
                    thechecker++;
                }
                count2++;
            }

            if (thechecker == 0)
            {
                string message = "You Win";
                MessageBox.Show(message);
                string[] lines = File.ReadAllLines("fortunes.txt");
                Wheel winWheel = new Wheel(lines);
                winWheel.Show();
            }

            if(guessCorrect == false)
            {
                int numbguessesleft = Int32.Parse(Global.guesseslefty);
                numbguessesleft--;
                Global.guesseslefty = numbguessesleft.ToString();
                GuessLbl.Text="Guesses Left: "+numbguessesleft;
                if (numbguessesleft == 0)
                {
                    string message = "You Lose";
                    MessageBox.Show(message);
                    string[] lines = File.ReadAllLines("misfortunes.txt");
                    Wheel misWheel = new Wheel(lines);
                    misWheel.Show();
                }
                    
            }


        }

        private void GuessGame_Load(object sender, EventArgs e)
        {
            Global2.giveupchecky = "0";
            Global.guesseslefty = "5";
            string[] lines = File.ReadAllLines("Phrases.txt");
            Random rand = new Random();
            var chosenline = lines[rand.Next(lines.Length)];
            string[] parts = chosenline.Split(',');
            Console.WriteLine(parts[0]);
            Console.WriteLine(parts[1]);
            char[] characters = parts[1].ToCharArray();
            HintLbl.Text = "Hint: " + parts[0];
            var longy = characters.Length;
            if (longy <= 52)
            {
                var count = 0;

                while (count < longy)
                {
                    var chosenbox = "letterBox" + (count + 1);
                    Console.WriteLine(chosenbox);
                    TextBox tbx = this.Controls.Find(chosenbox, true).FirstOrDefault() as TextBox;
                    var letterToWrite = characters[count];
                    var converted = letterToWrite.ToString();
                    tbx.Text = converted;

                    bool result = Char.IsWhiteSpace(letterToWrite);

                    if (result != true)
                    {
                        tbx.ForeColor = Color.Black;
                        tbx.BackColor = Color.Black;
                    }
                    count++;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            endGameForm endGame = new endGameForm();
            endGame.Show();
            this.Hide();
        }
    }
}
