namespace SnakeGame
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.StartButton = new System.Windows.Forms.Button();
            this.SnapButton = new System.Windows.Forms.Button();
            this.pictureCanvas = new System.Windows.Forms.PictureBox();
            this.txtScore = new System.Windows.Forms.Label();
            this.txtHighScore = new System.Windows.Forms.Label();
            this.GameTimerEvent = new System.Windows.Forms.Timer(this.components);
            this.cbxlevel = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.AutoSize = true;
            this.StartButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.StartButton.Location = new System.Drawing.Point(42, 22);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(140, 73);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartGame);
            // 
            // SnapButton
            // 
            this.SnapButton.BackColor = System.Drawing.Color.SkyBlue;
            this.SnapButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.SnapButton.Location = new System.Drawing.Point(213, 22);
            this.SnapButton.Name = "SnapButton";
            this.SnapButton.Size = new System.Drawing.Size(140, 73);
            this.SnapButton.TabIndex = 1;
            this.SnapButton.Text = "Snap";
            this.SnapButton.UseVisualStyleBackColor = false;
            this.SnapButton.Click += new System.EventHandler(this.TakeSnapShot);
            // 
            // pictureCanvas
            // 
            this.pictureCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureCanvas.BackColor = System.Drawing.Color.Plum;
            this.pictureCanvas.Location = new System.Drawing.Point(-3, 139);
            this.pictureCanvas.Name = "pictureCanvas";
            this.pictureCanvas.Size = new System.Drawing.Size(907, 466);
            this.pictureCanvas.TabIndex = 3;
            this.pictureCanvas.TabStop = false;
            this.pictureCanvas.Click += new System.EventHandler(this.pictureCanvas_Click);
            this.pictureCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdatePictureBox);
            // 
            // txtScore
            // 
            this.txtScore.AutoSize = true;
            this.txtScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtScore.Location = new System.Drawing.Point(601, 22);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(94, 25);
            this.txtScore.TabIndex = 4;
            this.txtScore.Text = "Score: 0";
            // 
            // txtHighScore
            // 
            this.txtHighScore.AutoSize = true;
            this.txtHighScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtHighScore.Location = new System.Drawing.Point(601, 70);
            this.txtHighScore.Name = "txtHighScore";
            this.txtHighScore.Size = new System.Drawing.Size(119, 25);
            this.txtHighScore.TabIndex = 5;
            this.txtHighScore.Text = "High Score";
            // 
            // GameTimerEvent
            // 
            this.GameTimerEvent.Interval = 40;
            this.GameTimerEvent.Tick += new System.EventHandler(this.GameTimer);
            // 
            // cbxlevel
            // 
            this.cbxlevel.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cbxlevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbxlevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxlevel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxlevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbxlevel.ForeColor = System.Drawing.Color.Black;
            this.cbxlevel.FormattingEnabled = true;
            this.cbxlevel.Items.AddRange(new object[] {
            "Dễ ",
            "Khó"});
            this.cbxlevel.Location = new System.Drawing.Point(424, 22);
            this.cbxlevel.Name = "cbxlevel";
            this.cbxlevel.Size = new System.Drawing.Size(121, 39);
            this.cbxlevel.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 605);
            this.Controls.Add(this.cbxlevel);
            this.Controls.Add(this.txtHighScore);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.pictureCanvas);
            this.Controls.Add(this.SnapButton);
            this.Controls.Add(this.StartButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SnakeGame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button SnapButton;
        private System.Windows.Forms.PictureBox pictureCanvas;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Label txtHighScore;
        private System.Windows.Forms.Timer GameTimerEvent;
        private System.Windows.Forms.ComboBox cbxlevel;
    }
}

