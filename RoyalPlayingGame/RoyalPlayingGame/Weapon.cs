using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame
{
    public enum WeaponType { Sword, Staff, Shield, Dagger, Mace, Spear }
    public enum WeaponSlot { LeftHand, RightHand, TwoHands}
    public class Weapon : Item
    {
        public Weapon(string name, WeaponType WType, WeaponSlot WSlot, Effect effect, uint weaponLvl )
        {
            this.WSlot = WSlot;
            this.WType = WType;
            base.ItemName = name;
            base.ItemEffect = effect;
            base.ItemLvl = weaponLvl;
            base.MaxAmount = 1;
        }
        public WeaponSlot WSlot { get; private set; }
        public WeaponType WType { get; private set; }
    }
}
