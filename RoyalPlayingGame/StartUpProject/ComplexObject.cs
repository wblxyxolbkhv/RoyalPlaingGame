using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame;
using SimplePhysicalEngine.NonPhysicalComponents;
using SimplePhysicalEngine;
using VisualPart;
using System.Drawing;
using System.Windows.Forms;

namespace StartUpProject
{
    public class ComplexObject
    {

        public Unit Unit { get; set; }
        public RealObject RealObject { get; set; }
        public Animation Animation { get; set; }
        public Image CurrentFrame
        {
            get
            {
                if (Animation != null && Animation.CurrentFrame!=null)
                    return Animation.CurrentFrame;
                return null;
            }
        }

        public Animation DefaultAnimation { get; set; }

        public Animation NonActivityAnimationLeft { get; set; }
        public Animation NonActivityAnimationRight { get; set; }
        public Animation WalkAnimationLeft { get; set; }
        public Animation WalkAnimationRight { get; set; }
        public Animation JumpAnimationLeft { get; set; }
        public Animation JumpAnimationRight { get; set; }
        public Animation Cast1AnimationLeft { get; set; }
        public Animation Cast1AnimationRight { get; set; }

        public virtual void OnRefresh(object sender, EventArgs e)
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

        public ComplexObject Cast(NegativeSpell spell, RealObject caster, List<RealObject> CollisionDomain)
        {
            ComplexObject flyingSpell = new ComplexObject();
            flyingSpell.RealObject = new RealObject(CollisionDomain);
            flyingSpell.RealObject.Position = caster.GetCastPoint();
            flyingSpell.RealObject.Height = 17;
            flyingSpell.RealObject.Width = 26;
            flyingSpell.RealObject.SpeedX = 6;
            flyingSpell.WalkAnimationLeft = new Animation("Fireball/WalkLeftFireball", 200);
            flyingSpell.WalkAnimationLeft.Start();
            flyingSpell.WalkAnimationRight = new Animation("Fireball/WalkRightFireball", 200);
            flyingSpell.WalkAnimationRight.Start();
            
            switch (caster.direction)
            {
                case Direction.Left:
                case Direction.NoneLeft:
                    flyingSpell.RealObject.direction = Direction.Left;
                    flyingSpell.Animation = flyingSpell.WalkAnimationLeft;
                    Animation = Cast1AnimationLeft;
                    Animation.Start();
                    break;
                case Direction.Right:
                case Direction.NoneRight:
                    flyingSpell.RealObject.direction = Direction.Right;
                    flyingSpell.Animation = flyingSpell.WalkAnimationRight;
                    Animation = Cast1AnimationRight;
                    Animation.Start();
                    break;
            }
            return flyingSpell;
        }
        public void PrintObject(PaintEventArgs e, int CameraBias)
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
