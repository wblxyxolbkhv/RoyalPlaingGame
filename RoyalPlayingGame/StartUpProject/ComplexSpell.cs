using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Spell;

namespace StartUpProject
{
    public class ComplexSpell : ComplexObject
    {
        public ComplexSpell()
        {
            IsActive = true;
            DamagedUnits = new List<ComplexUnit>();
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
