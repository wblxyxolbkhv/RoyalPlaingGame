using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame
{
    public  interface ITargetObject
    {
        uint Life { get; set; }
        void GetDamage(uint damage);
                
    }
}
