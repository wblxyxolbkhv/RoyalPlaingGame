using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Spell;
using System.Windows.Forms;
using RoyalPlayingGame.Quests;

namespace RoyalPlayingGame.Units
{
   public class Player:Unit
    {
        public Player():base()
        {
            
            QuestJournal = new List<Quest>();
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
            SpellHotKey1 = SpellBook[fireBall.Name];
            SpellHotKey2 = SpellBook[frost.Name];
            SpellHotKey3 = SpellBook[breath.Name];
            SpellHotKey4 = SpellBook[wave.Name];
        }
        public int experience;
        public List<Quest> QuestJournal { get; set; }
        
        public int Experience
        {
            get { return experience; }
            set
            {
                if (value > 200)
                {
                    experience = value - 200;
                    Level++;
                }
                else experience = value;
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

        public void AddQuest(Quest quest)
        {
            QuestJournal.Add(quest);
        }

    }
}
