using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Spell;
using System.Windows.Forms;
using RoyalPlayingGame.Quests;
using RoyalPlayingGame.Journal;

namespace RoyalPlayingGame.Units
{
    /// <summary>
    /// класс игрока 
    /// </summary>
   public class Player:Unit
    {
        public Player():base()
        {
            
            QuestJournal = new PlayerJournal();
            Experience = 0;
            Health = RealHealth = 100;
            Mana = RealMana = 10000;
            Agility = RealAgility = 4;
            Intelligence = RealIntelligence = 1000;
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
            //отладочное, убрать
            for (int i = 0; i < 4; i++)
                Inventory.AddItem(ItemsManager.GetItem(1000));
        }
        public int experience;
        public PlayerJournal QuestJournal { get; set; } = null;
        
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
        
        /// <summary>
        /// генерация спелла относительно нажатой клавиши
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
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

        /// <summary>
        /// добавление квеста в журнал
        /// </summary>
        /// <param name="quest"></param>
        public void AddQuest(Quest quest)
        {
            QuestJournal.ActiveQuests.Add(quest);
        }

    }
}
