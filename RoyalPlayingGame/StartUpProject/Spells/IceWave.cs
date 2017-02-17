using System;
using System.Collections.Generic;
using SimplePhysicalEngine.NonPhysicalComponents;
using VisualPart;

namespace StartUpProject.Spells
{
    public class IceWave : ComplexSpell
    {
        public IceWave(List<RealObject> CollisionDomain, RealObject caster) : base(CollisionDomain, caster)
        {
            RealObject.Height = 131;
            RealObject.Width = 84;
            RealObject.SpeedX = 0;
            WalkAnimationLeft = new Animation("Spells/IceWave/Left", 100);
            WalkAnimationLeft.Mode = AnimationMode.Once;
            WalkAnimationRight = new Animation("Spells/IceWave/Right", 100);
            WalkAnimationLeft.Mode = AnimationMode.Once;
            NonActivityAnimationLeft = new Animation("Spells/IceWave/Left", 100);
            NonActivityAnimationLeft.Mode = AnimationMode.Once;
            NonActivityAnimationRight = new Animation("Spells/IceWave/Right", 100);
            NonActivityAnimationRight.Mode = AnimationMode.Once;
            switch (caster.direction)
            {
                case Direction.Left:
                case Direction.NoneLeft:
                    RealObject.Position = new SimplePhysicalEngine.Vector2(caster.Position.X - RealObject.Width, caster.Position.Y + caster.Height - RealObject.Height);
                    RealObject.direction = Direction.Left;
                    Animation = NonActivityAnimationLeft;
                    Animation.Start();
                    break;
                case Direction.Right:
                case Direction.NoneRight:
                    RealObject.Position = new SimplePhysicalEngine.Vector2(caster.Position.X + caster.Width, caster.Position.Y + caster.Height - RealObject.Height);
                    RealObject.direction = Direction.Right;
                    Animation = NonActivityAnimationRight;
                    Animation.Start();
                    break;
            }
            Animation.AnimationEnd += OnUnitDeath;
        }
    }
}
