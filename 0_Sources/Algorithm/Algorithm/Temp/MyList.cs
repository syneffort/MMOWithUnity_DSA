using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.Temp
{
    class MyList<T>
    {
        const int DEFAULT_SIZE = 1;
        const int GROWTH_FACTOR = 2;

        T[] _data = new T[DEFAULT_SIZE];

        public int Count = 0; // 사용중 데이터 수
        public int Capacity { get { return _data.Length; } } // 예약된 데이터 개수

        // O(1) : 예외케이스로 Capacity 증가는 조건문이 활성화 되어야 하기 때문에 횟수가 적을것으로 간주하여 무시함
        public void Add(T item)
        {
            // 1. 공간이 충분한지 확인
            if (Count >= Capacity)
            {
                // 공간을 늘려 확보
                T[] newArray = new T[Count * GROWTH_FACTOR];
                for (int i = 0; i < Count; i++)
                    newArray[i] = _data[i];

                _data = newArray;
            }

            // 2. 공간에 데이터 삽입
            _data[Count] = item;
            Count++;
        }

        // O(1)
        public T this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        // O(N)
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
                _data[i] = _data[i + 1];

            _data[Count - 1] = default(T);
            Count--;
        }
    }
}
