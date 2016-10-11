using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Spell
{
    public class SpellBookCollection
    {
        public SpellBookCollection()
        {
            SpellBook = new List<Spell>();
        }
<<<<<<< HEAD
        public  List<Spell> SpellBook { get; set; }
=======
        private List<Spell> SpellBook { get; set; }
>>>>>>> 837e9e60489873aeee88c5c90254e737875b48b1
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
