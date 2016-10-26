using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Exceptions
{
    public class LoadDialogException: System.Exception
    {
        public override string Message
        {
            get
            {
                return "Ошибка при загрузке диалога из XML-файла";
            }
        }
    }
}
