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
        Effect weaponEffect;
        public Weapon(string name, WeaponType WType, WeaponSlot WSlot, Effect effect )
        {
            this.WSlot = WSlot;
            this.WType = WType;
            base.ItemName = name;
            weaponEffect = effect;
        }
        public WeaponSlot WSlot { get; private set; }
        public WeaponType WType { get; private set; }
        public bool CheckRequirementStats(Player player)
        {
            return true;
        }
    }
}
