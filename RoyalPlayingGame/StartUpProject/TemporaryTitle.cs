using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimplePhysicalEngine.NonPhysicalComponents;
/* Назначение: Класс для всплывающих записей (вроде урона)
 * Автор: Никитенко А.В.
 */
namespace StartUpProject
{
    /// <summary>
    /// всплывающие надписи
    /// </summary>
    class TemporaryTitle : ComplexObject
    {
        public TemporaryTitle(string title, int lifeTime, RealObject r)
        {
            StartInit(title, lifeTime, r);
        }
        public TemporaryTitle(string title, int lifeTime, RealObject r, bool critical)
        {
            StartInit(title, lifeTime, r);
            IsCritical = critical;
        }
        private void StartInit(string title, int lifeTime, RealObject r)
        {
            Title = title;
            LifeTimer = new Timer();
            LifeTimer.Interval = 1000;
            LifeTimer.Tick += OnTimerTick;
            IsActive = true;
            RealObject = r;
            RealObject.Jump(-0.1);
            LifeTimer.Start();
        }
        private void OnTimerTick(object sender, EventArgs e)
        {
            //LifeTime--;
            LifeTime++;
            if (LifeTime <= 0)
                IsActive = false;
        }

        protected string Title { get; set; }

        private bool IsCritical = false;
        private int LifeTime { get; set; }
        private Timer LifeTimer { get; set; }
        public override void PrintObject(PaintEventArgs e, int CameraBias)
        {
            //base.PrintObject(e, CameraBias);
            int size = 12;
            if (IsCritical)
                size = 16;
            e.Graphics.DrawString(
                Title,
                new System.Drawing.Font("Arial", size, System.Drawing.FontStyle.Bold),
                System.Drawing.Brushes.Red,
                new System.Drawing.PointF((float)RealObject.Position.X - CameraBias, (float)RealObject.Position.Y));
        }
    }
}
