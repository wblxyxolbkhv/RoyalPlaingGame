using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePhysicalEngine.NonPhysicalComponents
{
    public enum Direction { Left, Right, None}
    public class RealObject
    {
        public RealObject(List<RealObject> objs)
        {
            NearbyObjects = objs;
            refreshTimer = new Timer();
            refreshTimer.Interval = 20;
            refreshTimer.Tick += OnRefreshPosition;
            direction = Direction.None;
            NearbyObjects.Add(this);
        }
        public void Start()
        {
            refreshTimer.Start();
        }
        private void OnRefreshPosition(object sender, EventArgs e)
        {
            if (direction == Direction.None)
                return;
            switch (direction)
            {
                case Direction.Left:
                        StepLeft();
                        break;
                case Direction.Right:
                        StepRight();
                        break;
            }
        }

        private void StepLeft()
        {
            double step = Speed;
            foreach (RealObject ro in NearbyObjects)
            {
                if (this.Position.Y - ro.Position.Y > 0 && this.Position.Y - ro.Position.Y < this.Height ||
                    this.Position.Y - ro.Position.Y < 0 && ro.Position.Y - this.Position.Y < ro.Height)
                {
                    if (this.Position.X - ro.Position.X - ro.Width >= 0 && this.Position.X - ro.Position.X - ro.Width <= Speed)
                    {
                        step = Math.Min(this.Position.X - ro.Position.X - ro.Width, step);
                        continue;
                    }
                    //if (ro.Position.X + ro.Width - this.Position.X >= 0 /*|| ro.Position.X - this.Position.X <= this.Width && ro.Position.X - this.Position.X >= 0*/)
                    //    step = 0;
                }

            }
            this.Position.X -= step;
        }
        private void StepRight()
        {
            double step = Speed;
            foreach (RealObject ro in NearbyObjects)
            {
                if (this.Position.Y - ro.Position.Y > 0 && this.Position.Y - ro.Position.Y < this.Height ||
                    this.Position.Y - ro.Position.Y < 0 && ro.Position.Y - this.Position.Y < ro.Height)
                {
                    if (ro.Position.X - this.Position.X - this.Width >= 0 && ro.Position.X - this.Position.X - this.Width <= Speed)
                    {
                        step = Math.Min(ro.Position.X - this.Position.X - this.Width, step);
                        continue;
                    }
                    //if (this.Position.X + this.Width - ro.Position.X >= 0 /*|| this.Position.X - ro.Position.X <= ro.Width && this.Position.X - ro.Position.X >= 0*/)
                    //    step = 0;
                }
                
            }
            this.Position.X += step;
        }

        public double Speed { get; set; }
        public Vector2 Position { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }


        public Direction direction { get; set; }
        public List<RealObject> NearbyObjects { get; set; }

        Timer refreshTimer;
    }
}
