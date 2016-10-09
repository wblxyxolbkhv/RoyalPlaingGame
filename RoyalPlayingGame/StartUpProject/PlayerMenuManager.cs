using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Units;
using VisualPart.UserControls;
using System.Windows.Forms;
using System.Drawing;

namespace StartUpProject
{
    public class PlayerMenuManager
    {
        public Player player;
        public PlayerMenu VisualMenu;


        private bool IsMenuShowed { get; set; }

        public void OnMenuRefresh(object sender, EventArgs e)
        {
            VisualMenu.MaxHP = (int)player.Health;
            VisualMenu.RealHP = (int)player.RealHealth;

            VisualMenu.MaxMP = (int)player.Mana;
            VisualMenu.RealMP = (int)player.RealMana;

            VisualMenu.Strengh = (int)player.Strength;
            VisualMenu.RealStrengh = (int)player.RealStrength;

            VisualMenu.Agility = (int)player.Agility;
            VisualMenu.RealAgility = (int)player.RealAgility;

            VisualMenu.Intelegence = (int)player.Intelligence;
            VisualMenu.RealIntelegence = (int)player.RealIntelligence;
        }

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
