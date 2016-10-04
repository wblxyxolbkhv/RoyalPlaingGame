using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame
{
    public enum PotionType { MP, HP}
    public class Potion:Item
    { 
        public Potion(string name, Effect effect, uint potionLvl, PotionType PType, ushort amount, ushort maxAmount):base( name, maxAmount, amount, potionLvl, effect)
        {
            this.PType = PType;
        }
        public Potion(string name, Effect effect, uint potionLvl, PotionType PType, ushort amount) : base(name, 10, amount, potionLvl, effect)
        {
            this.PType = PType;
        }
        public void AddPotion()
        {
            
        }
        public PotionType PType { get; protected set; }

    }
}
