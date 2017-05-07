using System;
using System.Collections.Generic;
using SimplePhysicalEngine.NonPhysicalComponents;
using SimplePhysicalEngine;
using VisualPart;

namespace StartUpProject.Spells
{
    public class Orb : ComplexSpell
    {
        public Orb(Vector2 place) : base()
        {
            RealObject.Height = 131;
            RealObject.Width = 84;
            RealObject.SpeedX = 0;
            NonActivityAnimationLeft = new Animation("Spells/Orb", 100, System.Drawing.Color.FromArgb(0, 128, 0));
            NonActivityAnimationLeft.Mode = AnimationMode.Once;

            RealObject.Position = new SimplePhysicalEngine.Vector2(place.X, place.Y);
            RealObject.direction = Direction.Right;
            Animation = NonActivityAnimationLeft;
            //Animation.Start();

            Animation.AnimationEnd += OnUnitDeath;
        }
    }
}
