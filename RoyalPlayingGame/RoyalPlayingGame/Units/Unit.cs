using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Item.Items;
using RoyalPlayingGame.Effect;
using RoyalPlayingGame.Spell;

namespace RoyalPlayingGame.Units

{
    public enum DamageType { Physical, Magic }

    public class Unit : Interfaces.ITargetObject
    {
        public Unit()
        {
            SpellBook = new SpellBookCollection();
            ArmorSet = new List<Armor>();
            WeaponSet = new List<Weapon>();
            Potions = new List<Potion>();
            SpellBook = new SpellBookCollection();
            Effects = new List<Effect.Effect>();
            IsAlive = true;
        }
        #region BITCH
        protected int realHealth;
        protected int realMana;
        protected int realAgility;
        protected int realStrength;
        protected int realIntelligence;
        protected int realPhysicalDamageReduction;
        protected int realMagicalDamageReduction;
        public event Action Death;
        public bool IsAlive { get; set; }

        public int Health { get; set; }
        public int Mana { get; set; }
        public int Strength { get; protected set; }
        public int Agility { get; protected set; }
        public int Intelligence { get; protected set; }
        public int PhysicalDamageReduction { get; protected set; }
        public int MagicalDamageReduction { get; protected set; }

        public int RealHealth { get { return realHealth; }
            set
            {
                realHealth = value;
                if (value <= 0)
                {
                    IsAlive = false;
                    Death?.Invoke();
                }
            }
        }
        public int RealMana
        {
            get
            {
                if (realMana <= 0)
                    return 0;
                else return realMana;
            }
            set
            {
                realMana = value;
            }
        }
        public int RealStrength
        {
            get
            {
                if (realStrength <= 0)
                    return 0;
                else return realStrength;
            }
            set
            {
                realStrength = value;
            }
        }
        public int RealAgility
        {
            get
            {
                if (realAgility <= 0)
                    return 0;
                else return realAgility;
            }
            set
            {
                realAgility = value;
            }
        }
        public int RealIntelligence
        {
            get
            {
                if (realIntelligence <= 0)
                    return 0;
                else return realIntelligence;
            }
            set
            {
                realIntelligence = value;
            }
        }
        public int RealPhysicalDamageReduction
        {
            get
            {
                if (realPhysicalDamageReduction <= 0)
                    return 0;
                else return realPhysicalDamageReduction;
            }
            set
            {
                realPhysicalDamageReduction = value;
            }
        }
        public int RealMagicalDamageReduction
        {
            get
            {
                if (realMagicalDamageReduction <= 0)
                    return 0;
                else return realMagicalDamageReduction;
            }
            set
            {
                realMagicalDamageReduction = value;
            }
        }
        #endregion 
        public List<Effect.Effect> Effects { get; set; }
        public List<Armor> ArmorSet { get; set; }
        public List<Weapon> WeaponSet { get; set; }
        public List<Potion> Potions { get; set; }
        public SpellBookCollection SpellBook { get; set; }
        public int Level { get; protected set; }
        public Random CriticalChance { get; set; }
        public Spell.Spell SpellHotKey1 { get; set; }
        public Spell.Spell SpellHotKey2 { get; set; }
        public Spell.Spell SpellHotKey3 { get; set; }
        public Spell.Spell SpellHotKey4 { get; set; }


        public int GotDamaged(int damage, DamageType DType)
        {
            if (DType == DamageType.Physical)
            {
                RealHealth = RealHealth - (damage - (damage * PhysicalDamageReduction / 100));
                return (damage - (damage * PhysicalDamageReduction / 100));
            }
            else
            {
                RealHealth = RealHealth - (damage - (damage * MagicalDamageReduction / 100));
                return (damage - (damage * MagicalDamageReduction / 100));
            }
        }
  
        public void CalcStatsEffects()
        {
            foreach (Effect.Effect effect in Effects)
            {
                if (effect.effectTimer != null && effect.CurrentTime <=0)
                    Effects.Remove(effect);
            }
            foreach (Effect.Effect effect in Effects)
            {
                RealAgility += effect.DAgility;
                RealHealth += effect.DHealth;
                RealMana += effect.DMana;
                RealStrength += effect.DStrength;
                RealIntelligence += effect.DIntelligence;
                RealMagicalDamageReduction += effect.DMagicalDamageReduction;
                RealPhysicalDamageReduction += effect.DPhysicalDamageReduction;
            }

        }

        public void AddEffect(Effect.Effect effect)
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

        public virtual Spell.Spell CastSpell()
        {
            Spell.NegativeSpells.FireBall fireball = new Spell.NegativeSpells.FireBall(RealIntelligence, RealAgility);
            return fireball;
        }
        public virtual Spell.Spell CastSpell(Spell.Spell spell)
        {
            if (RealMana - spell.ManaCost < 0)
                throw new Exceptions.NoManaException();
            else if (spell.Active == true)
            {
                spell.Active = false;
                spell.CurrentCoolDown = SpellHotKey1.CoolDown;
                spell.coolDownTimer.Start();
                RealMana -= spell.ManaCost;
                return spell;
            }
            throw new Exceptions.SpellCoolDownException();
        }
        public int AutoAttack(out bool CriticalStrike)
        {
            CriticalChance = new Random();  
            int damage = RealStrength * 4 + (int)(RealAgility * 0.5);
            int BasicCriticalChance = 20 + (int)(RealAgility * 0.02);
            if (CriticalChance.Next(100) < BasicCriticalChance)
            {
                CriticalStrike = true;
                return damage * 2;
            }
            else
            {
                CriticalStrike = false;
                return damage;
            }
        }


    }
}
