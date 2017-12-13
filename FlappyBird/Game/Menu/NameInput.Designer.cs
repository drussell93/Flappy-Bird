namespace FlappyBird.Game.Menu
{
    partial class NameInput
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
            this.userInput = new System.Windows.Forms.TextBox();
            this.submit = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userInput
            // 
            this.userInput.Location = new System.Drawing.Point(154, 112);
            this.userInput.Name = "userInput";
            this.userInput.Size = new System.Drawing.Size(100, 26);
            this.userInput.TabIndex = 0;
            this.userInput.TextChanged += new System.EventHandler(this.userInput_TextChanged);
            this.userInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NameInputKeyPress);
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(154, 163);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(75, 23);
            this.submit.TabIndex = 1;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(154, 209);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 2;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // NameInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Controls.Add(this.close);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.userInput);
            this.Name = "NameInput";
            this.Text = "NameInput";
            this.Load += new System.EventHandler(this.NameInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button submit;
        public System.Windows.Forms.TextBox userInput;
        private System.Windows.Forms.Button close;
    }
}