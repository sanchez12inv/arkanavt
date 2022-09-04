using AlkoTowerDefence.Objects;
using System;
using System.Windows.Forms;

namespace AlkoTowerDefence
{
    public partial class Form1 : Form
    {
        private Game game = new Game();
        private Player player = new Player();

        public Form1()
        {
            InitializeComponent();

            Height = Screen.PrimaryScreen.Bounds.Height - 100;
            Cursor.Hide();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game.StartGame(new ScreenRectangle(pictureBox1), player);
            game.AddPlayer(player);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            game.UpdateDraw(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            game.UpdateGame();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            game.UpdateControll(e);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            game.UpdateControll(e);
        }

        private void timerEnemy_Tick(object sender, EventArgs e)
        {
            game.RespawnEnemy<Enemy1>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true && timerEnemy.Enabled == true)
            {
                buttonPause.Text = "►";
                timer1.Enabled = false;
                timerEnemy.Enabled = false;
            }
            else
            {
                buttonPause.Text = "||";
                timer1.Enabled = true;
                timerEnemy.Enabled = true;
            }
        }
    }
}
