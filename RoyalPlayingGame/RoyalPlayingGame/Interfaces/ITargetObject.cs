using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Interfaces
{
    public  interface ITargetObject
    {
        int Health { get; set; }
        void GotDamaged(int damage, Units.DamageType DType);
    }
}
