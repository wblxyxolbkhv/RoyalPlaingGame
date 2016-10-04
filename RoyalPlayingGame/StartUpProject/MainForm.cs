using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimplePhysicalEngine;
using SimplePhysicalEngine.NonPhysicalComponents;

namespace StartUpProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            #region Инициализация меню, событий

            RoyalPlayingGame.GameLevel level1 = new RoyalPlayingGame.GameLevel();
            level1.VisualMenu = this.playerMenu1;

            this.KeyDown += level1.OnKeyDownExternal;
            this.KeyDown += MainForm_KeyDown;
            this.KeyUp += OnKeyUp;
            pictureBox1.MouseClick += pictureBox1_MouseClick;
            pictureBox1.Paint += pictureBox1_Paint;
            this.KeyPreview = true;
            t.Tick += T_Tick;
            t.Interval = 20;
            t.Start();

            #endregion

            gravity = new Power(0.01 * new Vector2(0, 1));

            player = new RealObject(objects, gravity);
            player.Position = new Vector2(400, 400);
            player.Height = 50;
            player.Width = 50;
            player.SpeedX = 8;
            player.Start();

            ground = new RealObject(objects);
            ground.Position = new Vector2(20, 600);
            ground.Height = 10;
            ground.Width = 800;
            ground.SpeedX = 8;
            ground.Start();

        }

        Power gravity;
        List<RealObject> objects = new List<RealObject>();
        RealObject player;
        RealObject ground;

        private void T_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        Timer t = new Timer();
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (RealObject o in objects)
            {
                e.Graphics.FillRectangle(Brushes.Black, (float)o.Position.X, (float)o.Position.Y, (float)o.Width, (float)o.Height);
            }
            e.Graphics.FillRectangle(Brushes.Red, (float)player.Position.X, (float)player.Position.Y, (float)player.Width, (float)player.Height);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                RealObject o = new RealObject(objects, gravity);
                o.Position = new Vector2(e.X, e.Y);
                o.Height = 50;
                o.Width = 50;
                o.SpeedX = 8;
                o.Start();
            }
            else
            {
                player.Position = new Vector2(e.X, e.Y);
            }

        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    player.direction = Direction.Right;
                    break;
                case Keys.A:
                    player.direction = Direction.Left;
                    break;
                case Keys.W:
                    player.Jump(-1);
                    break;
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    player.direction = Direction.None;
                    break;
                case Keys.A:
                    player.direction = Direction.None;
                    break;
            }
        }
    }
}
