using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplePhysicalEngine.NonPhysicalComponents;

namespace SimplePhysicalEngine
{
    public delegate void TriggerCollisionHandler(int TriggerID);
    public static class TriggersColiisionsListener
    {
        public static event TriggerCollisionHandler TriggerCollisionDetected;
        public static void OnTriggerCollisionDetected(RealObject o1, RealObject o2)
        {
            if (o1.IsTrigger && o2.ID == 0)
                TriggerCollisionDetected?.Invoke(o1.ID);
            if (o2.IsTrigger && o1.ID == 0)
                TriggerCollisionDetected?.Invoke(o2.ID);
        }
    }
}
