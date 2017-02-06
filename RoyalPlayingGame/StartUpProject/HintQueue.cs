using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartUpProject
{
    public class HintQueue
    {
        class Hint
        {
            public Hint(string message)
            {
                LifeTime = 100;
                Message = message;
            }
            public Hint(string message, int time)
            {
                LifeTime = time;
                Message = message;
            }
            public int LifeTime;
            public string Message;
        }
        private List<Hint> Hints { get; set; } = new List<Hint>();
        public System.Drawing.Brush Brush = System.Drawing.Brushes.Black;

        public bool Contains(string hintMessage)
        {
            foreach (Hint h in Hints)
            {
                if (h.Message == hintMessage)
                    return true;
            }
            return false;
        }
        public void AddHint(string message)
        {
            Hints.Add(new Hint(message));
        }
        public void AddHint(string message, int time)
        {
            Hints.Add(new Hint(message, time));
        }
        public void OnRefresh(int deltaTime)
        {
            List<Hint> removeList = new List<Hint>();
            foreach (Hint h in Hints)
            {
                h.LifeTime -= deltaTime;
                if (h.LifeTime <= 0)
                    removeList.Add(h);
            }
            foreach (Hint h in removeList)
                Hints.Remove(h);
            removeList.Clear();
        }
        public void PrintHints(PaintEventArgs e)
        {
            for (int i = 1;i <= 3; i++)
            {
                if (Hints.Count < i)
                    break;
                Hint hint = Hints[Hints.Count - i];

                e.Graphics.DrawString(hint.Message,
                    new System.Drawing.Font("Arial", 10),
                    this.Brush,
                    700,
                    100 - i*20);
            }
        }
    }
}
