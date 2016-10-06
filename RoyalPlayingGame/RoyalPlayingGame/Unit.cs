using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame

{
    public enum DamageType { Physical, Magic }

    public class Unit : ITargetObject
    {
        public uint Health { get; set; }
        public uint Mana { get; set; }
        public uint Strength { get; protected set; }
        public uint Agility { get; protected set; }
        public uint Intelligence { get; protected set; }
        public uint PhysicalDamageReduction { get; protected set; }
        public uint MagicalDamageReduction { get; protected set; }

        public uint RealHealth { get; set; }
        public uint RealMana { get; set; }
        public uint RealStrength { get; protected set; }
        public uint RealAgility { get; protected set; }
        public uint RealIntelligence { get; protected set; }
        public uint RealPhysicalDamageReduction { get; protected set; }
        public uint RealMagicalDamageReduction { get; protected set; }

        public List<Effect> Effects { get; set; }
        public List<Armor> ArmorSet { get; set; }
        public List<Weapon> WeaponSet { get; set; }
        public List<Potion> Potions { get; set; }
        public List<Spell> SpellBook { get; set; }
        public uint Level { get; protected set; }

        public void GotDamaged(uint damage, DamageType DType)
        {
            if (DType == DamageType.Physical)
            {
                Health = Health - (damage - (damage * PhysicalDamageReduction / 100));
            }
            else
            {
                Health = Health - (damage - (damage * MagicalDamageReduction / 100));
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
                RealMagicalDamageReduction = effect.DMagicalDamageReduction < 0 ? RealMagicalDamageReduction - (uint)effect.DMagicalDamageReduction : RealMagicalDamageReduction + (uint)effect.DMagicalDamageReduction;
                RealPhysicalDamageReduction = effect.DPhysicalDamageReduction < 0 ? RealPhysicalDamageReduction - (uint)effect.DPhysicalDamageReduction : RealPhysicalDamageReduction + (uint)effect.DPhysicalDamageReduction;
            }

        }

        public void AddEffect(Effect effect)
        {
            effect.effectTimer.Start();
            Effects.Add(effect);
        }

        public void AddPotion(Potion potion)
        {
            foreach (Potion addedPotion in Potions)
            {
                if (addedPotion.ItemName == potion.ItemName)
                {
                    addedPotion.Amount += 1;
                }
                else
                {
                    Potions.Add(potion);
                }
            }
        }
        public void AddPotion(Potion potion, ushort amount)
        {
            foreach (Potion addedPotion in Potions)
            {
                if (addedPotion.ItemName == potion.ItemName)
                    addedPotion.Amount += amount;
            }
        }

        public bool ItsALIVE()
        {
            if (RealHealth == 0)
            {
                return false;
            }
            else return true;
        }

        public void PhysicalAttack(ITargetObject targetObject)
        {
            targetObject.GotDamaged((uint)(RealStrength * 0.03), DamageType.Physical);
        }

        public void MagicalAttack(ITargetObject targetObject, NegativeSpell negativeSpell)
        {
            targetObject.GotDamaged((uint)negativeSpell.DealtDamage(), DamageType.Magic);
        }

        public Spell CastSpell()
        {
            NegativeSpells.FireBall fireball = new NegativeSpells.FireBall(RealIntelligence, RealAgility);
            return fireball;
        }
    }
}
