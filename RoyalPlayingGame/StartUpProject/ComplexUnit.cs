using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Spell;
using SimplePhysicalEngine.NonPhysicalComponents;
using VisualPart;

namespace StartUpProject
{
    class ComplexUnit : ComplexObject
    {
        public Animation JumpAnimationLeft { get; set; }
        public Animation JumpAnimationRight { get; set; }
        public Animation Cast1AnimationLeft { get; set; }
        public Animation Cast1AnimationRight { get; set; }
        public ComplexSpell Cast(NegativeSpell spell, RealObject caster, List<RealObject> CollisionDomain)
        {
            ComplexSpell flyingSpell = new ComplexSpell();
            if (spell is RoyalPlayingGame.Spell.NegativeSpells.FireBall)
            {
                flyingSpell.RealObject = new RealObject(CollisionDomain);
                flyingSpell.RealObject.Position = caster.GetCastPoint();
                flyingSpell.RealObject.Height = 17;
                flyingSpell.RealObject.Width = 26;
                flyingSpell.RealObject.SpeedX = 6;
                flyingSpell.WalkAnimationLeft = new Animation("Fireball/WalkLeftFireball", 200);
                flyingSpell.WalkAnimationLeft.Start();
                flyingSpell.WalkAnimationRight = new Animation("Fireball/WalkRightFireball", 200);
                flyingSpell.WalkAnimationRight.Start();

                flyingSpell.DeathAnimation = new Animation("Fireball/Death", 10);
                flyingSpell.DeathAnimation.Mode = AnimationMode.Once;

            }
            switch (caster.direction)
            {
                case Direction.Left:
                case Direction.NoneLeft:
                    flyingSpell.RealObject.direction = Direction.Left;
                    flyingSpell.Animation = flyingSpell.WalkAnimationLeft;
                    Animation = Cast1AnimationLeft;
                    Animation.Start();
                    break;
                case Direction.Right:
                case Direction.NoneRight:
                    flyingSpell.RealObject.direction = Direction.Right;
                    flyingSpell.Animation = flyingSpell.WalkAnimationRight;
                    Animation = Cast1AnimationRight;
                    Animation.Start();
                    break;
            }
            return flyingSpell;
        }
        public override void OnRefresh(object sender, EventArgs e)
        {
            RealObject.OnRefreshPosition(sender, e);
            if (Animation.Mode == AnimationMode.Once && Animation.IsActive)
                return;
            if (RealObject.IsJumpingDown || RealObject.IsJumpingUp)
                switch (RealObject.direction)
                {
                    case Direction.Left:
                    case Direction.NoneLeft:
                        Animation = JumpAnimationLeft;
                        break;
                    case Direction.Right:
                    case Direction.NoneRight:
                        Animation = JumpAnimationRight;
                        break;
                }
            else
                switch (RealObject.direction)
                {
                    case Direction.Left:
                        Animation = WalkAnimationLeft;
                        break;
                    case Direction.Right:
                        Animation = WalkAnimationRight;
                        break;
                    case Direction.NoneLeft:
                        Animation = NonActivityAnimationLeft;
                        break;
                    case Direction.NoneRight:
                        Animation = NonActivityAnimationRight;
                        break;
                }
        }
    }
}
