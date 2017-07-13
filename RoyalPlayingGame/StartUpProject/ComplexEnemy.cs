using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimplePhysicalEngine.NonPhysicalComponents;
using VisualPart;
using System.Drawing;
using SimplePhysicalEngine;
/* Назначение: Базовый класс для всех врагов
 * Автор: Никитенко А.В.
 */
namespace StartUpProject
{
    public delegate void SpellCasted(ComplexSpell spell);
    public class ComplexEnemy : ComplexUnit
    {
        public override void OnRefresh(object sender, EventArgs e)
        {
            if (RealObject.SpeedX > 0)
                MaxSpeed = RealObject.SpeedX;
            RealObject.OnRefreshPosition(sender, e);
            Animation.OnUpdateFrame(GlobalGameComponents.Game.DeltaTime);
            if (Animation.Mode == AnimationMode.Once && Animation.IsActive)
                return;
            if (Unit != null && !Unit.IsAlive)
                return;
            else
                switch (RealObject.direction)
                {
                    case Direction.Left:
                    case Direction.NoneLeft:
                        Animation = WalkAnimationLeft;
                        break;
                    case Direction.Right:
                    case Direction.NoneRight:
                        Animation = WalkAnimationRight;
                        break;
                }
            Decide();
        }
        public override void PrintObject(PaintEventArgs e, int CameraBias)
        {
            base.PrintObject(e, CameraBias);

            e.Graphics.FillRectangle(System.Drawing.Brushes.Black,
                (float)RealObject.Position.X - CameraBias,
                (float)RealObject.Position.Y - 10,
                (float)RealObject.Width,
                5f);
            if (Unit.RealHealth <= 0)
                return;
            double percent = (double)Unit.RealHealth / (double)Unit.Health;
            Brush brush = null;
            if (percent <=1 && percent > 0.75)
                brush = new SolidBrush(Color.Green);
            else if (percent <= 0.75 && percent > 0.5)
                brush = new SolidBrush(Color.Yellow);
            else if (percent <= 0.5 && percent > 0.25)
                brush = new SolidBrush(Color.Orange);
            else if (percent <= 0.25 && percent >= 0)
                brush = new SolidBrush(Color.Red);

            e.Graphics.FillRectangle(brush,
                 (float)RealObject.Position.X - CameraBias,
                 (float)RealObject.Position.Y - 9,
                 (float)(RealObject.Width*percent),
                 4f);
        }


        public ComplexUnit Target { get; set; }
        public Vector2 PatrolPoint { get; set; }
        public double PatrolRadius { get; set; }
        public double AgressiveRadius { get; set; }
        public double AttackRange { get; set; }

        private void Decide()
        {
            if (Target == null)
            {
                PatrolMode();
                return;
            }
            if ((Target.RealObject.Position - this.RealObject.Position).Length > AgressiveRadius)
                PatrolMode();
            else AgressiveMode();

        }
        private void PatrolMode()
        {
            Vector2 patrolDirection = PatrolPoint - RealObject.Position;
            // слева от точки
            if (patrolDirection.X >= 0)
            {
                if (RealObject.direction == Direction.Right)
                    return;
                else if (patrolDirection.SqLength >= PatrolRadius)
                    RealObject.direction = Direction.Right;
            }
            // справа от точки
            else
            {
                if (RealObject.direction == Direction.Left)
                    return;
                else if (patrolDirection.SqLength >= PatrolRadius)
                    RealObject.direction = Direction.Left;
            }
        }
        private void AgressiveMode()
        {

            // цель слева
            if (Target.RealObject.Position.X < RealObject.Position.X)
            {
                //поворачиваемся
                RealObject.direction = Direction.Left;
                RealObject.SpeedX = MaxSpeed;
                // бьем
                if (RealObject.Position.X - 
                    Target.RealObject.Position.X - 
                    Target.RealObject.Width <= AttackRange/2)
                {
                    RealObject.direction = Direction.Left;
                    RealObject.SpeedX = 0;
                    Attack(Target);
                }
            }
            // цель справа
            else
            {
                //поворачиваемся
                RealObject.direction = Direction.Right;
                RealObject.SpeedX = MaxSpeed;
                // бьем
                if (Target.RealObject.Position.X -
                    RealObject.Position.X -
                    RealObject.Width <= AttackRange / 2)
                {
                    RealObject.direction = Direction.Right;
                    RealObject.SpeedX = 0;
                    Attack(Target);
                }
            }



            
        }
        // TODO: да простят меня боги за этот убогий костыль
        // для предотвращения того, что враг не останавливается при ударе
        private double MaxSpeed;

        public event SpellCasted AttackCasted;
        private void Attack(ComplexUnit target)
        {
            AttackCasted?.Invoke(Cast(target.RealObject.NearbyObjects));
        }
        
        public override void OnUnitDeath()
        {
            base.OnUnitDeath();
        }
        
    }
}
