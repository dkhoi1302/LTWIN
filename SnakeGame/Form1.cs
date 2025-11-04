using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Hello world 123
namespace SnakeGame
{
    public partial class Form1 : Form
    {
        int speed = 200;

        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();

        int maxWidth;
        int maxHeight;

        int score;
        int highScore;

        Random rand = new Random();

        bool goLeft, goRight, goDown, goUp;

        private string highScoreFile = "highscore.txt"; // File lưu highscore

        public Form1()
        {
            InitializeComponent();

            new Settings();

            this.KeyDown += new KeyEventHandler(KeyIsDown);
            this.KeyUp += new KeyEventHandler(KeyIsUp);
            this.KeyPreview = true;
            this.GameTimerEvent.Tick += new EventHandler(GameTimer);

            GameTimerEvent.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadHighScore(); // Load highscore khi mở game
        }

        private void LoadHighScore()
        {
            if (File.Exists(highScoreFile))
            {
                string scoreText = File.ReadAllText(highScoreFile);
                int.TryParse(scoreText, out highScore);
            }
            else
            {
                highScore = 0;
            }

            txtHighScore.Text = "High Score: " + highScore;
            txtHighScore.ForeColor = Color.Maroon;
            txtHighScore.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void SaveHighScore()
        {
            File.WriteAllText(highScoreFile, score.ToString(), Encoding.UTF8);
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Settings.directions != "right")
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right && Settings.directions != "left")
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Up && Settings.directions != "down")
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down && Settings.directions != "up")
            {
                goDown = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) goLeft = false;
            if (e.KeyCode == Keys.Right) goRight = false;
            if (e.KeyCode == Keys.Up) goUp = false;
            if (e.KeyCode == Keys.Down) goDown = false;
        }

        private void StartGame(object sender, EventArgs e)
        {
            GameTimerEvent.Stop();

            goLeft = goRight = goUp = goDown = false;

            if (cbxlevel.SelectedItem != null)
            {
                switch (cbxlevel.SelectedItem.ToString())
                {
                    case "Dễ": speed = 500; break;
                    case "Khó": speed = 50; break;
                    default: speed = 200; break;
                }
            }
            else
            {
                speed = 150;
            }

            GameTimerEvent.Interval = speed;

            RestartGame();
            GameTimerEvent.Start();

            cbxlevel.Enabled = false;

            this.ActiveControl = null;
            this.Focus();
        }

        private void TakeSnapShot(object sender, EventArgs e)
        {
            Label caption = new Label();
            caption.Name = "scoreCaption";
            caption.Text = "I scored: " + score + " and my Highscore is " + highScore + " on the Snake Game from Nhóm 6";
            caption.Font = new Font("Arial", 12, FontStyle.Bold);
            caption.ForeColor = Color.MediumVioletRed;
            caption.AutoSize = false;
            caption.Width = pictureCanvas.Width;
            caption.Height = 30;
            caption.TextAlign = ContentAlignment.MiddleCenter;

            pictureCanvas.Controls.Add(caption);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "Snake Game SnapShot Nhom6";
            dialog.DefaultExt = "jpg";
            dialog.Filter = "JPG Image File | *.jpg";
            dialog.ValidateNames = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int width = pictureCanvas.Width;
                int height = pictureCanvas.Height;

                Bitmap bmp = new Bitmap(width, height);
                pictureCanvas.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                bmp.Save(dialog.FileName, ImageFormat.Jpeg);
            }
            pictureCanvas.Controls.Remove(caption);
        }

        private void GameTimer(object sender, EventArgs e)
        {
            if (goLeft) Settings.directions = "left";
            if (goRight) Settings.directions = "right";
            if (goDown) Settings.directions = "down";
            if (goUp) Settings.directions = "up";

            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.directions)
                    {
                        case "left": Snake[i].X--; break;
                        case "right": Snake[i].X++; break;
                        case "down": Snake[i].Y++; break;
                        case "up": Snake[i].Y--; break;
                    }

                    if (Snake[i].X < 0) Snake[i].X = maxWidth;
                    if (Snake[i].X > maxWidth) Snake[i].X = 0;
                    if (Snake[i].Y < 0) Snake[i].Y = maxHeight;
                    if (Snake[i].Y > maxHeight) Snake[i].Y = 0;

                    if (Snake[i].X == food.X && Snake[i].Y == food.Y) EatFood();

                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            GameOver();
                        }
                    }
                }
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }

            pictureCanvas.Invalidate();
        }

        private void UpdatePictureBox(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            for (int i = 0; i < Snake.Count; i++)
            {
                Brush snakeColour = (i == 0) ? Brushes.Black : Brushes.DarkGreen;

                canvas.FillEllipse(snakeColour, new Rectangle(
                    Snake[i].X * Settings.Width,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                ));
            }

            canvas.FillEllipse(Brushes.DarkRed, new Rectangle(
                food.X * Settings.Width,
                food.Y * Settings.Height,
                Settings.Width, Settings.Height
            ));
        }

        public void SoundPlay(string Amthanh)
        {
            string path = @"Resoucre\anmoi.wav";
            if (File.Exists(path))
            {
                SoundPlayer player = new SoundPlayer(path);
                player.Play();
            }
            else
            {
                MessageBox.Show("Không tìm thấy file âm thanh: " + path);
            }
        }

        public void SoundEndgame(string Amthanh)
        {
            string path = @"Resoucre\thuagame.wav";
            if (File.Exists(path))
            {
                SoundPlayer player = new SoundPlayer(path);
                player.Play();
            }
            else
            {
                MessageBox.Show("Không tìm thấy file âm thanh: " + path);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveHighScore(); 
            if (MessageBox.Show("Bạn có chắc là muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void RestartGame()
        {
            foreach (Control ctrl in pictureCanvas.Controls.OfType<Label>().ToList())
            {
                pictureCanvas.Controls.Remove(ctrl);
            }

            maxWidth = pictureCanvas.Width / Settings.Width - 1;
            maxHeight = pictureCanvas.Height / Settings.Height - 1;

            Snake.Clear();

            StartButton.Enabled = false;
            SnapButton.Enabled = false;
            score = 0;
            txtScore.Text = "Score: " + score;

            Circle head = new Circle { X = 10, Y = 5 };
            Snake.Add(head);

            for (int i = 0; i < 10; i++)
            {
                Circle body = new Circle();
                Snake.Add(body);
            }

            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };

            GameTimerEvent.Start();
        }

        private void EatFood()
        {
            SoundPlay("anmoi");
            score += 1;
            txtScore.Text = "Score: " + score;

            Circle body = new Circle
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };
            Snake.Add(body);

            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };
        }
        private void pictureCanvas_Click(object sender, EventArgs e)
        {
            
        }
        private void GameOver()
        {
            SoundEndgame("thuagame");
            GameTimerEvent.Stop();
            StartButton.Enabled = true;
            SnapButton.Enabled = true;

            if (score > highScore)
            {
                highScore = score;
                txtHighScore.Text = "High Score: " + Environment.NewLine + highScore;
                txtHighScore.ForeColor = Color.Maroon;
                txtHighScore.TextAlign = ContentAlignment.MiddleCenter;

                SaveHighScore(); 
            }

            cbxlevel.Enabled = true;
        }
    }
}
