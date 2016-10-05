﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame

{ public enum DamageType { physical, magic }
    public class Unit : ITargetObject
    {
        public uint Health { get; set; }
        public uint Mana { get; set; }
        public uint Strength { get; protected set; }
        public uint Agility { get; protected set; }
        public uint Intelligence { get; protected set; }


        public uint RealHealth { get; set; }
        public uint RealMana { get; set; }
        public uint RealStrength { get; protected set; }
        public uint RealAgility { get; protected set; }
        public uint RealIntelligence { get; protected set; }

        private List<Effect> Effects { get; }
        public uint Level { get; protected set; }
        public void GotDamaged(uint damage)
        {
            Health = Health - damage;
        }
        public void Attack(ITargetObject tarobject, DamageType DType)
        {
            if (DType == DamageType.physical)
            {
                tarobject.GotDamaged((uint)(Strength * 0.85));
            }
            else
            {
                tarobject.GotDamaged((uint)(Intelligence * 0.60));
            }
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
                RealMana = Mana;
                RealStrength = Strength;
                RealIntelligence = Intelligence;
                RealAgility = Agility;               
                RealAgility = effect.DAgility < 0 ? RealAgility - (uint)effect.DAgility : RealAgility + (uint)effect.DAgility;
                RealHealth = effect.DHealth < 0 ? RealHealth - (uint)effect.DHealth : RealHealth + (uint)effect.DHealth;
                RealMana = effect.DMana < 0 ? RealMana - (uint)effect.DMana : RealMana + (uint)effect.DMana;
                RealStrength = effect.DStrength < 0 ? RealStrength - (uint)effect.DStrength : RealStrength + (uint)effect.DStrength;
                RealIntelligence = effect.DIntelligence < 0 ? RealIntelligence - (uint)effect.DIntelligence : RealIntelligence + (uint)effect.DIntelligence;
            }
        }
        public void AddEffect(Effect effect)
        {
            effect.effectTimer.Start();
            Effects.Add(effect);
        }
    }
}
