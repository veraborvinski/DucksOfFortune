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



        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines("Phrases.txt");
            Random rand = new Random();
            var chosenline = lines[rand.Next(lines.Length)];
            Console.WriteLine(chosenline);
            char[] characters = chosenline.ToCharArray();
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

        private void guessBtn_Click(object sender, EventArgs e)
        {
            String guess = guessBox.Text;
            string guessupper = guess.ToUpper();
            string guesslower = guess.ToLower();
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
            }


        }

        private void GuessGame_Load(object sender, EventArgs e)
        {

        }
    }
}
