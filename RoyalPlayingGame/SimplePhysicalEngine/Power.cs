using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePhysicalEngine
{
    /// <summary>
    /// сила, прилагаемая к обьекту
    /// </summary>
    public class Power
    {
        public Power(Vector2 direction, double multi, PhysicalObject o)
        {
            Direction = direction;
            Multiple = multi;
            PhysObject = o;
        }
        public Power(Vector2 direction, double multi)
        {
            Direction = direction;
            Multiple = multi;
        }
        /// <summary>
        /// обьект, к которому приложена сила
        /// </summary>
        public PhysicalObject PhysObject
        {
            get;
            private set;
        }
        /// <summary>
        /// направление приложения
        /// </summary>
        public Vector2 Direction
        {
            get;
            set;
        }
        /// <summary>
        /// множитель силы
        /// </summary>
        public double Multiple
        {
            get;set;
        }
        /// <summary>
        /// время приложения силы
        /// </summary>
        public double Time
        {
            get;set;
        }
        public static Power operator +(Power p1, Power p2)
        {
            Vector2 newDirection = p1.Multiple*p1.Direction + p2.Multiple*p2.Direction;
            Power v = new Power(newDirection, 1);
            return v;
        }
        public static Power operator -(Power p1, Power p2)
        {
            Vector2 newDirection = p1.Multiple * p1.Direction - p2.Multiple * p2.Direction;
            Power v = new Power(newDirection, 1);
            return v;
        }
        public static Power operator *(double d, Power v)
        {
            return new Power(new Vector2(d * v.Direction.X, d * v.Direction.Y), v.Multiple);
        }
    }
}
