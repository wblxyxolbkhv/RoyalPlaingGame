using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartUpProject.GlobalGameComponents;
/* Назначение: Стадия сценария, для показа текста на экране
 * Автор: Никитенко А.В.
 */
namespace StartUpProject.Scripts
{
    public class InfoStage : ScriptStage
    {
        public InfoStage(int time, string info, string name):base(name)
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
