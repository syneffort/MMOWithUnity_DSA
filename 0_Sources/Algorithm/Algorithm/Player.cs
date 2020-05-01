using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Algorithm
{
    class Pos
    {
        public Pos(int y, int x)
        {
            Y = y;
            X = x;
        }

        public int Y;
        public int X;
    }

    class Player
    {
        public int PosY { get; private set; }
        public int PosX { get; private set; }
        
        Random _rand = new Random();
        Board _board;

        enum Dir
        {
            Up = 0,
            Left,
            Down,
            Right
        }

        int _dir = (int)Dir.Up;
        List<Pos> _points = new List<Pos>();

        public void Initialize(int posY, int posX, Board board)
        {
            PosY = posY;
            PosX = posX;

            _board = board;

            //RightHand();
            BFS();
        }

        void BFS()
        {
            int[] deltaY = new int[] { -1, 0, 1, 0 };
            int[] deltaX = new int[] { 0, -1, 0, 1 };

            bool[,] found = new bool[_board.Size, _board.Size];
            Pos[,] parent = new Pos[_board.Size, _board.Size];

            Queue<Pos> q = new Queue<Pos>();
            q.Enqueue(new Pos(PosY, PosX));
            found[PosY, PosX] = true;
            parent[PosY, PosX] = new Pos(PosY, PosX);

            while (q.Count > 0)
            {
                Pos pos = q.Dequeue();
                int nowY = pos.Y;
                int nowX = pos.X;

                for (int i = 0; i < 4; i++)
                {
                    int nextY = nowY + deltaY[i];
                    int nextX = nowX + deltaX[i];

                    if (nextY < 0 || nextY >= _board.Size || nextX < 0 || nextX >= _board.Size)
                        continue;

                    if (_board.Tile[nextY, nextX] == Board.TileType.Wall)
                        continue;

                    if (found[nextY, nextX])
                        continue;

                    q.Enqueue(new Pos(nextY, nextX));
                    found[nextY, nextX] = true;
                    parent[nextY, nextX] = new Pos(nowY, nowX);
                }
            }

            int y = _board.DestY;
            int x = _board.DestX;
            while (parent[y, x].Y != y || parent[y, x].X != x)
            {
                _points.Add(new Pos(y, x));
                Pos pos = parent[y, x];
                y = pos.Y;
                x = pos.X;
            }

            _points.Add(new Pos(y, x));
            _points.Reverse();
        }

        void RightHand()
        {
            // 현재 바라보고 있는 방향으로, 좌표 변화를 나타냄
            int[] frontY = new int[] { -1, 0, 1, 0 };
            int[] frontX = new int[] { 0, -1, 0, 1 };
            int[] rightY = new int[] { 0, -1, 0, 1 };
            int[] rightX = new int[] { 1, 0, -1, 0 };

            _points.Add(new Pos(PosY, PosX));
            while (PosY != _board.DestY || PosX != _board.DestX)
            {
                // 1. 현재 바라보는 방향 기준으로 오른쪽으로 갈 수 있는지 확인
                if (_board.Tile[PosY + rightY[_dir], PosX + rightX[_dir]] == Board.TileType.Empty)
                {
                    // 오른쪽 방향으로 90도 회전
                    _dir = (_dir - 1 + 4) % 4;
                    // 앞으로 전진
                    PosY = PosY + frontY[_dir];
                    PosX = PosX + frontX[_dir];

                    _points.Add(new Pos(PosY, PosX));
                }
                // 2. 현재 바라보는 방향으로 전진할 수 있는지 확인
                else if (_board.Tile[PosY + frontY[_dir], PosX + frontX[_dir]] == Board.TileType.Empty)
                {
                    // 앞으로 전진
                    PosY = PosY + frontY[_dir];
                    PosX = PosX + frontX[_dir];

                    _points.Add(new Pos(PosY, PosX));
                }
                else
                {
                    // 왼쪽방향으로 90도 회전
                    _dir = (_dir + 1 + 4) % 4;
                }
            }
        }

        const int MOVE_TICK = 10;
        int _sumTick = 0;
        int _lastIndex = 0;
        public void Update(int deltaTick)
        {
            if (_lastIndex >= _points.Count)
                return;

            _sumTick += deltaTick;
            if (_sumTick < MOVE_TICK)
                return;

            _sumTick = 0;

            PosY = _points[_lastIndex].Y;
            PosX = _points[_lastIndex].X;
            _lastIndex++;

            #region Random Move Test
            //int randValue = _rand.Next(0, 5);
            //switch (randValue)
            //{
            //    case 0: // 상
            //        if (PosY - 1 >= 0 && _board.Tile[PosY - 1, PosX] == Board.TileType.Empty)
            //            PosY = PosY - 1;
            //        break;
            //    case 1: // 하
            //        if (PosY + 1 < _board.Size && _board.Tile[PosY + 1, PosX] == Board.TileType.Empty)
            //            PosY = PosY + 1;
            //        break;
            //    case 2: // 좌
            //        if (PosX -1 >= 0 && _board.Tile[PosY, PosX - 1] == Board.TileType.Empty)
            //            PosX = PosX - 1;
            //        break;
            //    case 3: // 우
            //        if (PosX + 1 < _board.Size && _board.Tile[PosY, PosX + 1] == Board.TileType.Empty)
            //            PosX = PosX + 1;
            //        break;
            //}
            #endregion
        }
    }
}
