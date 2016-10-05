using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame;
using SimplePhysicalEngine.NonPhysicalComponents;
using VisualPart;
using System.Drawing;

namespace StartUpProject
{
    public class ComplexObject
    {

        private Unit Unit { get; set; }
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

        public Animation NonActivityAnimationLeft { get; set; }
        public Animation NonActivityAnimationRight { get; set; }
        public Animation WalkAnimationLeft { get; set; }
        public Animation WalkAnimationRight { get; set; }
        public Animation JumpAnimationLeft { get; set; }
        public Animation JumpAnimationRight { get; set; }

        public void OnRefresh(object sender, EventArgs e)
        {
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
            RealObject.OnRefreshPosition(sender, e);
        }
    }
}
