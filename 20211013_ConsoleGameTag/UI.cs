using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicGameLib;

namespace _20211013_ConsoleGameTag
{
    class UI
    {
        public static void ShowGame(GameField game)
        {
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < game.Size; i++)
            {
                for (int j = 0; j < game.Size; j++)
                {
                    Console.Write("{0}\t", game[i, j].NumberCell);
                }
                Console.WriteLine();
            }
        }


        public static Coordinate GetDirection()
        {
            Coordinate coordinate = new Coordinate();
            ConsoleKey key;

            key = Console.ReadKey(true).Key;
            // TODO: енам direction, and coordinate to BL
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    coordinate.x = 1;
                    coordinate.y = 0;
                    break;
                case ConsoleKey.DownArrow:
                    coordinate.x = -1;
                    coordinate.y = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    coordinate.x = 0;
                    coordinate.y = 1;
                    break;
                case ConsoleKey.RightArrow:
                    coordinate.x = 0;
                    coordinate.y = -1;
                    break;
            }

            return coordinate;
        }

        public static void ShowWin()
        {
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("Победа");
        }
    }
}
