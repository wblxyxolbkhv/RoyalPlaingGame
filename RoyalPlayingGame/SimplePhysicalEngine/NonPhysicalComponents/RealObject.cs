using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimplePhysicalEngine;

namespace SimplePhysicalEngine.NonPhysicalComponents
{
    public enum Direction { Left, Right, NoneLeft, NoneRight}
    public class RealObject
    {
        private int dt = 20;
        public RealObject()
        {
            NearbyObjects = new List<RealObject>();
            direction = Direction.NoneRight;
            NearbyObjects.Add(this);

            this.gravity = null;
            SpeedY = 0;
            IsJumpingUp = false;
            IsJumpingDown = false;
            Mass = 5;
            IsTrigger = false;
            TriggerCollisionDetected+= TriggersColiisionsListener.OnTriggerCollisionDetected;
        }
        public RealObject(List<RealObject> objs)
        {
            NearbyObjects = objs;
            direction = Direction.NoneRight;
            NearbyObjects.Add(this);

            this.gravity = null;
            SpeedY = 0;
            IsJumpingUp = false;
            IsJumpingDown = false;
            Mass = 5;
            IsTrigger = false;
            TriggerCollisionDetected += TriggersColiisionsListener.OnTriggerCollisionDetected;

        }
        public RealObject(List<RealObject> objs, int id)
        {
            NearbyObjects = objs;
            direction = Direction.NoneRight;
            NearbyObjects.Add(this);

            this.gravity = null;
            SpeedY = 0;
            IsJumpingUp = false;
            IsJumpingDown = false;
            Mass = 5;
            ID = id;
            IsTrigger = false;
            TriggerCollisionDetected += TriggersColiisionsListener.OnTriggerCollisionDetected;
        }
        public RealObject(List<RealObject> objs, int id, Power gravity)
        {
            NearbyObjects = objs;
            direction = Direction.NoneRight;

            this.gravity = gravity;
            SpeedY = 0;
            IsJumpingUp = false;
            IsJumpingDown = false;
            Mass = 5;
            ID = id;
            IsTrigger = false;
            TriggerCollisionDetected += TriggersColiisionsListener.OnTriggerCollisionDetected;
        }
        public RealObject(List<RealObject> objs, Power gravity)
        {
            NearbyObjects = objs;
            direction = Direction.NoneRight;
            NearbyObjects.Add(this);

            this.gravity = gravity;
            SpeedY = 0;
            IsJumpingUp = false;
            IsJumpingDown = true;
            Mass = 5;
            IsTrigger = false;
            TriggerCollisionDetected += TriggersColiisionsListener.OnTriggerCollisionDetected;

        }
        public void OnRefreshPosition(object sender, EventArgs e)
        {
            if (Fixed)
                return;
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
                case Direction.NoneRight:
                case Direction.NoneLeft:
                    break;
            }
        }
        public int ID { get; protected set; }
        public bool IsTrigger { get; set; }
        protected double DoCollision(double step, RealObject ro)
        {
            if (!IsTrigger && !ro.IsTrigger)
            {
                if (CollisionDetected != null && !ro.Equals(this))
                    CollisionDetected(ro, this);
                step = Math.Min(this.Position.X - ro.Position.X - ro.Width, step);
                step = Math.Max(0, step);
            }
            else
            {
                if (TriggerCollisionDetected != null && !ro.Equals(this))
                {
                    TriggerCollisionDetected(ro, this);
                }
            }
            return step;
        }
        protected virtual void StepLeft()
        {
            double step = SpeedX;
            foreach (RealObject ro in NearbyObjects)
            {
                if (this.Position.Y - ro.Position.Y >= 0 && this.Position.Y - ro.Position.Y < this.Height ||
                    this.Position.Y - ro.Position.Y <= 0 && ro.Position.Y - this.Position.Y < ro.Height)
                {
                    if (this.Position.X <= ro.Position.X + ro.Width && this.Position.X >= ro.Position.X - this.Width)
                        if (ro.Width != 4000 && this.Width != 4000 && ro.Width != 72 && this.Width != 72)
                            DoCollision(step, ro);
                    if (this.Position.X - ro.Position.X - ro.Width >= 0 && this.Position.X - ro.Position.X - ro.Width < SpeedX)
                    {
                        step = DoCollision(step, ro);
                        continue;
                    }
                }

            }
            this.Position.X -= step;
        }
        protected virtual void StepRight()
        {
            double step = SpeedX;
            foreach (RealObject ro in NearbyObjects)
            {
                if (this.Position.Y - ro.Position.Y >= 0 && this.Position.Y - ro.Position.Y < ro.Height ||
                    this.Position.Y - ro.Position.Y <= 0 && ro.Position.Y - this.Position.Y < this.Height)
                {
                    if (this.Position.X <= ro.Position.X + ro.Width && this.Position.X >= ro.Position.X - this.Width)
                        if (ro.Width != 4000 && this.Width != 4000 && ro.Width != 72 && this.Width != 72)
                            DoCollision(step, ro);
                    if (ro.Position.X - this.Position.X - this.Width >= 0 && ro.Position.X - this.Position.X - this.Width < SpeedX)
                    {
                        step = DoCollision(step, ro);
                        continue;
                    }
                }
                
            }
            this.Position.X += step;
        }

        public double SpeedX { get; set; }
        public double SpeedY
        {
            get;
            set;
        }
        protected Power gravity { get; set; }
        public Vector2 Position { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }

        public Direction direction { get; set; }
        public List<RealObject> NearbyObjects { get; set; }


        

        public bool IsJumpingUp { get; protected set; }
        public bool IsJumpingDown { get; protected set; }

        protected double Mass { get; set; }

        protected virtual void StepDown()
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
                        if (!ro.IsTrigger)
                        {
                            step = Math.Min(ro.Position.Y - this.Position.Y - this.Height, step);
                            IsJumpingDown = false;
                            IsJumpingUp = false;
                            SpeedY = 0;
                        }
                        continue;
                    }
                }
            }
            this.Position.Y += step;
        }
        protected virtual void StepUp()
        {
            SpeedY = SpeedY + dt * GetBoost().Y;
            double newPositionY = Position.Y + SpeedY * dt + dt * dt * 1 / 2 * GetBoost().Y;
            double step = Position.Y - newPositionY;
            if (SpeedY == 0)
                return;
            foreach (RealObject ro in NearbyObjects)
            {
                if (this.Equals(ro))
                    continue;
                if (this.Position.X - ro.Position.X >= 0 && this.Position.X - ro.Position.X <= ro.Width ||
                    this.Position.X - ro.Position.X <= 0 && ro.Position.X - this.Position.X <= this.Width)
                {
                    if (this.Position.Y - ro.Position.Y - ro.Height >= 0 && this.Position.Y - ro.Position.Y - ro.Height < Position.Y - newPositionY)
                    {
                        if (!ro.IsTrigger)
                        {
                            step = Math.Min(this.Position.Y - ro.Position.Y - ro.Height, step);
                            SpeedY = 0;
                            IsJumpingUp = false;
                            IsJumpingDown = true;
                        }
                        continue;
                    }
                }
            }
            if (Math.Abs(SpeedY) < 0.05 || step < Position.Y - newPositionY)
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
        /// <summary>
        /// метод для получения точки для респауна атакующих заклинаний (только для кастеров)
        /// </summary>
        /// <returns></returns>
        public Vector2 GetCastPoint()
        {
            Vector2 res = null;
            if (direction == Direction.Left || direction == Direction.NoneLeft)
            {
                res = new Vector2(Position.X + 9 - 26, Position.Y + 30);
            }
            if (direction == Direction.Right || direction == Direction.NoneRight)
            {
                res = new Vector2(Position.X + Width - 9, Position.Y + 30);
            }
            return res;
        }

        private bool Fixed;
        public void Fixate()
        {
            Fixed = true;
        }
        public void Unfixate()
        {
            Fixed = false;
        }

        public event CollisionHandler CollisionDetected;
        public event CollisionHandler TriggerCollisionDetected;
    }
    public delegate void CollisionHandler(RealObject o1, RealObject o2);
}
