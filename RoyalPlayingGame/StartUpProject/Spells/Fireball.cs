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
        public Fireball(List<RealObject> CollisionDomain, RealObject caster) : base(CollisionDomain, caster)
        {
            RealObject.Position = caster.GetCastPoint();
            RealObject.Height = 17;
            RealObject.Width = 26;
            RealObject.SpeedX = 12;

            DeathAnimation = new Animation("Spells/Fireball/Death", 10);
            DeathAnimation.Mode = AnimationMode.Once;
            switch (caster.direction)
            {
                case Direction.Left:
                case Direction.NoneLeft:
                    RealObject.direction = Direction.Left;
                    WalkAnimationLeft = new Animation("Spells/Fireball/WalkLeftFireball", 200);
                    WalkAnimationLeft.Start();
                    Animation = WalkAnimationLeft;
                    Animation.Start();
                    break;
                case Direction.Right:
                case Direction.NoneRight:
                    WalkAnimationRight = new Animation("Spells/Fireball/WalkRightFireball", 200);
                    WalkAnimationRight.Start();
                    RealObject.direction = Direction.Right;
                    Animation = WalkAnimationRight;
                    Animation.Start();
                    break;
            }
        }
    }
}
