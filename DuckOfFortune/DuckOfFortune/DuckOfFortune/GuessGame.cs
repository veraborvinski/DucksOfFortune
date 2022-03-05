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

        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            string[] lines = File.ReadAllLines("misfortunes.txt");
            Wheel misWheel = new Wheel(lines);
            misWheel.Show();
        }

        private void guessBtn_Click(object sender, EventArgs e)
        {
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
            Global.guesseslefty = "5";
            string[] lines = File.ReadAllLines("Phrases.txt");
            Random rand = new Random();
            var chosenline = lines[rand.Next(lines.Length)];
            string[] parts = chosenline.Split(',');
            Console.WriteLine(parts[0]);
            Console.WriteLine(parts[1]);
            Console.WriteLine(parts[2]);
            char[] characters = parts[1].ToCharArray();
            QuestLbl.Text = "Question: " + parts[0];
            HintLbl.Text = "Hint: " + parts[2];
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

        private void QuestLbl_Click(object sender, EventArgs e)
        {

        }
    }
}
