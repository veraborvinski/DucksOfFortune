namespace DuckOfFortune
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.btnScores = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(551, 356);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(111, 68);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnScores
            // 
            this.btnScores.BackColor = System.Drawing.Color.Transparent;
            this.btnScores.Location = new System.Drawing.Point(551, 450);
            this.btnScores.Name = "btnScores";
            this.btnScores.Size = new System.Drawing.Size(111, 70);
            this.btnScores.TabIndex = 1;
            this.btnScores.Text = "High Scores";
            this.btnScores.UseVisualStyleBackColor = false;
            this.btnScores.Click += new System.EventHandler(this.btnScores_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(551, 544);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(111, 69);
            this.btnQuit.TabIndex = 2;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLbl.Location = new System.Drawing.Point(410, 172);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(405, 59);
            this.TitleLbl.TabIndex = 3;
            this.TitleLbl.Text = "Duck Of Fortune";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1178, 844);
            this.Controls.Add(this.TitleLbl);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnScores);
            this.Controls.Add(this.btnStart);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnScores;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label TitleLbl;
    }
}

