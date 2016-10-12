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
    public class Fireball : ComplexSpell
    {
        public Fireball(List<RealObject> CollisionDomain, RealObject caster)
        {
            RealObject = new RealObject(CollisionDomain);
            RealObject.Position = caster.GetCastPoint();
            RealObject.Height = 17;
            RealObject.Width = 26;
            RealObject.SpeedX = 8;
            WalkAnimationLeft = new Animation("Fireball/WalkLeftFireball", 200);
            WalkAnimationLeft.Start();
            WalkAnimationRight = new Animation("Fireball/WalkRightFireball", 200);
            WalkAnimationRight.Start();

            DeathAnimation = new Animation("Fireball/Death", 10);
            DeathAnimation.Mode = AnimationMode.Once;
            switch (caster.direction)
            {
                case Direction.Left:
                case Direction.NoneLeft:
                    RealObject.direction = Direction.Left;
                    Animation = WalkAnimationLeft;
                    Animation.Start();
                    break;
                case Direction.Right:
                case Direction.NoneRight:
                    RealObject.direction = Direction.Right;
                    Animation = WalkAnimationRight;
                    Animation.Start();
                    break;
            }
        }
    }
}
