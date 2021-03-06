using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
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
                var whiteCounter = 0;
                var sleepTime = 500;
                while (count2 < 52)
                {
                    var chosenbox = "letterBox" + (count2 + 1);
                    Console.WriteLine(chosenbox);
                    TextBox tbx = this.Controls.Find(chosenbox, true).FirstOrDefault() as TextBox;
                    if (tbx.BackColor != Color.Black) {
                        whiteCounter++;
                        if (whiteCounter == 3) {
                            sleepTime = 0;
                        }
                    }
                    if (tbx.ForeColor == Color.Black)
                    {
                        whiteCounter=0;
                    }
                    Console.WriteLine(tbx.Text);
                    tbx.ForeColor = Color.White;
                    tbx.Refresh();
                    Thread.Sleep(sleepTime);
                    
                    count2++;
                }
                
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
                string message = "Good Job, Enjoy the spin.";
                MessageBox.Show(message);
                this.Hide();
                string[] lines = File.ReadAllLines("fortunes.txt");
                Wheel winWheel = new Wheel(lines);
                winWheel.Show();
            }

            if(guessCorrect == false)
            {
                SoundPlayer goodbyeDuck = new SoundPlayer("gunshot.wav");
                int numbguessesleft = Int32.Parse(Global.guesseslefty);
                var ducktoremove = numbguessesleft;
                if (ducktoremove == 5)
                {
                    goodbyeDuck.Play();
                    Thread.Sleep(250);
                    duck5.BackgroundImage = Properties.Resources.deadduck;
                }
                if (ducktoremove == 4)
                {
                    goodbyeDuck.Play();
                    Thread.Sleep(250);
                    duck4.BackgroundImage = Properties.Resources.deadduck;
                }
                if (ducktoremove == 3)
                {
                    goodbyeDuck.Play();
                    Thread.Sleep(250);
                    duck3.BackgroundImage = Properties.Resources.deadduck;
                }
                if (ducktoremove == 2)
                {
                    goodbyeDuck.Play();
                    Thread.Sleep(250);
                    duck2.BackgroundImage = Properties.Resources.deadduck;
                }
                if (ducktoremove == 1)
                {
                    goodbyeDuck.Play();
                    Thread.Sleep(250);
                    duck1.BackgroundImage = Properties.Resources.deadduck;
                }

                numbguessesleft--;
                Global.guesseslefty = numbguessesleft.ToString();
                GuessLbl.Text = "Guesses Left: ";
                if (numbguessesleft == 0)
                {
                    var count3 = 0;
                    var whiteCounter = 0;
                    var sleepTime = 400;
                    while (count3 < 52)
                    {
                        var chosenbox = "letterBox" + (count3 + 1);
                        Console.WriteLine(chosenbox);
                        TextBox tbx = this.Controls.Find(chosenbox, true).FirstOrDefault() as TextBox;
                        if (tbx.BackColor != Color.Black)
                        {
                            whiteCounter++;
                            if (whiteCounter == 3)
                            {
                                sleepTime = 0;
                            }
                        }
                        if (tbx.ForeColor == Color.Black)
                        {
                            whiteCounter = 0;
                        }
                        Console.WriteLine(tbx.Text);
                        tbx.ForeColor = Color.White;
                        tbx.Refresh();
                        Thread.Sleep(sleepTime);

                        count3++;
                    }
                    string message = "Hold this L. Off to the wheel of misfortune";
                    MessageBox.Show(message);
                    this.Hide();
                    string[] lines = File.ReadAllLines("misfortunes.txt");
                    Wheel misWheel = new Wheel(lines);
                    misWheel.Show();
                }
                    
            }

            guessBox.Text = "";
        }

        static string[] lines = File.ReadAllLines("Phrases.txt");
        bool[] picked_questions = new bool[lines.Length];

        private void GuessGame_Load(object sender, EventArgs e)
        {
            var lastLine = File.ReadLines("currentplayer.txt").Last();
            string[] getscore = lastLine.Split(',');
            lblScore.Text = "?" + getscore[1];
            Global2.giveupchecky = "0";
            Global.guesseslefty = "5";
            
            Random rand = new Random();
            int chosen_index = rand.Next(lines.Length);
            picked_questions[chosen_index] = true;
            var chosenline = lines[chosen_index];
            string[] parts = chosenline.Split(',');
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
                    tbx.HideSelection = true;
                    var letterToWrite = characters[count];
                    var converted = letterToWrite.ToString();
                    tbx.Text = converted;

                    bool result = Char.IsWhiteSpace(letterToWrite);

                    if (result != true)
                    {
                        tbx.ForeColor = Color.Black;
                        tbx.BackColor = Color.Black;
                    }

                    if(letterToWrite is ';' || letterToWrite is '-')
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

            if (getscore[1] != "0")
            {


                WinForm winform = new WinForm();
                winform.Show();
                this.Hide();
            }

            else {
                WhatForm whatform = new WhatForm();
                whatform.Show();
                this.Hide();
            }
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

        private void HintLbl_Click(object sender, EventArgs e)
        {

        }
        private void QuestLbl_Click(object sender, EventArgs e)
        {

        }

        private void guessBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                guessBtn_Click(this, new EventArgs());
            }
        }

        private void guessBox_TextChanged(object sender, KeyEventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
