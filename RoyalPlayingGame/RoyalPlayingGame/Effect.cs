using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame
{
    public class Effect
    {
        public Effect()
        {
            DLife = 0;
            DStrength = 0;
            DAgility = 0;
            DIntelligence = 0;
        }
        public virtual int DLife { get; set; }
        public virtual int DStrength { get; private set; }
        public virtual int DAgility { get; private set; }
        public virtual int DIntelligence{ get; private set; }
    }
}
