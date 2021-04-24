using System;
using System.Collections.Generic;
using System.Text;

namespace Task5
{
    class MyStack<T>
    {
        private List<T> _list;

        public MyStack()
        {
            _list = new List<T>();
        }

        public void Push(T a)
        {
            _list.Add(a);
        }

        public T Pop()
        {
            T lastItem = _list[_list.Count - 1];
            _list.RemoveAt(_list.Count - 1);
            return lastItem;
        }

        public T Top()
        {
            return _list[_list.Count - 1];
        }

        public int Count()
        {
            return _list.Count;
        }

    }
}
