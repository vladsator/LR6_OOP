using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace LR_6_code_Cch
{
    class MyList<T>
    {
        private T[] _items;
        private int _size;
        private const int DefaultSize = 1;
        private static readonly T[] EmptyArray = new T[0];

        public MyList()
        {
            _items = new T[DefaultSize];
        }

        public MyList(int length)
        {
            _items = new T[length];
        }

        public MyList(IEnumerable<T> collection)
        {
            var c = collection as ICollection<T>;
            if (c != null)
            {
                int count = c.Count;
                if (count == 0)
                {
                    _items = EmptyArray;
                }
                else
                {
                    _items = new T[count];
                    c.CopyTo(_items, 0);
                    _size = count;
                }
            }
            else
            {
                _size = 0;
                _items = EmptyArray;

                using (IEnumerator<T> en = collection.GetEnumerator())
                {
                    while (en.MoveNext())
                    {
                        Add(en.Current);
                    }
                }
            }
        }

        public void Add(T item)
        {
            if (_size == _items.Length)
            {
                var newItems = new T[_size * 2];
                Array.Copy(_items, 0, newItems, 0, _size);
                _items = newItems;
            }
            _items[_size++] = item;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            _size--;
            if (index < _size)
            {
                Array.Copy(_items, index + 1, _items, index, _size - index);
            }
            _items[_size] = default(T);
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(_items, item, 0, _size);
        }

        public void Clear()
        {
            if (_size > 0)
            {
                Array.Clear(_items, 0, _size);
                _size = 0;
            }
        }

        public int Count
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);
                return _size;
            }
        }


        // Sorts the elements in this list.  Uses the default comparer and 
        // Array.Sort.
        public void Sort()
        {
            Sort(0, Count, null);
        }

        public void Sort(int index, int count, IComparer<T> comparer)
        {
            Array.Sort(_items, index, count, comparer);
        }


        public T[] ToArray()
        {
            var array = new T[_size];
            Array.Copy(_items, 0, array, 0, _size);
            return array;
        }
    }
}