using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Units;
using RoyalPlayingGame.Spell;
using SimplePhysicalEngine.NonPhysicalComponents;
using SimplePhysicalEngine;
using VisualPart;
using System.Drawing;
using System.Windows.Forms;

namespace StartUpProject
{
    public class ComplexObject
    {
        public ComplexObject()
        {
            IsActive = true;
        }
        protected void OnUnitDeath()
        {
            IsActive = false;
            RealObject.Fixate();
            Animation = DeathAnimation;
            DeathAnimation.Start();
        }

        public Unit Unit
        {
            get { return unit; }
            set
            {
                unit = value;
                unit.Death += OnUnitDeath;
            }
        }
        private Unit unit;

        public RealObject RealObject { get; set; }
        public Animation Animation { get; set; }
        public Image CurrentFrame
        {
            get
            {
                if (Animation != null && Animation.CurrentFrame != null)
                    return Animation.CurrentFrame;
                return null;
            }
        }
        public bool IsActive { get; set; }

        public Animation DefaultAnimation { get; set; }

        public Animation NonActivityAnimationLeft { get; set; }
        public Animation NonActivityAnimationRight { get; set; }
        public Animation WalkAnimationLeft { get; set; }
        public Animation WalkAnimationRight { get; set; }
        public Animation DeathAnimation { get;set;}

        public virtual void OnRefresh(object sender, EventArgs e)
        {
            RealObject.OnRefreshPosition(sender, e);
            if (Animation.Mode == AnimationMode.Once && Animation.IsActive)
                return;
            if (Unit != null && !Unit.IsAlive)
                return;
            if (this is ComplexSpell && !(this as ComplexSpell).IsActive)
                return;
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



        public virtual void PrintObject(PaintEventArgs e, int CameraBias)
        {
            if (CurrentFrame == null)
                e.Graphics.FillRectangle(System.Drawing.Brushes.Black,
                    (float)RealObject.Position.X - CameraBias,
                    (float)RealObject.Position.Y,
                    (float)RealObject.Width,
                    (float)RealObject.Height);
            else
                e.Graphics.DrawImage(CurrentFrame,
                    (float)RealObject.Position.X - CameraBias,
                    (float)RealObject.Position.Y);
        }


        
        
    }
}
