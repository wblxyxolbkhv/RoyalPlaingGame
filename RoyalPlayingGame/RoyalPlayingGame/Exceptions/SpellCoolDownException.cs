using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Exceptions
{
    public class SpellCoolDownException:Exception
    {
        public override string Message
        {
            get
            {
                return "заклинание еще не готово";
            }
        }
    }
}
