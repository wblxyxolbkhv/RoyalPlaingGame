using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Назначение: Вектор в двумерном пространстве
 * Автор: Никитенко А.В.
 */
namespace SimplePhysicalEngine
{
    /// <summary>
    /// двумерный вектор
    /// </summary>
    public class Vector2
    {
        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double X { get; set; }
        public double Y { get; set; }
        /// <summary>
        /// длина вектора
        /// </summary>
        public double Length
        {
            get
            {
                return Math.Sqrt(SqLength);
            }
        }
        /// <summary>
        /// квадрат длины вектора,
        /// считается быстрее чем просто длина,
        /// для динамических расчетов лучше использовать ее
        /// </summary>
        public double SqLength
        {
            get
            {
                return X* X +Y * Y;
            }
        }
        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            Vector2 v = new Vector2(v1.X + v2.X, v1.Y + v2.Y);
            return v;
        }
        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            Vector2 v = new Vector2(v1.X - v2.X, v1.Y - v2.Y);
            return v;
        }
        public static Vector2 operator *(double d, Vector2 v)
        {
            return new Vector2(d * v.X, d * v.Y);
        }
        /// <summary>
        /// передает расстояние от одной точки до другой
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static double GetDistance(Vector2 v1, Vector2 v2)
        {
            double distance = 0;

            if (v1 == null || v2 == null)
                return distance;

            Vector2 v3 = v1 - v2;
            distance = v3.SqLength;

            return distance;
        }
        public static bool IsOverlayX(Vector2 v1, Vector2 v2)
        {
            return false;
        }
    }
}
