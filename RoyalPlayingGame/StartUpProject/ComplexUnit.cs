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
    public class ComplexUnit : ComplexObject
    {
        public Animation JumpAnimationLeft { get; set; }
        public Animation JumpAnimationRight { get; set; }
        public Animation Cast1AnimationLeft { get; set; }
        public Animation Cast1AnimationRight { get; set; }
        public Animation AttackAnimationLeft { get; set; }
        public Animation AttackAnimationRight { get; set; }
        public ComplexSpell Cast(NegativeSpell spell, RealObject caster, List<RealObject> CollisionDomain)
        {
            ComplexSpell flyingSpell = null;
            if (spell is RoyalPlayingGame.Spell.NegativeSpells.FireBall)
                flyingSpell = new Spells.Fireball(CollisionDomain, RealObject);
            else if (spell is RoyalPlayingGame.Spell.NegativeSpells.FrostDragonHead)
                flyingSpell = new Spells.FireDragonHead(CollisionDomain, RealObject);
            else if (spell is RoyalPlayingGame.Spell.NegativeSpells.DragonBreath)
                flyingSpell = new Spells.DragonBreath(CollisionDomain, RealObject);
            else if (spell is RoyalPlayingGame.Spell.NegativeSpells.IceWave)
                flyingSpell = new Spells.IceWave(CollisionDomain, RealObject);
            else flyingSpell = new
            switch (caster.direction)
            {
                case Direction.Left:
                case Direction.NoneLeft:
                    Animation = Cast1AnimationLeft;
                    Animation.Start();
                    break;
                case Direction.Right:
                case Direction.NoneRight:
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
