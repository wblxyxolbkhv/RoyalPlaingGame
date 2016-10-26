using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Item.Items
{
    public enum PotionType { MP, HP }
    public class Potion : Item
    {
        public Potion(int iD, string name, Effect.Effect effect, uint potionLvl, PotionType PType, ushort amount, ushort maxAmount) : base(iD, name, maxAmount, amount, potionLvl, effect)
        {
            this.PType = PType;
        }
        public Potion(int iD, string name, Effect.Effect effect, uint potionLvl, PotionType PType, ushort amount) : base(iD,name, 10, amount, potionLvl, effect)
        {
            this.PType = PType;
        }

        public PotionType PType { get; protected set; }

    }
}
