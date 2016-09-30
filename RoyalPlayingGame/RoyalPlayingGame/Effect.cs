using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoyalPlayingGame
{
    public class Effect
    {
        public Timer effectTimer;
        public Effect()
        {
            DHealth = 0;
            DStrength = 0;
            DAgility = 0;
            DIntelligence = 0;
            Duration = 0;
        }
        public Effect(uint duration)
        {
            effectTimer = new Timer();
            effectTimer.Interval = 1000;
            effectTimer.Tick += OnEffectTimerTick;
            DHealth = 0;
            DStrength = 0;
            DAgility = 0;
            DIntelligence = 0;
            Duration = duration;
            CurrentTime = duration;
        }

        private void OnEffectTimerTick(object sender, EventArgs e)
        {
            CurrentTime--;
        }

        public virtual int DHealth { get; set; }
        public virtual int DStrength { get; protected set; }
        public virtual int DAgility { get; protected set; }
        public virtual int DIntelligence{ get; protected set; }
        public virtual uint Duration { get; protected set; }
        public virtual uint CurrentTime { get; protected set; }
    }
}
