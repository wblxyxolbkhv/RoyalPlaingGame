using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplePhysicalEngine.NonPhysicalComponents;
/* Назначение: Слушатель столкновений с триггерами
 * слушает все столкновения с триггерами и уведомляет об этом нужные классы
 * Автор: Никитенко А.В.
 */
namespace SimplePhysicalEngine
{
    public delegate void TriggerCollisionHandler(string TriggerID);
    public static class TriggersColiisionsListener
    {
        public static event TriggerCollisionHandler TriggerCollisionDetected;
        public static void OnTriggerCollisionDetected(RealObject o1, RealObject o2)
        {
            if (o1.IsTrigger && o2.ID == "player")
                TriggerCollisionDetected?.Invoke(o1.ID);
            if (o2.IsTrigger && o1.ID == "player")
                TriggerCollisionDetected?.Invoke(o2.ID);
        }
        
    }
}
