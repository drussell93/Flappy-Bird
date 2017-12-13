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
    public partial class NameInput : Form
    {

        public NameInput()
        {
            InitializeComponent();
            Size = new Size(455, 331);
            BackColor = Color.LightBlue;
        }

        private void NameInput_Load(object sender, EventArgs e)
        {
            Panel textPanel = new Panel();
            Label name = new Label();
            name.Font = new Font(name.Font.FontFamily, 16);
            name.TextAlign = ContentAlignment.MiddleCenter;
            name.Text = "Enter name ";
            name.Size = new Size(300, 50);

            userInput.Size = new Size(100, 50);
            submit.Size = new Size(100, 25);
            close.Size = new Size(100, 25);

            textPanel.Location = new Point(20, 10);
            textPanel.Size = new Size(500, 300);

            textPanel.Controls.Add(name);
            textPanel.Controls.Add(userInput);
            textPanel.Controls.Add(submit);
            textPanel.Controls.Add(close);
 
            this.Controls.Add(textPanel);
        }

        private void userInput_TextChanged(object sender, EventArgs e)
        {
  
        }

        private void NameInputKeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void submit_Click(object sender, EventArgs e)
        {
            if (userInput.Text != null)
            {
                MessageBox.Show("Name added: " + userInput.Text); 
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
