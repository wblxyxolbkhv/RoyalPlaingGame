using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace StartUpProject.Scripts
{
    /// <summary>
    /// класс
    /// </summary>
    public class RealTimeScriptStage : ScriptStage
    {
        public RealTimeScriptStage(string name) : base(name) { }

        public Thread Thread;
        public ThreadStart RealTimeAction;
        public override bool IsFinished()
        {
            if (Thread == null)
            {
                if (IsFinishedExternal != null)
                    return IsFinishedExternal();
                return true;
            }
            if (Thread.ThreadState == ThreadState.Running || Thread.ThreadState == ThreadState.WaitSleepJoin)
                return false;
            return true;
        }
    }
}
