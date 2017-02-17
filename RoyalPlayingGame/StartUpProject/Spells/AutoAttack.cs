using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SimplePhysicalEngine.NonPhysicalComponents;
using VisualPart;


namespace StartUpProject.Spells
{
    public class AutoAttack : ComplexSpell
    {
        public AutoAttack(List<RealObject> CollisionDomain, ComplexUnit caster)
        {
            RealObject = new RealObject(CollisionDomain);
            RealObject.Height = 50;
            RealObject.Width = 50;
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
            caster.AttackAnimationLeft.AnimationEnd += OnUnitDeath;
            caster.AttackAnimationRight.AnimationEnd += OnUnitDeath;
        }
        public override void PrintObject(PaintEventArgs e, int CameraBias)
        {
                e.Graphics.FillRectangle(System.Drawing.Brushes.White,
                    (float)RealObject.Position.X - IndentX - CameraBias,
                    (float)RealObject.Position.Y - IndentY,
                    (float)RealObject.Width,
                    (float)RealObject.Height);
            
        }
    }
}
