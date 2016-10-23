using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Item.Items
{
    public enum WeaponType { Sword, Staff, Shield, Dagger, Mace, Spear }
    public enum WeaponSlot { LeftHand, RightHand, TwoHands }
    public class Weapon : Item
    {
        Random randomWeaponGeneration;
        public Weapon(int iD, string name, WeaponType WType, WeaponSlot WSlot, Effect.Effect effect, uint weaponLvl) : base(iD,name, 1, 1, weaponLvl, effect)
        {
            this.WSlot = WSlot;
            this.WType = WType;
        }
        public Weapon(int iD, string name, WeaponType WType, WeaponSlot WSlot, uint weaponLvl, int minValue, int maxValue) : base(iD,name, 1, 1, weaponLvl)
        {
            Effect.Effect effect = new Effect.Effect();
            randomWeaponGeneration = new Random();
            effect.DAgility = randomWeaponGeneration.Next(minValue, maxValue);
            effect.DIntelligence = randomWeaponGeneration.Next(minValue, maxValue);
            effect.DStrength = randomWeaponGeneration.Next(minValue, maxValue);
            ItemEffect = effect;
            this.WType = WType;
            this.WSlot = WSlot;
        }
        public WeaponSlot WSlot { get; private set; }
        public WeaponType WType { get; private set; }
    }
}
