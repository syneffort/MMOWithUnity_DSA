using System;
using System.Collections.Generic;

namespace Exercise
{
    class Program
    {
        // 스택 : LIFO (후입선출 : Last In First Out)
        // 큐 : FIFO (선입선출 : First In First Out)

        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(101);
            stack.Push(102);
            stack.Push(103);
            stack.Push(104);
            stack.Push(105);

            int data1 = stack.Pop();
            int data2 = stack.Peek();

            Queue<int> queue = new Queue<int>();

            queue.Enqueue(101);
            queue.Enqueue(102);
            queue.Enqueue(103);
            queue.Enqueue(104);
            queue.Enqueue(105);

            int data3 = queue.Dequeue();
            int data4 = queue.Peek();

            LinkedList<int> list = new LinkedList<int>();

            list.AddLast(101);
            list.AddLast(102);
            list.AddLast(103);
            list.AddLast(104);
            list.AddLast(105);

            // FIFO
            int value1 = list.First.Value;
            list.RemoveFirst();

            // LIFO
            int value2 = list.Last.Value;
            list.RemoveLast();
        }
    }
}
