using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame
{
    public class Unit : ITargetObject
    {
        public uint Health { get; set; }
        public uint Strength { get; protected set; }
        public uint Agility { get; protected set; }
        public uint Intelligence { get; protected set; }

        public uint RealHealth { get; set; }
        public uint RealStrength { get; protected set; }
        public uint RealAgility { get; protected set; }
        public uint RealIntelligence { get; protected set; }

        private List<Effect> Effects { get; protected set; }
        public uint Level { get; protected set; }
        public void GotDamaged(uint damage)
        {

        }
        public void Attack(ITargetObject tarobject)
        {

        }
        public void CalcStatsEffects()
        {
            foreach (Effect effect in Effects)
            {
                if (effect.effectTimer != null && effect.CurrentTime <=0)
                    Effects.Remove(effect);
            }
            foreach (Effect effect in Effects)
            {

                RealHealth = Health;
                RealStrength = Strength;
                RealIntelligence = Intelligence;
                RealAgility = Agility;               
                RealAgility = effect.DAgility < 0 ? RealAgility - (uint)effect.DAgility : RealAgility + (uint)effect.DAgility;
                RealHealth = effect.DHealth < 0 ? RealHealth - (uint)effect.DHealth : RealHealth + (uint)effect.DHealth;
                //
            }
        }
        public void AddEffect(Effect effect)
        {
            effect.effectTimer.Start();
            Effects.Add(effect);
        }

        

        
        

    }
}
