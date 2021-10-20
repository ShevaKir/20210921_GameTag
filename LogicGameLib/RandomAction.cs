using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGameLib
{
    class RandomAction
    {
        static Random rnd = new Random();

        public static int RandomIndex()
        {
            return rnd.Next(0, 4);
        }
    }
}
