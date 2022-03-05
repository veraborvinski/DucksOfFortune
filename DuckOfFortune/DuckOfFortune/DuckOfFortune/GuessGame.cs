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



                    foreach (Control control in Controls)
                    {
                        if (control is TextBox)
                        {
                            //Investigate and do your thing
                        }
                    }

                    Console.WriteLine("test2");
                    var letterToWrite = characters[count];
                  

                    count++;
                }
            }



        }
    }
}
