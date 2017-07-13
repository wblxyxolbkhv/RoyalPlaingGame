using System;
using System.Collections.Generic;
using SimplePhysicalEngine.NonPhysicalComponents;
using SimplePhysicalEngine;
using VisualPart;
/* Назначение: Молния
 * Автор: Никитенко А.В.
 */
namespace StartUpProject.Spells
{
    public class Lighting : ComplexSpell
    {
        public Lighting(Vector2 place) : base()
        {
            RealObject.Height = 131;
            RealObject.Width = 84;
            RealObject.SpeedX = 0;
            NonActivityAnimationLeft = new Animation("Spells/Lighting", 100, System.Drawing.Color.FromArgb(0, 128, 0));
            NonActivityAnimationLeft.Mode = AnimationMode.Once;
            
            RealObject.Position = new SimplePhysicalEngine.Vector2(place.X, place.Y);
            RealObject.direction = Direction.Right;
            Animation = NonActivityAnimationLeft;
            //Animation.Start();
            
            Animation.AnimationEnd += OnUnitDeath;
        }
    }
}
