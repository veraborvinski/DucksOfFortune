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

        IDictionary<string, int> hScores = new Dictionary<string, int>();

        private void HighScore_Load(object sender, EventArgs e)
        {
            string[] scores;
            // Read the file and add the scores to a dictionary  
            foreach (string line in File.ReadLines("Scores.txt"))
            {
                scores = line.Split(',');
                hScores.Add(scores[0], Int32.Parse(scores[1]));
                Array.Clear(scores, 0, scores.Length);
            }
            List<int> scoreNums = new List<int>();
            //finding the FIRST, SECOND and THIRD max
            int max=0;
            string firstPlayer="";
            foreach (var dict in hScores)
            {
                if (dict.Value > max)
                {
                    max = dict.Value;
                    firstPlayer = dict.Key;
                }
            }
            int secondMax = 0;
            string secondPlayer = "";
            foreach (var dict in hScores)
            {
                if (dict.Value > secondMax)
                {
                    if (dict.Value == max)
                    {
                        continue;
                    } else
                    {
                        secondMax = dict.Value;
                        secondPlayer = dict.Key;
                    }
                }
            }
            int thirdMax = 0;
            string thirdPlayer = "";
            foreach (var dict in hScores)
            {
                if (dict.Value > thirdMax)
                {
                    if (dict.Value == max || dict.Value == secondMax)
                    {
                        continue;
                    }
                    else
                    {
                        thirdMax = dict.Value;
                        thirdPlayer = dict.Key;
                    }
                }
            }
            

            first.Text = "1. " + max + " by " + firstPlayer;

            second.Text = "2. " + secondMax + " by " + secondPlayer;

            third.Text = "3. " + thirdMax + " by " + thirdPlayer;
        }


        


        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }
    }
}
