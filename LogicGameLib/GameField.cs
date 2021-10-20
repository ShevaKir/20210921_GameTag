using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGameLib
{
    public class GameField
    {
        private const int SIZE = 4;
        private const int DEFAUNT_COUNT = 500;
        private Cell[,] _cells;
        private Cell[,] _winningCell;
        private int _countCell = 1;
 

        public GameField(int size = SIZE)
        {
            _cells = new Cell[size, size];
            FillField();
        }

        public Cell this[int xIndex, int yIndex]
        {
            get
            {
                return _cells[xIndex, yIndex];
            }
            private set
            {
                _cells[xIndex, yIndex] = value;
            }
        }

        public int Size
        {
            get
            {
                return SIZE;
            }
        }


        private void FillField()
        {
            for (int i = 0; i < _cells.GetLength(0); i++)
            {
                for (int j = 0; j < _cells.GetLength(1); j++)
                {
                    _cells[i, j] = new Cell(_countCell);
                    _countCell++;
                }
            }
            _cells[SIZE - 1, SIZE - 1] = new Cell(0);

            _winningCell = new Cell[SIZE, SIZE];
            Array.Copy(_cells, _winningCell, _cells.Length);
        }

        public void Shuffle(int count = DEFAUNT_COUNT)
        {
            while (count > 0)
            {
                Action(RandomAction.RandomIndex(), RandomAction.RandomIndex());
                count--;
            }
        }

        public void Action(int i, int j)
        {
            for (int x = i - 1; x <= i + 1; x++)
            {
                for (int y = j - 1; y <= j + 1; y++)
                {
                    if (x >= 0 && x < _cells.GetLength(1)
                            && y >= 0 && y < _cells.GetLength(0)
                                && (x == i || y == j))
                    {
                        if (_cells[x, y].NumberCell == 0)
                        {
                            Swap(i, j, x, y);
                        }
                    }

                }
            }
        }

        private void Swap(int x1, int y1, int x2, int y2)
        {
            Cell cell = _cells[x2, y2];
            _cells[x2, y2] = _cells[x1, y1];
            _cells[x1, y1] = cell;
        }

        public bool IsWin()
        {
            bool result = false;

            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    if (_cells[i, j] == _winningCell[i, j])
                    {
                        result = true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return result;
        }
    }
}
