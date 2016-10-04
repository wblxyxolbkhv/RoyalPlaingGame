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

namespace TestProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            objects = new List<PhysicalObject>();
            t.Tick += T_Tick;
            t.Interval = 20;
            t.Start();

            player = new PhysicalObject();
            player.Position = new Vector2(0, 0);
            player.Width = 50;
            player.Height = 50;
            player.Mass = 5;

            player.MinX = 0;
            player.MinY = 0;
            player.MaxX = pictureBox1.Width - player.Width;
            player.MaxY = pictureBox1.Height - player.Height;

            player.Powers.Add(new Power(new Vector2(0, 1), 0.01));

            RoyalPlayingGame.GameLevel level1 = new RoyalPlayingGame.GameLevel();
            //level1.VisualMenu = 
        }

        private void T_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        Timer t = new Timer();
        List<PhysicalObject> objects;
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            for (int i = 0; i < objects.Count; i++)
            {
                e.Graphics.FillRectangle(Brushes.Black,
                    (int)(objects[i].Position.X),
                    (int)(objects[i].Position.Y),
                    (int)(objects[i].Width),
                    (int)(objects[i].Height));
            }
            e.Graphics.FillRectangle(Brushes.Red,
                    (int)(player.Position.X),
                    (int)(player.Position.Y),
                    (int)(player.Width),
                    (int)(player.Height));
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

            PhysicalObject obj = new PhysicalObject();
            obj.Position = new Vector2(e.X, e.Y);
            obj.Width = 50;
            obj.Height = 50;
            obj.Mass = 5;

            obj.MinX = 0;
            obj.MinY = 0;
            obj.MaxX = pictureBox1.Width - obj.Width;
            obj.MaxY = pictureBox1.Height - obj.Height;

            obj.Powers.Add(new Power(new Vector2(0, 1), 0.01));
            objects.Add(obj);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                player.Powers.Add(rightPower);
            }
        }
        Power leftPower = new Power(new Vector2(-1, 0), 0.01);
        Power rightPower = new Power(new Vector2(1, 0), 0.01);
        PhysicalObject player;
    }
}
