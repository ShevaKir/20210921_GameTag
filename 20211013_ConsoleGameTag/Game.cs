using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicGameLib;

namespace _20211013_ConsoleGameTag
{
    class Game
    {
        private const int SIZE = 4;
        private GameField _game;

        public Game(int size = SIZE)
        {
            _game = new GameField(size);
            _game.Shuffle(20);
        }

        public void Run()
        {
            UI.ShowGame(_game);

            do
            {
                for (int i = 0; i < _game.Size; i++)
                {
                    for (int j = 0; j < _game.Size; j++)
                    {
                        if(_game[i,j].NumberCell == 0)
                        {
                            Coordinate coordinate = UI.GetDirection();
                            _game.Action(i + coordinate.x, j + coordinate.y);
                            UI.ShowGame(_game);
                            break;
                        }
                    }
                }

            } while (!_game.IsWin());

            UI.ShowWin();
        }

    }
}
