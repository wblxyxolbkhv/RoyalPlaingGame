using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Spell
{
    public class SpellBookCollection
    {
        private List<Spell> SpellBook { get; set; }
        public Spell this[string index]
        {
            get
            {
                foreach (Spell spell in SpellBook)
                {
                    if (spell.SpellName == index)
                        return spell;
                }
                throw new IndexOutOfRangeException("Заклинание отсутствует.");
            }

        }
        public void AddSpell(Spell spell)
        {
            SpellBook.Add(spell);
        }
        public void RemoveSpell(Spell spell)
        {
            SpellBook.Remove(spell);
        }
        public void RemoveSpell(string name)
        {
            RemoveSpell(this[name]);
        }
        
    }
    
}
