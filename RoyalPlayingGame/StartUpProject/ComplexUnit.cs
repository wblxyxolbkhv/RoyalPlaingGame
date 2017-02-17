using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Spell;
using RoyalPlayingGame;
using RoyalPlayingGame.Items;
using RoyalPlayingGame.Dialogs;
using SimplePhysicalEngine.NonPhysicalComponents;
using SimplePhysicalEngine;
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
        public Dialog CurrentDialog { get; set; }
        public virtual ComplexSpell Cast(NegativeSpell spell, List<RealObject> CollisionDomain)
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
            else flyingSpell = new Spells.AutoAttack(CollisionDomain, this);
            switch (RealObject.direction)
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
        /// <summary>
        /// перегрузка для автоатаки
        /// </summary>
        /// <param name="CollisionDomain"></param>
        /// <returns></returns>
        public virtual ComplexSpell Cast(List<RealObject> CollisionDomain)
        {
            if (cooldownTime.CompareTo(GlobalGameComponents.Game.CurrentTime)>0)
                return null;
            ComplexSpell flyingSpell = null;
            flyingSpell = new Spells.AutoAttack(CollisionDomain, this);
            switch (RealObject.direction)
            {
                case Direction.Left:
                case Direction.NoneLeft:
                    Animation = AttackAnimationLeft;
                    Animation.Start();
                    break;
                case Direction.Right:
                case Direction.NoneRight:
                    Animation = AttackAnimationRight;
                    Animation.Start();
                    break;
            }
            cooldownTime = DateTime.Now.AddMilliseconds(AutoAttackCooldown);
            return flyingSpell;
        }
        public override void OnRefresh(object sender, EventArgs e)
        {
            RealObject.OnRefreshPosition(sender, e);
            Animation.OnUpdateFrame(GlobalGameComponents.Game.DeltaTime);
            if (Animation.Mode == AnimationMode.Once && Animation.IsActive)
                return;
            if (RealObject.IsJumpingDown || RealObject.IsJumpingUp)
                switch (RealObject.direction)
                {
                    case Direction.Left:
                    case Direction.NoneLeft:
                        Animation = JumpAnimationLeft ?? DefaultAnimation;
                        break;
                    case Direction.Right:
                    case Direction.NoneRight:
                        Animation = JumpAnimationRight ?? DefaultAnimation;
                        break;
                }
            else
                switch (RealObject.direction)
                {
                    case Direction.Left:
                        Animation = WalkAnimationLeft ?? DefaultAnimation;
                        break;
                    case Direction.Right:
                        Animation = WalkAnimationRight ?? DefaultAnimation;
                        break;
                    case Direction.NoneLeft:
                        Animation = NonActivityAnimationLeft ?? DefaultAnimation;
                        break;
                    case Direction.NoneRight:
                        Animation = NonActivityAnimationRight ?? DefaultAnimation;
                        break;
                }
        }

        DateTime cooldownTime = new DateTime();
        public int AutoAttackCooldown = 1000;


    }
}
