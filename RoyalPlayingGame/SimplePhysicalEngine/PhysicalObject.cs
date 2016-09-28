using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimplePhysicalEngine
{
    /// <summary>
    /// интерфейс, добавляющий физическое тело объекту
    /// </summary>
    public class PhysicalObject
    {
        double dt = 30;
        public PhysicalObject()
        {
            Powers = new List<Power>();
            Speed = new Vector2(0, 0);

            refreshTimer.Tick += OnRefresh;
            refreshTimer.Interval = (int)dt;
            refreshTimer.Start();
        }

        private void OnRefresh(object sender, EventArgs e)
        {
            Speed.X = Speed.X + dt*GetBoost().X;
            Position.X = Position.X + Speed.X * dt + dt*dt*1/2*GetBoost().X;

            Speed.Y = Speed.Y + dt * GetBoost().Y;
            Position.Y = Position.Y + Speed.Y * dt + dt * dt * 1 / 2 * GetBoost().Y;
        }

        /// <summary>
        /// позиция в мире
        /// </summary>
        public Vector2 Position { get; set; }
        /// <summary>
        /// масса обьекта
        /// </summary>
        public double Mass{ get; set; }
        /// <summary>
        /// скорость обьекта
        /// </summary>
        public Vector2 Speed { get; set; }
        private Timer refreshTimer = new Timer();

        // все объекты будут у нас прямоугольные

        /// <summary>
        /// ширина по Х
        /// </summary>
        public double Width { get; set; }
        /// <summary>
        /// высота по Y
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// все силы, действующие на тело
        /// </summary>
        public List<Power> Powers { get; set; }

        public event CollisionHandler CollisionDetected;









        /// <summary>
        /// возвращает равнодействующую всех сил действующих на тело
        /// </summary>
        /// <returns></returns>
        private Power ResultantPower()
        {
            Power res = new Power(new Vector2(0, 0), 1);
            foreach (Power p in Powers)
                res += p;
            return res;
        }
        /// <summary>
        /// получить ускорение, действующее на тело
        /// </summary>
        /// <param name="p"></param>
        /// <param name="mass"></param>
        /// <returns></returns>
        private Vector2 GetBoost(Power p, double mass)
        {
            if (mass == 0)
                return new Vector2(0, 0);
            Vector2 v = p.Multiple * p.Direction;
            v = (1 / mass) * v;
            return v;
        } 
        /// <summary>
        /// получить ускорение, действующее на тело
        /// </summary>
        /// <returns></returns>
        private Vector2 GetBoost()
        {
            return GetBoost(this.ResultantPower(), Mass);
        }
        

    }
    public delegate void CollisionHandler(PhysicalObject o1, PhysicalObject o2);
        
}
