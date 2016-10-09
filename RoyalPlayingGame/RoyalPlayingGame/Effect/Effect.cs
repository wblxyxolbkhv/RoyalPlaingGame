using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoyalPlayingGame.Effect
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
            DMana = 0;
            DPhysicalDamageReduction = 0;
            DMagicalDamageReduction = 0;
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
            DMana = 0;
            DPhysicalDamageReduction = 0;
            DMagicalDamageReduction = 0;
            Duration = duration;
            CurrentTime = duration;
        }

        private void OnEffectTimerTick(object sender, EventArgs e)
        {
            CurrentTime--;
        }

        public virtual int DHealth { get; set; }
        public virtual int DMana { get; set; }
        public virtual int DStrength { get; set; }
        public virtual int DAgility { get; set; }
        public virtual int DIntelligence{ get; set; }
        public virtual uint Duration { get; set; }
        public virtual uint CurrentTime { get; set; }
        public virtual uint DPhysicalDamageReduction { get; set; }
        public virtual uint DMagicalDamageReduction { get; set; }
    }
}
