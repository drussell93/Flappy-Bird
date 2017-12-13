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
using FlappyBird.Game; 

namespace FlappyBird
{
    public partial class GameWindow : Form
    {
        // Create game objects 
        Bird bird = new Bird();
        Pipe pipes = new Pipe();
        LowerPipe lowerPipe = new LowerPipe();
        UpperPipe upperPipe = new UpperPipe();    
        EndGame collision = null;

        // List for game object picture boxes 
        List<PictureBox> pictureBoxList = new List<PictureBox>();  

        // Constructor 
        public GameWindow()
        {
            InitializeComponent();

            // Form properties 
            StartPosition = FormStartPosition.CenterScreen; 
            BackColor = Color.LightBlue; 
            MaximumSize = new Size(655, 531);
            Size = new Size(655, 531);

            // Label properties
            scoreText.Text = "0";
            instructions.Text = "Press s to start, enter for menu, tab for name input";
            instructions.Font = new Font(instructions.Font.FontFamily, 14);
            instructions.Location = new Point(100, 200);
            instructions.Visible = true; 

            // Collision event 
            collision = new EndGame(); 
            collision.CollisionOccurrence += new CollisionOccurrenceEventHandler(collision_CollisionOccurrence);
           
            // Add objects to list
            pictureBoxList.Add((PictureBox)Controls.Find("pipeBottom", true)[0]);
            pictureBoxList.Add((PictureBox)Controls.Find("pipeTop", true)[0]);
            pictureBoxList.Add((PictureBox)Controls.Find("flappyBird", true)[0]);

            pictureBoxList[0].Size = new Size(100, 250);
            pictureBoxList[1].Size = new Size(100, 250);

            pictureBoxList[0].Location = new Point(428, 300);
            pictureBoxList[1].Location = new Point(321, -100);

            // Disable game timer until user input 
            gameTimer.Enabled = false;      
        }
      
        private void GameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                bird.Jumping = true;
                bird.Gravity = -10;
            }

            if (e.KeyCode == Keys.S)
            {
                gameTimer.Stop(); 
            }

        }

        private void GameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                bird.Jumping = false;
                bird.Gravity = 3;
            }

            if (e.KeyCode == Keys.S)
            {
                gameTimer.Enabled = true;
                instructions.Visible = false; 
            }
        }

        private void GameKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Game.Menu.MenuDisplay menuDisplay = new Game.Menu.MenuDisplay();
                menuDisplay.Show();
            }
            if (e.KeyChar == (char)Keys.Tab)
            {
                ShowNameInput(); 
            }

        }

        private void gameTimer_Tick_1(object sender, EventArgs e)
        {    
            // Set speed of scroll
            pictureBoxList[0].Left -= lowerPipe.Speed;
            pictureBoxList[1].Left -= upperPipe.Speed;

            // Apply gravity to the bird object 
            flappyBird.Top += bird.Gravity;

            // Update labels
            scoreText.Text = Convert.ToString(bird.Score); 

            // Logic for repeating the lower pipe
            if (pictureBoxList[0].Left < -80)
            {
                pictureBoxList[0].Left = lowerPipe.RandomizePosition();
                lowerPipe.RandomizeHeight();

                pictureBoxList[0].Size = new Size(100, 250);
                pictureBoxList[0].Location = new Point(pictureBoxList[0].Left, lowerPipe.Height);

                //lowerPipe.IncreaseSpeed(); 
                bird.Score += 1; 
            }
            // logic for repeating the upper pipe
            else if (pictureBoxList[1].Left < -95)
            {
                pictureBoxList[1].Left = upperPipe.RandomizePosition();
                upperPipe.RandomizeHeight();

                pictureBoxList[1].Size = new Size(100, 250);
                pictureBoxList[1].Location = new Point(pictureBoxList[1].Left, upperPipe.Height);
                pipes.IncreaseSpeed();

                //upperPipe.IncreaseSpeed(); 
                bird.Score += 1; 
            }

            // Logic for bird collisions with pipes, ground, and upper boundary
            if (flappyBird.Bounds.IntersectsWith(ground.Bounds))
            {
                CollisionOccurred();
            }
            else if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds))
            {
                CollisionOccurred();
            }
            else if (flappyBird.Bounds.IntersectsWith(pipeTop.Bounds))
            {
                CollisionOccurred();
            }
            else if (flappyBird.Location.Y <= 0)
            {
                BoundaryHit(); 
            }
                
        }

        // Calls delegate to raise event 
        private void CollisionOccurred()
        {
            collision.Collision = true;
            gameTimer.Stop();
            collision.didCollide();
        }

        // "Bounces" the bird off the top of the screen
        private void BoundaryHit()
        {
            flappyBird.Location = new Point(32, 1);
        }

        // Reset game 
        private void ReloadForm()
        {        
            pictureBoxList[0].Location = new Point(628, 300);
            pictureBoxList[1].Location = new Point(321, -100);
            pictureBoxList[2].Location = new Point(32, 103); //53

            // Reset space key to up position (prevents automatic flying on restart)
            object sender = DialogResult.Yes;
            KeyEventArgs e = new KeyEventArgs(Keys.Space); 
            GameKeyUp(sender, e);

            KeyEventArgs e2 = new KeyEventArgs(Keys.S);
            GameKeyDown(sender, e2);
            //
            bird.Score = 0;

            // Restart the timer 
            gameTimer.Dispose();
            gameTimer.Start(); 
        }

        // Event for collision
        private void collision_CollisionOccurrence(object sender, CollisionOccurrenceEventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
           
            string message = "Play Again?";
            string caption = "Game Over!";

            result = MessageBox.Show(this, message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                RecordResults(); 
                ReloadForm(); 
            }
            else if (result == DialogResult.No)
            {
                RecordResults();
                this.Close();
            }
        }

        // Records score to Scores.txt
        private void RecordResults()
        {
            string name = bird.Name;
            string score = Convert.ToString(bird.Score);

            var projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            var file = Path.Combine(projectFolder, @"Game\Data\Scores.txt");

            File.AppendAllText(file, name + ": " + score + Environment.NewLine);
        }

        private void GameWindow_Load(object sender, EventArgs e)
        { }

        public void ShowNameInput()
        {
            Game.Menu.NameInput name = new Game.Menu.NameInput();


            name.ShowDialog(this);
            if(name.userInput.Text != null)
            {
                bird.Name = name.userInput.Text; 
            }
            name.Dispose();
        }
    }
}
