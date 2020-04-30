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
                { 0, 1, 0, 1, 0, 0 },
                { 1, 0, 1, 1, 0, 0 },
                { 0, 1, 0, 0, 0, 0 },
                { 1, 1, 0, 0, 1, 0 },
                { 0, 0, 0, 1, 0, 1 },
                { 0, 0, 0, 0, 1, 0 },
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
        }
    }
}
