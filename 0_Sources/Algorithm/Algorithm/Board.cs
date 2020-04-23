using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Algorithm.Temp;

namespace Algorithm
{
    class Board
    {
        #region Tile Type Enum
        public enum TileType
        {
            Empty = 0,
            Wall,
        }
        #endregion

        public int _size;
        public TileType[,] _tile;
        const char CIRCLE = '\u25cf';

        public void Initialize(int size)
        {
            _size = size;
            _tile = new TileType[_size, _size];

            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    if (x == 0 || x == _size - 1 || y == 0 || y == size - 1)
                        _tile[y, x] = TileType.Wall;
                    else
                        _tile[y, x] = TileType.Empty;
                }
            }
        }

        public void Render()
        {
            ConsoleColor prevColor = Console.ForegroundColor;

            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    Console.ForegroundColor = GetTileColor(_tile[x, y]);
                    Console.Write(CIRCLE);
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = prevColor;
        }

        ConsoleColor GetTileColor(TileType type)
        {
            switch (type)
            {
                case TileType.Empty:
                    return ConsoleColor.Green;
                case TileType.Wall:
                    return ConsoleColor.Gray;
                default:
                    return ConsoleColor.Green;
            }
        }
    }
}
