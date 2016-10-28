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

            RealObject = new RealObject(CollisionDomain, Gravity);
            RealObject.Position = new Vector2(600, 400);
            RealObject.Height = 110;
            RealObject.Width = 110;
            RealObject.SpeedX = 2;
            RealObject.direction = Direction.Right;
            PatrolPoint = new Vector2(RealObject.Position.X, RealObject.Position.Y);
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
        
    }
}
