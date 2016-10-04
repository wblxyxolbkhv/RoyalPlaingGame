using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using VisualPart.UserControls;

namespace RoyalPlayingGame
{
    public class GameLevel
    {
        public Player player;
        public PlayerMenu playerMenu;
        public VisualPart.UserControls.PlayerMenu VisualMenu;


        private bool IsMenuShowed { get; set; }



        public void OnKeyDownExternal(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
            {
                if (IsMenuShowed)
                {
                    IsMenuShowed = false;
                    VisualMenu.Visible = false;
                }
                else
                {
                    IsMenuShowed = true;
                    VisualMenu.Visible = true;
                    double w = (double)VisualMenu.Parent.Width / 2.0;
                    double h = (double)VisualMenu.Parent.Height / 2.0;
                    VisualMenu.Location = new Point((int)(w - (double)VisualMenu.Size.Width / 2.0),
                        (int)(h - (double)VisualMenu.Size.Height / 2.0));
                    VisualMenu.Parent.Focus();
                }

            }
        }

    }
}
