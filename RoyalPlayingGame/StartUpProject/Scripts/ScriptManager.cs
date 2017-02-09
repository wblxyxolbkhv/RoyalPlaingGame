using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartUpProject.GlobalGameComponents;

namespace StartUpProject.Scripts
{
    public static class ScriptManager
    {
        public static ScriptStage CurrentScript { get; set; }
        public static ScriptStage RootScript { get; set; }
        public static void Init()
        {
            // строим дерево скриптов
            RootScript = new ScriptStage();
            RootScript.isWaiting = true;
                ScriptStage s = new InfoStage(5000, "ТЫ УНИЧТОЖИЛ ВСЕ ЖИВОЕ В ЭТОМ МАЛЕНЬКОМ МИРЕ! ТЫ ДОВОЛЕН?");
                RootScript.NextStage = s;
                    ScriptStage lastStage = new ScriptStage();
                    lastStage.isWaiting = true;
                    lastStage.IsFinishedExternal += () =>
                    {
                        return false;
                    };
                    s.NextStage = lastStage;




            CurrentScript = RootScript;
        }
        public static void OnRefresh(object sender, EventArgs e)
        {
            if (CurrentScript == null)
                return;
            if (CurrentScript.IsFinished())
                CurrentScript = CurrentScript.NextStage;
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
