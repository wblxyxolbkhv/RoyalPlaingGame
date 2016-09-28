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

namespace VisualPart
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
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

            PhysicalObject obj = new PhysicalObject();
            obj.Position = new Vector2(e.X, e.Y);
            obj.Width = 50;
            obj.Height = 50;
            obj.Mass = 5;
            obj.Powers.Add(new Power(new Vector2(0, 1), 0.01));
            objects.Add(obj);
        }

    }
}
