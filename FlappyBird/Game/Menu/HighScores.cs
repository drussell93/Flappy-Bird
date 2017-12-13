using System;
using System.IO; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird.Game.Menu
{
    public partial class HighScores : Form
    {
        public HighScores()
        {
            InitializeComponent();
            Size = new Size(455, 331);
            BackColor = Color.LightBlue;
        }

        private void HighScores_Load(object sender, EventArgs e)
        {
            // Read high scores for HighScores.txt
            var projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            var file = Path.Combine(projectFolder, @"Game\Data\HighScores.txt");

            string scores = File.ReadAllText(file);

            Panel textPanel = new Panel();

            // Display high scores
            Label highScores = new Label();
            highScores.Font = new Font(highScores.Font.FontFamily, 16);
            highScores.TextAlign = ContentAlignment.MiddleCenter;
            highScores.Text = scores + "\nPress enter to return";

            Label title = new Label();
            title.Font = new Font(title.Font.FontFamily, 16);
            title.TextAlign = ContentAlignment.MiddleCenter;
            title.Text = "High Scores";

            textPanel.Location = new Point(20, 10);
            highScores.Size = new Size(400, 350);//250
            title.Size = new Size(400, 50);
            textPanel.Size = new Size(400, 500);

            textPanel.Controls.Add(title);
            textPanel.Controls.Add(highScores);

            this.Controls.Add(textPanel);
        }

        private void HighScoresKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.Close();
            }
        }
    }
}
