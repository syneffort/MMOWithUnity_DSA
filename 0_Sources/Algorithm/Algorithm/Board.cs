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
            if (size % 2 == 0)
                return;

            _size = size;
            _tile = new TileType[_size, _size];

            //GenerateByBinaryTree();
            GenerateBySideWinder();
        }

        void GenerateByBinaryTree()
        {

            // 길을 막는 작업
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        _tile[y, x] = TileType.Wall;
                    else
                        _tile[y, x] = TileType.Empty;
                }
            }

            // 랜덤으로 우측 혹은 아래로 길을 열어주는 작업
            // 바이너리 트리 알고리즘
            Random rand = new Random();
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;

                    if (y == _size - 2 && x == _size - 2)
                        continue;

                    if (y == _size - 2)
                    {
                        _tile[y, x + 1] = TileType.Empty;
                        continue;
                    }

                    if (x == _size - 2)
                    {
                        _tile[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    if (rand.Next(0, 2) == 0)
                    {
                        _tile[y, x + 1] = TileType.Empty;
                    }
                    else
                    {
                        _tile[y + 1, x] = TileType.Empty;
                    }

                }
            }
        }

        void GenerateBySideWinder()
        {
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        _tile[y, x] = TileType.Wall;
                    else
                        _tile[y, x] = TileType.Empty;
                }
            }

            Random rand = new Random();
            for (int y = 0; y < _size; y++)
            {
                int count = 1;
                for (int x = 0; x < _size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;

                    if (y == _size - 2 && x == _size - 2)
                        continue;

                    if (y == _size - 2)
                    {
                        _tile[y, x + 1] = TileType.Empty;
                        continue;
                    }

                    if (x == _size - 2)
                    {
                        _tile[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    if (rand.Next(0, 2) == 0)
                    {
                        _tile[y, x + 1] = TileType.Empty;
                        count++;
                    }
                    else
                    {
                        int randomIndex = rand.Next(0, count);
                        _tile[y + 1, x - randomIndex * 2] = TileType.Empty;
                        count = 1;
                    }
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
                    return ConsoleColor.Black;
                case TileType.Wall:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.Black;
            }
        }
    }
}
