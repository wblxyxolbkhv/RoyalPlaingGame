using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Назначение: Базовый класс для стадий сценария
 * Автор: Никитенко А.В.
 */
namespace StartUpProject.Scripts
{
    public delegate bool ScriptFinish();
    public class ScriptStage
    {
        public ScriptStage(string name)
        {
            Name = name;
        }
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
        /// <summary>
        /// показывает, является ли стадия ждущей (то есть не выполняет никаких действий и не ограничивает движение)
        /// </summary>
        public bool isWaiting = false;
        public bool isFinished = false;
        // делегат для проверки конца
        public ScriptFinish IsFinishedExternal;
        public DateTime StartTime;
        public string Name { get; set; }

        public ScriptStage NextStage { get; set; }
    }
}
