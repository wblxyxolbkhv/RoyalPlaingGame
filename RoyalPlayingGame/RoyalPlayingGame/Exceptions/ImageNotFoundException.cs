using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Exceptions
{
    public class ImageNotFoundException: Exception
    {
        public override string Message
        {
            get
            {
                return "Изображение для предмета отсутствует";
            }
        }
    }
}
