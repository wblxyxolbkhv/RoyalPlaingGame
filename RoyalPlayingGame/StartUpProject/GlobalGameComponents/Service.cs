using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpProject.GlobalGameComponents
{
    public static class Service
    {
        public static bool Between(int start, int end, double number)
        {
            if (number > start && number <= end)
                return true;
            return false;
        }
    }
}
