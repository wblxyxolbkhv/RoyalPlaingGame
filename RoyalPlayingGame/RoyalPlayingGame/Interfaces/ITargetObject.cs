using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Interfaces
{
    public  interface ITargetObject
    {
        uint Health { get; set; }
        void GotDamaged(uint damage, Units.DamageType DType);
        bool ItsALIVE();
    }
}
