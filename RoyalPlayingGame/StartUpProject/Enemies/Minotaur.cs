using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplePhysicalEngine.NonPhysicalComponents;
using System.Windows.Forms;
using SimplePhysicalEngine;
using VisualPart;
using RoyalPlayingGame.Spell;
using RoyalPlayingGame.Units;
using RoyalPlayingGame;
using RoyalPlayingGame.Items;

namespace StartUpProject.Enemies
{
    public class Minotaur : ComplexEnemy
    {
        public Minotaur(List<RealObject> CollisionDomain, Power Gravity)
        {
            
            Unit = new Unit(1001);
            Unit.Health = 100;
            Unit.RealHealth = 100;
            Unit.BaseDamage = 10;
            //Unit.AddLoot(new Item("hat", "Шляпа", 1,1,1, ItemType.Other));
            //Unit.AddLoot(new Armor("hat", "Шляпа", ArmorSlot.Head, 0, 2, 5));
            //Unit.AddLoot(new Item("double_hat", "Двойная шляпа", 1,1,1, ItemType.Potion));
            //Unit.AddLoot(new Item("triple_hat", "Тройная шляпа", 1,1,1, ItemType.Armor));
            //Unit.AddLoot(ItemsManager.GetCustomItem("ultra_hat"));
            //Unit.AddLoot(new Item("cool_book", "Книгга", 1, 1, 1, ItemType.Weapon));
            Unit.AddLoot(new Armor("newhat", "Шляпа", ArmorSlot.Head, 0, 4, 10));
            Unit.AddLoot(new Armor("neck", "Ожерелье", ArmorSlot.Neck, 0, 4, 10));
            Unit.AddLoot(new Armor("back", "Плащ", ArmorSlot.Back, 0, 4, 10));
            Unit.AddLoot(new Armor("chest", "Мантия", ArmorSlot.Chest, 0, 4, 10));
            Unit.AddLoot(new Armor("boots", "Сапоги", ArmorSlot.Boots, 0, 4, 10));
            Unit.AddLoot(new Armor("ring", "Кольцо", ArmorSlot.Ring, 0, 4, 10));
            Unit.AddLoot(new Weapon("staff", "Посох", WeaponType.Staff, WeaponSlot.TwoHands, 0, 4, 10));

            RealObject = new RealObject(CollisionDomain, Gravity);
            RealObject.Height = 106;
            RealObject.Width = 110;
            IndentX = 36;
            IndentY = 37;
            RealObject.SpeedX = 2;
            RealObject.direction = Direction.Right;
            PatrolRadius = 4000;
            AgressiveRadius = 400;

            WalkAnimationLeft = new Animation("Minotaur/WalkLeft", 100);
            WalkAnimationLeft.Start();
            WalkAnimationRight = new Animation("Minotaur/WalkRight", 100);
            WalkAnimationRight.Start();

            AttackAnimationLeft = new Animation("Minotaur/AttackLeft", 150);
            AttackAnimationLeft.Mode = AnimationMode.Once;
            AttackAnimationRight = new Animation("Minotaur/AttackRight", 150);
            AttackAnimationRight.Mode = AnimationMode.Once;

            AttackRange = 50;//AttackAnimationLeft.CurrentFrame.Width;

            DeathAnimation = new Animation("Minotaur/Death", 100);
            DeathAnimation.Mode = AnimationMode.Once;

            DefaultAnimation = WalkAnimationLeft;
            Animation = WalkAnimationLeft;

            

        }
        public override void OnUnitDeath()
        {
            base.OnUnitDeath();

            IndentY = 16;
        }

    }
}
