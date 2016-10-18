﻿using System;
using System.Collections.Generic;
using SimplePhysicalEngine.NonPhysicalComponents;
using VisualPart;


namespace StartUpProject.Spells
{
    public class AutoAttack : ComplexSpell
    {
        public AutoAttack(List<RealObject> CollisionDomain, RealObject caster)
        {
            RealObject = new RealObject(CollisionDomain);
            RealObject.Height = 108;
            RealObject.Width = 150;
            RealObject.SpeedX = 0;
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
            Animation.AnumationEnd += OnUnitDeath;
        }
    }
}
