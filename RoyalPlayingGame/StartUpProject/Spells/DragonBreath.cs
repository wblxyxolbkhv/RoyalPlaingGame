using System;
using System.Collections.Generic;
using SimplePhysicalEngine.NonPhysicalComponents;
using VisualPart;

namespace StartUpProject.Spells
{
    class DragonBreath : ComplexSpell
    {
        public DragonBreath(List<RealObject> CollisionDomain, RealObject caster) : base(CollisionDomain, caster)
        {
            RealObject.Height = 108;
            RealObject.Width = 150;
            RealObject.SpeedX = 0;
            WalkAnimationLeft = new Animation("Spells/DragonBreath/Left", 60);
            WalkAnimationLeft.Mode = AnimationMode.Once;
            WalkAnimationRight = new Animation("Spells/DragonBreath/Right", 60);
            WalkAnimationLeft.Mode = AnimationMode.Once;
            NonActivityAnimationLeft = new Animation("Spells/DragonBreath/Left", 60);
            NonActivityAnimationLeft.Mode = AnimationMode.Once;
            NonActivityAnimationRight = new Animation("Spells/DragonBreath/Right", 60);
            NonActivityAnimationRight.Mode = AnimationMode.Once;
            switch (caster.direction)
            {
                case Direction.Left:
                case Direction.NoneLeft:
                    RealObject.Position = new SimplePhysicalEngine.Vector2(caster.Position.X - 150, caster.Position.Y - 40);
                    RealObject.direction = Direction.Left;
                    Animation = NonActivityAnimationLeft;
                    Animation.Start();
                    break;
                case Direction.Right:
                case Direction.NoneRight:
                    RealObject.Position = new SimplePhysicalEngine.Vector2(caster.Position.X + caster.Width - 30, caster.Position.Y - 40);
                    RealObject.direction = Direction.Right;
                    Animation = NonActivityAnimationRight;
                    Animation.Start();
                    break;
            }
            Animation.AnimationEnd += OnUnitDeath;
        }
    }
}
