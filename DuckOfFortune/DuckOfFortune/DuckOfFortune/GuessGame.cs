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

        static string[] lines = File.ReadAllLines("Phrases.txt");
        bool[] picked_questions = new bool[lines.Length];

        private void GuessGame_Load(object sender, EventArgs e)
        {
            var lastLine = File.ReadLines("currentplayer.txt").Last();
            string[] getscore = lastLine.Split(',');
            lblScore.Text = "You have: £" + getscore[1];
            Global2.giveupchecky = "0";
            Global.guesseslefty = "5";
            
            Random rand = new Random();
            int chosen_index = rand.Next(lines.Length);
            picked_questions[chosen_index] = true;
            var chosenline = lines[chosen_index];
            string[] parts = chosenline.Split(',');
            char[] characters = parts[1].ToCharArray();
            //QuestLbl.Text = "Question: " + parts[0];
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

                    if(letterToWrite is ';')
                    {
                        tbx.ForeColor = Color.White;
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
            var lastLine = File.ReadLines("currentplayer.txt").Last();
            string[] getscore = lastLine.Split(',');
            

            File.AppendAllText(@"Scores.txt", getscore[0]+","+getscore[1] + Environment.NewLine);

            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Hide();
        }

        private void QuestLbl_Click(object sender, EventArgs e)
        {

        }

        private void GenerateQuestionAndHint()
        {
            int chosen_index;
            Random rand = new Random();
            do
            {
                chosen_index = rand.Next(lines.Length);
            } while (picked_questions[chosen_index] is true);
            picked_questions[chosen_index] = true;
            var chosenline = lines[chosen_index];
            string[] parts = chosenline.Split(',');
            char[] characters = parts[1].ToCharArray();
            //QuestLbl.Text = "Question: " + parts[0];
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

                    if (letterToWrite is ';' || letterToWrite is '-')
                    {
                        tbx.ForeColor = Color.White;
                    }
                    count++;
                }
            }
        }

        private void HintLbl_Click(object sender, EventArgs e)
        {

        }
    }
}
