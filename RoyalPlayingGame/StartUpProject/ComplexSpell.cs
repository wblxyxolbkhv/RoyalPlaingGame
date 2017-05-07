using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Spell;
using SimplePhysicalEngine.NonPhysicalComponents;

namespace StartUpProject
{
    public class ComplexSpell : ComplexObject
    {
        public ComplexSpell(List<RealObject> CollisionDomain, RealObject caster)
        {
            IsActive = true;
            DamagedUnits = new List<ComplexUnit>();
            RealObject = new RealObject(CollisionDomain);
            RealObject.AddReservedObject(caster);
            // TODO: подчистить за собой хвосты
            if (caster != null)
                caster.AddReservedObject(RealObject);
        }
        /// <summary>
        /// конструктор для спеллов, которые никого не задевают
        /// </summary>
        public ComplexSpell()
        {
            IsActive = true;
            DamagedUnits = new List<ComplexUnit>();
            RealObject = new RealObject();
        }
        public NegativeSpell Spell { get; set; }
        public double Damage { get; set; }
        public void ManualyDeath()
        {
            if (IsActive)
            {
                IsActive = false;
                RealObject.Position.Y -= 30;
                RealObject.Width = 0;
                RealObject.Height = 0;
                OnUnitDeath();
            }
        }
        public List<ComplexUnit> DamagedUnits { get; set; }

    }
}
