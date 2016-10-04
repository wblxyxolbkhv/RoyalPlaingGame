﻿using System;
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
        Random randomWeaponGeneration;
        public Weapon(string name, WeaponType WType, WeaponSlot WSlot, Effect effect, uint weaponLvl ):base(name,1,1,weaponLvl,effect)
        {
            this.WSlot = WSlot;
            this.WType = WType;
        }
        public Weapon(string name, WeaponType WType, WeaponSlot WSlot, uint weaponLvl, int minValue, int maxValue):base(name, 1,1,weaponLvl)
        {
            Effect effect = new Effect();
            randomWeaponGeneration = new Random();
            effect.DAgility = randomWeaponGeneration.Next(minValue, maxValue);
            effect.DIntelligence = randomWeaponGeneration.Next(minValue, maxValue);
            effect.DStrength = randomWeaponGeneration.Next(minValue, maxValue);
            base.ItemEffect = effect;
            this.WType = WType;
            this.WSlot = WSlot;
        }
        public WeaponSlot WSlot { get; private set; }
        public WeaponType WType { get; private set; }
    }
}
