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
                LifeTime = 3000;
                Message = message;
            }
            public int LifeTime;
            public string Message;
        }
        private List<Hint> Hints { get; set; }
        public void AddHint(string message)
        {
            Hints.Add(new Hint(message));
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
        public void PrintHints(PaintEventArgs e, int CameraBias)
        {

        }
    }
}
