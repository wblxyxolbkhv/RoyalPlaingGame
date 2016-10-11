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
                flyingSpell.RealObject.SpeedX = 8;
                flyingSpell.WalkAnimationLeft = new Animation("Fireball/WalkLeftFireball", 200);
                flyingSpell.WalkAnimationLeft.Start();
                flyingSpell.WalkAnimationRight = new Animation("Fireball/WalkRightFireball", 200);
                flyingSpell.WalkAnimationRight.Start();

                flyingSpell.DeathAnimation = new Animation("Fireball/Death", 10);
                flyingSpell.DeathAnimation.Mode = AnimationMode.Once;
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

            }
            else if (spell is RoyalPlayingGame.Spell.NegativeSpells.FrostDragonHead)
            {
                flyingSpell.RealObject = new RealObject(CollisionDomain);
                flyingSpell.RealObject.Height = 108;
                flyingSpell.RealObject.Width = 150;
                flyingSpell.RealObject.SpeedX = 0.001;
                flyingSpell.WalkAnimationLeft = new Animation("FrostDragonHead/WalkLeft", 100);
                flyingSpell.WalkAnimationLeft.Mode = AnimationMode.Once;
                flyingSpell.WalkAnimationRight = new Animation("FrostDragonHead/WalkRight", 100);
                flyingSpell.WalkAnimationLeft.Mode = AnimationMode.Once;
                flyingSpell.NonActivityAnimationLeft = new Animation("FrostDragonHead/WalkLeft", 100);
                flyingSpell.NonActivityAnimationLeft.Mode = AnimationMode.Once;
                flyingSpell.NonActivityAnimationRight = new Animation("FrostDragonHead/WalkRight", 100);
                flyingSpell.NonActivityAnimationRight.Mode = AnimationMode.Once;
                switch (caster.direction)
                {
                    case Direction.Left:
                    case Direction.NoneLeft:
                        flyingSpell.RealObject.Position = new SimplePhysicalEngine.Vector2(caster.Position.X - 150, caster.Position.Y - 20);
                        flyingSpell.RealObject.direction = Direction.Left;
                        flyingSpell.Animation = flyingSpell.NonActivityAnimationLeft;
                        flyingSpell.Animation.Start();
                        Animation = Cast1AnimationLeft;
                        Animation.Start();
                        break;
                    case Direction.Right:
                    case Direction.NoneRight:
                        flyingSpell.RealObject.Position = new SimplePhysicalEngine.Vector2(caster.Position.X + caster.Width, caster.Position.Y - 20);
                        flyingSpell.RealObject.direction = Direction.Right;
                        flyingSpell.Animation = flyingSpell.NonActivityAnimationRight;
                        flyingSpell.Animation.Start();
                        Animation = Cast1AnimationRight;
                        Animation.Start();
                        break;
                }
                flyingSpell.Animation.AnumationEnd += flyingSpell.OnUnitDeath;
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
