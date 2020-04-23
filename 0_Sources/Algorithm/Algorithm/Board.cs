using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Algorithm.Temp;

namespace Algorithm
{
    class Board
    {
        public int[] _data = new int[25]; // 배열
        //public List<int> _data2 = new List<int>(); // 동적 배열
        public MyList<int> _data2 = new MyList<int>(); // 동적 배열 (자작)
        //public LinkedList<int> _data3 = new LinkedList<int>(); // 이중 연결 동적 배열
        public MyLinkedList<int> _data3 = new MyLinkedList<int>(); // 이중 연결 동적 배열 (자작)

        public void Initialize()
        {
            #region List

            //_data2.Add(101);
            //_data2.Add(102);
            //_data2.Add(103);
            //_data2.Add(104);
            //_data2.Add(105);

            //int temp = _data2[2];

            //_data2.RemoveAt(2);

            #endregion

            #region LinkedList

            _data3.AddLast(101);
            _data3.AddLast(102);
            MyLinkedListNode<int> node = _data3.AddLast(103);
            _data3.AddLast(104);
            _data3.AddLast(105);

            _data3.Remove(node);

            #endregion


        }

    }
}
