using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20210921_GameTag
{
    class Cell
    {
        private int _numberCell;

        public Cell(int number)
        {
            _numberCell = number;
        }

        public int NumberCell
        {
            get
            {
                return _numberCell;
            }
            set
            {
                _numberCell = value;
            }
        }

    }
}
