using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.Temp
{
    class MyLinkedListNode<T>
    {
        public T Data;

        public MyLinkedListNode<T> Prev;
        public MyLinkedListNode<T> Next;
    }

    class MyLinkedList<T>
    {
        public MyLinkedListNode<T> Head = null;
        public MyLinkedListNode<T> Tail = null;
        public int Count = 0;

        // O(1)
        public MyLinkedListNode<T> AddLast(T data)
        {
            MyLinkedListNode<T> newRoom = new MyLinkedListNode<T>();
            newRoom.Data = data;

            // 아직 방이 없다면 새로 추가한 방이 Head
            if (Head == null)
                Head = newRoom;

            // 기존 마지막방과 마지막 방 연결
            if (Tail != null)
            {
                Tail.Next = newRoom;
                newRoom.Prev = Tail;
            }

            // 새로 추가되는 방을 마지막 방으로 설정
            Tail = newRoom;

            Count++;

            return newRoom;
        }

        // O(1)
        public void Remove(MyLinkedListNode<T> room)
        {
            // 기존 첫번째 방 다음 방을 첫번째 방으로 설정
            if (Head == room)
                Head = Head.Next;

            // 기존 마지막 방 이전 방을 마지막 방으로 설정
            if (Tail == room)
                Tail = Tail.Prev;

            if (room.Prev != null)
                room.Prev.Next = room.Next;

            if (room.Next != null)
                room.Next.Prev = room.Prev;

            Count--;
        }
    }
}
