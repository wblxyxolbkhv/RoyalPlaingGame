using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Spell;
using SimplePhysicalEngine.NonPhysicalComponents;
using VisualPart;

namespace StartUpProject.Spells
{
    public class FireDragonHead : ComplexSpell
    {
        public FireDragonHead(List<RealObject> CollisionDomain, RealObject caster) : base(CollisionDomain, caster)
        {
            RealObject.Height = 108;
            RealObject.Width = 150;
            RealObject.SpeedX = 0;
            WalkAnimationLeft = new Animation("Spells/FrostDragonHead/WalkLeft", 100);
            WalkAnimationLeft.Mode = AnimationMode.Once;
            WalkAnimationRight = new Animation("Spells/FrostDragonHead/WalkRight", 100);
            WalkAnimationLeft.Mode = AnimationMode.Once;
            NonActivityAnimationLeft = new Animation("Spells/FrostDragonHead/WalkLeft", 100);
            NonActivityAnimationLeft.Mode = AnimationMode.Once;
            NonActivityAnimationRight = new Animation("Spells/FrostDragonHead/WalkRight", 100);
            NonActivityAnimationRight.Mode = AnimationMode.Once;
            switch (caster.direction)
            {
                case Direction.Left:
                case Direction.NoneLeft:
                    RealObject.Position = new SimplePhysicalEngine.Vector2(caster.Position.X - 150, caster.Position.Y - 20);
                    RealObject.direction = Direction.Left;
                    Animation = NonActivityAnimationLeft;
                    Animation.Start();
                    break;
                case Direction.Right:
                case Direction.NoneRight:
                    RealObject.Position = new SimplePhysicalEngine.Vector2(caster.Position.X + caster.Width, caster.Position.Y - 20);
                    RealObject.direction = Direction.Right;
                    Animation = NonActivityAnimationRight;
                    Animation.Start();
                    break;
            }
            Animation.AnimationEnd += OnUnitDeath;
        }
    }
}
