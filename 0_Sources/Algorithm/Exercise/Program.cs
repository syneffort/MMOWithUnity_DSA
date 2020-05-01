using System;
using System.Collections.Generic;

namespace Exercise
{
    class Program
    {
        class Graph
        {
            int[,] adj = new int[6, 6]
            {
                { -1, 15, -1, 35, -1, -1 },
                { 15, -1, 05, 10, -1, -1 },
                { -1, 05, -1, -1, -1, -1 },
                { 35, 10, -1, -1, 05, -1 },
                { -1, -1, -1, 05, -1, 05 },
                { -1, -1, -1, -1, 05, -1 },
            };

            List<int>[] adj2 = new List<int>[]
            {
                new List<int>() { 1, 3 },
                new List<int>() { 0, 2, 3},
                new List<int>() { 1 },
                new List<int>() { 0, 1, 4 },
                new List<int>() { 3, 5 },
                new List<int>() { 4, },
            };

            #region DFS
            bool[] visited = new bool[6];
            // 1) now 방문함
            // 2) now와 연결된 버텍스들을 하나씩 확인해서 아직 미방문 상태라면 방문함
            public void DFS(int now)
            {
                Console.WriteLine(now);
                visited[now] = true;

                for (int next = 0; next < 6; next++)
                {
                    if (adj[now, next] == 0) // 연결되지 않았으면 컨티뉴
                        continue;

                    if (visited[next]) // 이미 방문했다면 컨티뉴
                        continue;

                    DFS(next);
                }
            }

            public void DFS2(int now)
            {
                Console.WriteLine(now);
                visited[now] = true;

                foreach (int next in adj2[now]) // 연결된 것만 확인
                {
                    if (visited[next]) // 이미 방문했다면 컨티뉴
                        continue;

                    DFS2(next);
                }
            }

            public void SearchAll()
            {
                visited = new bool[6];
                for (int now = 0; now < 6; now++)
                {
                    if (visited[now] == false)
                        DFS(now);
                }
            }
            #endregion

            #region BFS
            public void BFS(int start)
            {
                bool[] found = new bool[6];
                int[] parent = new int[6];
                int[] distance = new int[6];

                Queue<int> q = new Queue<int>();
                q.Enqueue(start);
                found[start] = true;
                parent[start] = start;
                distance[start] = 0;

                while (q.Count > 0)
                {
                    int now = q.Dequeue();
                    Console.WriteLine(now);

                    for (int next = 0; next < 6; next++)
                    {
                        if (adj[now, next] == 0)
                            continue;


                        if (found[next])
                            continue;

                        q.Enqueue(next);
                        found[next] = true;
                        parent[next] = now;
                        distance[next] = distance[now] + 1;
                    }
                }
            }
            #endregion

            public void Dijikstra(int start)
            {
                bool[] visited = new bool[6];
                int[] distance = new int[6];
                int[] parent = new int[6];
                Array.Fill(distance, int.MaxValue);

                distance[start] = 0;
                parent[start] = start;
                while (true)
                {
                    // 가장 좋은(가까운) 후보 선정
                    int closest = int.MaxValue;
                    int now = -1;
                    for (int i = 0; i < 6; i++)
                    {
                        // 기존 방문한 버텍스 컨티뉴
                        if (visited[i])
                            continue;
                        
                        // 아직 발견(예약)되지 않거나, 기존 후보보다 멀다면 컨티뉴
                        if (distance[i] == int.MaxValue || distance[i] >= closest)
                            continue;

                        closest = distance[i];
                        now = i;
                    }

                    // 다음 후보가 없으면 종료
                    if (now == -1)
                        break;

                    // 가장 좋은 후보 방문
                    visited[now] = true;

                    // 후보와 인접한 버텍스 조사 후 최단거리 갱신
                    for (int next = 0; next < 6; next++)
                    {
                        // 연결되지 않은 버텍스 컨티뉴
                        if (adj[now, next] == -1)
                            continue;

                        // 이미 방문한 버텍스 컨티뉴
                        if (visited[next])
                            continue;

                        // 새로 발견된 버텍스 까지의 거리 계산 후 갱신
                        int nextDist = distance[now] + adj[now, next];
                        if (nextDist < distance[next])
                        {
                            distance[next] = nextDist;
                            parent[next] = now;
                        }
                    }
                }
            }
        }


        // 스택 : LIFO (후입선출 : Last In First Out)
        // 큐 : FIFO (선입선출 : First In First Out)

        static void Main(string[] args)
        {
            #region Stack and Queue test
            //Stack<int> stack = new Stack<int>();

            //stack.Push(101);
            //stack.Push(102);
            //stack.Push(103);
            //stack.Push(104);
            //stack.Push(105);

            //int data1 = stack.Pop();
            //int data2 = stack.Peek();

            //Queue<int> queue = new Queue<int>();

            //queue.Enqueue(101);
            //queue.Enqueue(102);
            //queue.Enqueue(103);
            //queue.Enqueue(104);
            //queue.Enqueue(105);

            //int data3 = queue.Dequeue();
            //int data4 = queue.Peek();

            //LinkedList<int> list = new LinkedList<int>();

            //list.AddLast(101);
            //list.AddLast(102);
            //list.AddLast(103);
            //list.AddLast(104);
            //list.AddLast(105);

            //// FIFO
            //int value1 = list.First.Value;
            //list.RemoveFirst();

            //// LIFO
            //int value2 = list.Last.Value;
            //list.RemoveLast();
            #endregion

            // DFS (Depth First Search : 깊이 우선 탐색)
            // BFS (Breadth First Search : 너비 우선 탐색)

            Graph graph = new Graph();
            //graph.SearchAll();
            graph.Dijikstra(0);
        }
    }
}
