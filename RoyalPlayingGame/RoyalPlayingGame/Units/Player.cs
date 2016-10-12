﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Spell;
using System.Windows.Forms;

namespace RoyalPlayingGame.Units
{
   public class Player:Unit
    {
        public Player():base()
        {
            QuestJournal = new List<Quest.Quest>();
            Experience = 0;
            Health = RealHealth = 100;
            Mana = RealMana = 100;
            Agility = RealAgility = 4;
            Intelligence = RealIntelligence = 5;
            Strength = RealStrength = 4;
            PhysicalDamageReduction = RealPhysicalDamageReduction = 10;
            MagicalDamageReduction = RealMagicalDamageReduction = 15;

            Spell.NegativeSpells.FireBall fireBall = new Spell.NegativeSpells.FireBall(RealIntelligence,RealAgility);
            Spell.NegativeSpells.FrostDragonHead frost = new Spell.NegativeSpells.FrostDragonHead(RealIntelligence, RealAgility);
            Spell.NegativeSpells.DragonBreath breath = new Spell.NegativeSpells.DragonBreath(RealIntelligence, RealAgility);
            Spell.NegativeSpells.IceWave wave = new Spell.NegativeSpells.IceWave(RealIntelligence, RealAgility);
            SpellBook.AddSpell(fireBall);
            SpellBook.AddSpell(frost);
            SpellBook.AddSpell(breath);
            SpellBook.AddSpell(wave);
            SpellHotKey1 = SpellBook[fireBall.SpellName];
            SpellHotKey2 = SpellBook[frost.SpellName];
            SpellHotKey3 = SpellBook[breath.SpellName];
            SpellHotKey4 = SpellBook[wave.SpellName];
        }
        public List<Quest.Quest> QuestJournal { get; set; }
        public int Experience { get; set; }
        public void EquipWeapon(Item.Items.Weapon weapon)
        {
            if (CheckRequiredLvl(weapon))
            {
                WeaponSet.Add(weapon);
            }
        }
        public void EquipArmor(Item.Items.Armor armor)
        {
            if(CheckRequiredLvl(armor))
            {
                ArmorSet.Add(armor);
            }
        }
        public bool CheckRequiredLvl(Item.Item item)
        {
            if (item.ItemLvl >= Level)
                return true;
            else return false;
        }
        
        public void LvlUP()
        {
            if (Experience>=200)
            {
                Experience = Experience - 200;
                Level += 1;
            }
        }
        public Spell.Spell CastSpell(Keys key)
        {
            switch (key)
            {
                case Keys.D1:
                    {
                        return base.CastSpell(SpellHotKey1);      
                    }
                case Keys.D2:
                    {
                        return base.CastSpell(SpellHotKey2);
                    }
                case Keys.D3:
                    {
                        return base.CastSpell(SpellHotKey3);
                    }
                case Keys.D4:
                    {
                        return base.CastSpell(SpellHotKey4);
                    }
            }
            return null;
                
        }
        public void StopCoolDowns()
        {
            foreach (Spell.Spell spell in SpellBook.SpellBook)
            {
                spell.coolDownTimer.Stop();
            }
        }



    }
}
