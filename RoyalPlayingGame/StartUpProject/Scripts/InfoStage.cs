using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartUpProject.GlobalGameComponents;

namespace StartUpProject.Scripts
{
    public class InfoStage : ScriptStage
    {
        public InfoStage(int time, string info)
        {
            Time = time;
            InformationString = info;
        }

        /// <summary>
        /// время когда истекает время показа информации
        /// </summary>
        private int Time;
        public string InformationString { get; private set; }

        private DateTime FinishTime = DateTime.MinValue;
        public override bool IsFinished()
        {
            if (FinishTime == DateTime.MinValue)
                FinishTime = Game.CurrentTime.AddMilliseconds(Time);
            if (FinishTime.CompareTo(Game.CurrentTime) <= 0)
                return true;
            return false;
        }
    }
}
