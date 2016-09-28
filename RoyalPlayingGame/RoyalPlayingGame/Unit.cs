using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame
{
    public class Unit : ITargetObject
    {
        public uint Life { get; set; }
        public uint Strength { get; protected set; }
        public uint Agility { get; protected set; }
        public uint Intelligence { get; protected set; }
        public List<Effect> Effects { get; protected set; }
        public uint Level { get; protected set; }
        public void GetDamage(uint damage)
        {

        }
        public void Attack(ITargetObject tarobject)
        {

        }
        public void AddEffect(Effect effect)
        { 

        }

        

        
        

    }
}
