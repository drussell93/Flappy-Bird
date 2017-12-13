using System;
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
    public partial class MenuDisplay : Form
    {
        public MenuDisplay()
        {
            InitializeComponent();
            Size = new Size(455, 331);
            BackColor = Color.LightBlue;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            Panel textPanel = new Panel();
            Label instructions = new Label();
            instructions.Font = new Font(instructions.Font.FontFamily, 16);
            instructions.TextAlign = ContentAlignment.MiddleCenter;
            instructions.Text = "Spacebar gives the bird lift\nWatch out for obstacles\n\nPress enter to return\nPress tab to see high scores";
            textPanel.Location = new Point(20, 10);
            instructions.Size = new Size(400, 300);
            textPanel.Size = new Size(400, 300);  
            textPanel.Controls.Add(instructions);
            this.Controls.Add(textPanel);
        }

        private void MenuKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.Close(); 
            }
            if (e.KeyChar == (char)Keys.Tab)
            {
                HighScores highScores = new HighScores();
                highScores.Show();
                this.Close();         
            }
        }
    }
}
