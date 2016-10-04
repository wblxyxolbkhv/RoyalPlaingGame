using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace RoyalPlayingGame
{
    public class GameLevel
    {
        public Player player;
        public PlayerMenu playerMenu;
        public VisualPart.UserControls.PlayerMenu VisualMenu;
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                VisualMenu.Visible = true;
                double w = (double)VisualMenu.Parent.Width / 2.0;
                double h = (double)VisualMenu.Parent.Height / 2.0;
                VisualMenu.Location = new Point((int)(w - VisualMenu.Size.Width),
                    (int)(h - VisualMenu.Size.Height));
            }
        }

    }
}
