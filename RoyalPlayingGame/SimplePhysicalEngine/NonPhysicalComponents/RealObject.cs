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
        private int dt = 20;
        public RealObject(List<RealObject> objs)
        {
            NearbyObjects = objs;
            refreshTimer = new Timer();
            refreshTimer.Interval = dt;
            //refreshTimer.Tick += OnRefreshPosition;
            direction = Direction.None;
            NearbyObjects.Add(this);

            this.gravity = null;
            SpeedY = 0;
            IsJumpingUp = false;
            IsJumpingDown = true;
            Mass = 5;
            
        }
        public RealObject(List<RealObject> objs, Power gravity)
        {
            NearbyObjects = objs;
            refreshTimer = new Timer();
            refreshTimer.Interval = dt;
            //refreshTimer.Tick += OnRefreshPosition;
            direction = Direction.None;
            NearbyObjects.Add(this);

            this.gravity = gravity;
            SpeedY = 0;
            IsJumpingUp = false;
            IsJumpingDown = true;
            Mass = 5;

        }
        public void Start()
        {
            refreshTimer.Start();
        }
        public void OnRefreshPosition(object sender, EventArgs e)
        {
            if (IsJumpingUp)
                StepUp();
            else StepDown();
            switch (direction)
            {
                case Direction.Left:
                        StepLeft();
                        break;
                case Direction.Right:
                        StepRight();
                        break;
                case Direction.None:
                    break;
            }
        }

        private void StepLeft()
        {
            double step = SpeedX;
            foreach (RealObject ro in NearbyObjects)
            {
                if (this.Position.Y - ro.Position.Y >= 0 && this.Position.Y - ro.Position.Y < this.Height ||
                    this.Position.Y - ro.Position.Y <= 0 && ro.Position.Y - this.Position.Y < ro.Height)
                {
                    if (this.Position.X - ro.Position.X - ro.Width >= 0 && this.Position.X - ro.Position.X - ro.Width < SpeedX)
                    {
                        step = Math.Min(this.Position.X - ro.Position.X - ro.Width, step);
                        continue;
                    }
                }

            }
            this.Position.X -= step;
        }
        private void StepRight()
        {
            double step = SpeedX;
            foreach (RealObject ro in NearbyObjects)
            {
                if (this.Position.Y - ro.Position.Y >= 0 && this.Position.Y - ro.Position.Y < ro.Height ||
                    this.Position.Y - ro.Position.Y <= 0 && ro.Position.Y - this.Position.Y < this.Height)
                {
                    if (ro.Position.X - this.Position.X - this.Width >= 0 && ro.Position.X - this.Position.X - this.Width < SpeedX)
                    {
                        step = Math.Min(ro.Position.X - this.Position.X - this.Width, step);
                        continue;
                    }
                }
                
            }
            this.Position.X += step;
        }

        public double SpeedX { get; set; }
        public Vector2 Position { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }

        public Direction direction { get; set; }
        public List<RealObject> NearbyObjects { get; set; }


        private Power gravity { get; set; }
        private double SpeedY {
            get;
            set; }

        private bool IsJumpingUp { get; set; }
        private bool IsJumpingDown { get; set; }
        private double JumpHeight { get; set; }

        private double Mass { get; set; }

        private void StepDown()
        {
            if (gravity == null)
                return;
            SpeedY = SpeedY + dt * GetBoost().Y;
            double newPositionY = Position.Y + SpeedY * dt + dt * dt * 1 / 2 * GetBoost().Y;
            double step = newPositionY - Position.Y;
            if (SpeedY == 0)
                return;
            foreach (RealObject ro in NearbyObjects)
            {
                if (this.Position.X - ro.Position.X >= 0 && this.Position.X - ro.Position.X <= ro.Width ||
                    this.Position.X - ro.Position.X <= 0 && ro.Position.X - this.Position.X <= this.Width)
                {
                    if (ro.Position.Y - this.Position.Y - this.Height >= 0 && ro.Position.Y - this.Position.Y - this.Height < step)
                    {
                        step = Math.Min(ro.Position.Y - this.Position.Y - this.Height, step);
                        IsJumpingDown = false;
                        IsJumpingUp = false;
                        SpeedY = 0;
                        continue;
                    }
                }
            }
            this.Position.Y += step;
        }
        private void StepUp()
        {
            if (gravity == null)
                return;
            SpeedY = SpeedY + dt * GetBoost().Y;
            double newPositionY = Position.Y + SpeedY * dt + dt * dt * 1 / 2 * GetBoost().Y;
            double step = Position.Y - newPositionY;
            if (SpeedY == 0)
                return;
            foreach (RealObject ro in NearbyObjects)
            {
                if (this.Position.X - ro.Position.X >= 0 && this.Position.X - ro.Position.X <= ro.Width ||
                    this.Position.X - ro.Position.X <= 0 && ro.Position.X - this.Position.X <= this.Width)
                {
                    if (this.Position.Y - ro.Position.Y - ro.Height >= 0 && this.Position.Y - ro.Position.Y - ro.Height < Position.Y - newPositionY)
                    {
                        step = Math.Min(this.Position.Y - ro.Position.Y - ro.Height, step);
                        SpeedY = 0;
                        IsJumpingUp = false;
                        IsJumpingDown = true;
                        continue;
                    }
                }
            }
            if (Math.Abs(SpeedY) < 0.01 || step < Position.Y - newPositionY)
            {
                IsJumpingDown = true;
                IsJumpingUp = false;
                SpeedY = 0;
            }
            this.Position.Y -= step;

        }
        /// <summary>
        /// передать отрицательное
        /// </summary>
        /// <param name="speed"></param>
        public void Jump(double speed)
        {
            if (IsJumpingDown || IsJumpingUp)
                return;
            SpeedY = speed;
            IsJumpingUp = true;
        }
        private Vector2 GetBoost(Power p, double mass)
        {
            if (mass == 0 || p == null)
                return new Vector2(0, 0);
            Vector2 v = p.Direction;
            v = (1 / mass) * v;
            return v;
        }
        private Vector2 GetBoost()
        {
            return GetBoost(gravity, Mass);
        }
        Timer refreshTimer;
    }
}
