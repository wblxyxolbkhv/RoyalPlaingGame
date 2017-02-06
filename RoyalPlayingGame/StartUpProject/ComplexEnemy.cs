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

namespace StartUpProject
{
    public class ComplexEnemy : ComplexUnit
    {
        public override void OnRefresh(object sender, EventArgs e)
        {
            RealObject.OnRefreshPosition(sender, e);
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
        public double AttackRadius { get; set; }
        public double AttackRange { get; set; }
        private void Decide()
        {
            PatrolMode();
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
        private void AttackMode()
        {
            Vector2 targetDirection = Target.RealObject.Position - RealObject.Position;
            
        }
        private void Attack(ComplexUnit target)
        {
            //Cast(CollisionDomain);
        }

        protected List<int> LootList = new List<int>();
        public override void OnUnitDeath()
        {
            base.OnUnitDeath();

            //LootDroped?.Invoke(LootList, this.RealObject.Position);
        }
        
        public event LootDropHandler LootDroped;
    }
    public delegate void LootDropHandler(List<int> itemIDs, Vector2 dropPoint);  
}
