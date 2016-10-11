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

        public Scale ScaleHP { get;
            set; }
        public Scale ScaleMP { get;
            set; }


        private bool IsMenuShowed { get; set; }

        public void OnMenuRefresh(object sender, EventArgs e)
        {
            ScaleHP.CurrentValue = player.RealHealth;
            ScaleHP.MaxValue = player.Health;

            ScaleMP.CurrentValue = player.RealMana;
            ScaleMP.MaxValue = player.Mana;

            VisualMenu.MaxHP = player.Health;
            VisualMenu.RealHP = player.RealHealth;

            VisualMenu.MaxMP = player.Mana;
            VisualMenu.RealMP = player.RealMana;

            VisualMenu.Strengh = player.Strength;
            VisualMenu.RealStrengh = player.RealStrength;

            VisualMenu.Agility = player.Agility;
            VisualMenu.RealAgility = player.RealAgility;

            VisualMenu.Intelegence = player.Intelligence;
            VisualMenu.RealIntelegence = player.RealIntelligence;
        }
        public void OnPrint(object sender, PaintEventArgs e)
        {
            ScaleHP.Refresh();
            ScaleMP.Refresh();
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
