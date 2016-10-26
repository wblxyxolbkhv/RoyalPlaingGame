using System;
using System.Collections.Generic;
using SimplePhysicalEngine.NonPhysicalComponents;
using VisualPart;


namespace StartUpProject.Spells
{
    public class AutoAttack : ComplexSpell
    {
        public AutoAttack(List<RealObject> CollisionDomain, ComplexUnit caster)
        {
            RealObject = new RealObject(CollisionDomain);
            RealObject.Height = 200;
            RealObject.Width = 200;
            RealObject.SpeedX = 0;

            switch (caster.RealObject.direction)
            {
                case Direction.Left:
                case Direction.NoneLeft:
                    RealObject.Position = new SimplePhysicalEngine.Vector2(caster.RealObject.Position.X - RealObject.Width, caster.RealObject.Position.Y + caster.RealObject.Height - RealObject.Height);
                    RealObject.direction = Direction.Left;
                    break;
                case Direction.Right:
                case Direction.NoneRight:
                    RealObject.Position = new SimplePhysicalEngine.Vector2(caster.RealObject.Position.X + caster.RealObject.Width, caster.RealObject.Position.Y + caster.RealObject.Height - RealObject.Height);
                    RealObject.direction = Direction.Right;
                    break;
            }
            //caster.Animation.AnumationEnd += OnUnitDeath;
        }
    }
}
