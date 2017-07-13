using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Назначение: Сила
 * для просчета сложных траекторий движения
 * Автор: Никитенко А.В.
 */
namespace SimplePhysicalEngine
{
    /// <summary>
    /// сила, прилагаемая к обьекту
    /// </summary>
    public class Power
    {
        public Power(Vector2 direction, PhysicalObject o)
        {
            Direction = direction;
            PhysObject = o;
        }
        public Power(Vector2 direction)
        {
            Direction = direction;
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
        /// время приложения силы
        /// </summary>
        public double Time
        {
            get;set;
        }
        public static Power operator +(Power p1, Power p2)
        {
            Vector2 newDirection = p1.Direction + p2.Direction;
            Power v = new Power(newDirection);
            return v;
        }
        public static Power operator -(Power p1, Power p2)
        {
            Vector2 newDirection = p1.Direction - p2.Direction;
            Power v = new Power(newDirection);
            return v;
        }
        public static Power operator *(double d, Power v)
        {
            return new Power(new Vector2(d * v.Direction.X, d * v.Direction.Y));
        }
    }
}
