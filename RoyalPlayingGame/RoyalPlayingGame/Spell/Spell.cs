using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoyalPlayingGame.Spell
{
    public class Spell
    {
        public int ManaCost { get; set; }
        public int CastTime { get; set; }
        public int CurrentCoolDown { get; set; }
        public int CoolDown { get; set; }
        public Timer coolDownTimer { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public Spell(int manaCost, int castTime, int coolDown, string spellName)
        {
            coolDownTimer = new Timer();
            coolDownTimer.Interval = 1000;
            coolDownTimer.Tick += OnCoolDownTimerTick;
            ManaCost = manaCost;
            CastTime = castTime;
            CoolDown = coolDown;
            Name = spellName;
            Active = true;
        }

        private void OnCoolDownTimerTick(object sender, EventArgs e)
        {
            if (CurrentCoolDown <= 0)
            {
                Active = true;
                coolDownTimer.Stop();
            }
            else
                CurrentCoolDown -= 1;

        }
    }
}
