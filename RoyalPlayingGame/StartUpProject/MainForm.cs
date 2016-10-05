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
        GameLevel Level;
        public MainForm()
        {
            InitializeComponent();

            Level = new GameLevel();


            #region Инициализация меню, событий


            RoyalPlayingGame.GameLevel level1 = new RoyalPlayingGame.GameLevel();
            level1.VisualMenu = this.playerMenu1;

            this.KeyDown += Level.OnKeyDownExternal;
            this.KeyUp += Level.OnKeyUpExternal;
            pictureBox1.Paint += Level.OnPrintAllObjects;
            this.KeyPreview = true;


            //pictureBox1.MouseClick += pictureBox1_MouseClick;
            t.Tick += Level.OnRefresh;
            t.Tick += T_Tick;
            t.Interval = 20;
            t.Start();

            #endregion



        }
        

        private void T_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        Timer t = new Timer();

        #region Рудименты отладки

        /*
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
        */

        #endregion

    }
}
