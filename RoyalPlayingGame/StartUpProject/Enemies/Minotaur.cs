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

namespace StartUpProject.Enemies
{
    public class Minotaur : ComplexEnemy
    {
        public Minotaur(List<RealObject> CollisionDomain, Power Gravity)
        {
            
            Unit = new Unit(1001);
            Unit.Health = 100;
            Unit.RealHealth = 100;
            Unit.AddLoot(new RoyalPlayingGame.Items.Item(1000, "Шляпа", 1,1,1));
            Unit.AddLoot(new RoyalPlayingGame.Items.Item(1001, "Двойная шляпа", 1,1,1));
            Unit.AddLoot(new RoyalPlayingGame.Items.Item(1002, "Тройная шляпа", 1,1,1));

            RealObject = new RealObject(CollisionDomain, Gravity);
            RealObject.Height = 106;
            RealObject.Width = 110;
            IndentX = 36;
            IndentY = 37;
            RealObject.SpeedX = 2;
            RealObject.direction = Direction.Right;
            PatrolRadius = 4000;

            WalkAnimationLeft = new Animation("Minotaur/WalkLeft", 100);
            WalkAnimationLeft.Start();
            WalkAnimationRight = new Animation("Minotaur/WalkRight", 100);
            WalkAnimationRight.Start();

            AttackAnimationLeft = new Animation("Minotaur/AttackLeft", 100);
            AttackAnimationLeft.Mode = AnimationMode.Once;
            AttackAnimationRight = new Animation("Minotaur/AttackRight", 100);
            AttackAnimationRight.Mode = AnimationMode.Once;

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
