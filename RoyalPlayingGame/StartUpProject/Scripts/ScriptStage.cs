using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpProject.Scripts
{
    public delegate bool ScriptFinish();
    public class ScriptStage
    {
        public virtual bool IsFinished()
        {
            if (isFinished)
                return true;
            if (IsFinishedExternal != null)
            {
                isFinished = IsFinishedExternal();
                return isFinished;
            }
            return true;
        }
        public bool isWaiting = false;
        public bool isFinished = false;
        public ScriptFinish IsFinishedExternal;

        public ScriptStage NextStage { get; set; }
    }
}
