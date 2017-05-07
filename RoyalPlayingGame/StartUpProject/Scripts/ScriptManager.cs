using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartUpProject.GlobalGameComponents;
using System.Threading;

namespace StartUpProject.Scripts
{
    public static class ScriptManager
    {
        //внешние делегаты для проверки условий конца
        private static Dictionary<string, ScriptFinish> ExternalFinishedDelegates = new Dictionary<string, ScriptFinish>();
        //внешние делегаты для скриптов экшна
        private static Dictionary<string, ThreadStart> ExternalActionDelegates = new Dictionary<string, ThreadStart>();
        public static ScriptStage CurrentScript { get; set; }
        public static ScriptStage RootScript { get; set; }
        public static void Init()
        {
            // строим дерево скриптов
            RootScript = new ScriptStage("root");
            RootScript.isWaiting = true;
            RealTimeScriptStage stage = new RealTimeScriptStage("fight_stage");
            RootScript.NextStage = stage;
            ScriptStage last = new ScriptStage("last");
            last.isWaiting = true;
            last.IsFinishedExternal += () =>
            {
                return false;
            };
            stage.NextStage = last;




            CurrentScript = RootScript;
        }
        public static void AddFinishedDelegate(string name, ScriptFinish Delegate)
        {
            ExternalFinishedDelegates.Add(name, Delegate);
        }
        public static void AddActionDelegate(string name, ThreadStart Delegate)
        {
            ExternalActionDelegates.Add(name, Delegate);
        }
        public static void OnRefresh(object sender, EventArgs e)
        {
            if (CurrentScript == null)
                return;
            if (CurrentScript.IsFinished())
            {
                CurrentScript = CurrentScript.NextStage;
                if (CurrentScript == null)
                    return;
                CurrentScript.StartTime = DateTime.Now;
                RealTimeScriptStage r;
                if ((r = CurrentScript as RealTimeScriptStage)!=null)
                {
                    if (ExternalActionDelegates.ContainsKey(r.Name))
                    {
                        r.RealTimeAction += ExternalActionDelegates[r.Name];
                        Thread t = new Thread(r.RealTimeAction);
                        r.Thread = t;
                        t.Start();
                    }
                }
                if (ExternalFinishedDelegates.ContainsKey(CurrentScript.Name))
                    CurrentScript.IsFinishedExternal += ExternalFinishedDelegates[CurrentScript.Name];
            }
        }
        public static string GetInfoString()
        {
            InfoStage stage = CurrentScript as InfoStage;
            if (stage!=null && !stage.IsFinished())
            {
                return stage.InformationString;
            }
            return null;
        }
    }
}
