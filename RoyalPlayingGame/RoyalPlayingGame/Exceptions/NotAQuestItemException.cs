using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Exceptions
{
    public class NotAQuestItemException:Exception
    {
        public override string Message
        {
            get
            {
                return "Невозможно добавить предмет, не являющийся квестовым.";
            }
        }
    }
}
