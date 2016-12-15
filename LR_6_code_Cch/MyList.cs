using System;
using System.Collections.Generic;
using System.Collections;

namespace LR_6_code_Cch
{
    public class MyList<T> : ICollection<T>
    {
        public MyList()
        {
            count = 0;

            first_element = null;
            current_element = null;
        }

        public class Element<T>
        {
            public Element(T _value, int _index)
            {
                value = _value;
                index = _index;
            }

            public T value { get; set; }
            public int index { get; set; }
            public Element<T> next { get; set; }
        }

        public void Add(T item)
        {
            if (count == 0)
            {
                Element<T> element = new Element<T>(item, count);
                first_element = element;
                count++;
            }
            else
            {
                Element<T> element = new Element<T>(item, count);

                current_element = first_element;
                while (current_element.next != null)
                {
                    current_element = current_element.next;
                }

                current_element.next = element;
                count++;
            }
        }

        public void Clear()
        {
            current_element = first_element;
            while (current_element != null)
            {
                current_element = first_element.next;
                first_element = null;
                first_element = current_element;
            }

            count = 0;
        }

        public bool Contains(T item)
        {
            current_element = first_element;
            while (current_element != null)
            {
                if (current_element.value.Equals(item))
                    return true;
                else
                    current_element = current_element.next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            int _arrayIndex = arrayIndex;
            if (array.Length - arrayIndex >= count)
            {
                current_element = first_element;
                while (current_element != null)
                {
                    array[_arrayIndex] = current_element.value;
                    current_element = current_element.next;
                    _arrayIndex++;
                }
            }
            else
                throw new IndexOutOfRangeException("Not enough memory");
        }

        public bool Remove(T item)
        {
            if (first_element.value.Equals(item))
            {
                first_element = first_element.next;
                count--;
                return true;
            }
            else
                current_element = first_element.next;
            while (current_element != null)
            {
                if (current_element.value.Equals(item))
                {
                    Element<T> current_element2 = first_element;
                    while (current_element2 != null)
                    {
                        if (current_element2.next.value.Equals(item))
                        {
                            current_element2.next = current_element.next;
                            count--;
                            return true;
                        }
                        else
                            current_element2 = current_element2.next;
                    }
                }
                else
                    current_element = current_element.next;
            }
            return false;

        }

        /// / / / / / 
        public IEnumerator<T> GetEnumerator()
        {
            current_element = first_element;
            while (current_element != null)
            {
                yield return current_element.value;
                current_element = current_element.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        ///// / / / / / / / /

        public T this[int index]
        {
            get
            {
                current_element = first_element;
                for (int i = 0; i < index; i++)
                {
                    current_element = current_element.next;
                }
                return current_element.value;
            }

            set
            {
                current_element = first_element;
                for (int i = 0; i < index; i++)
                {
                    current_element = current_element.next;
                }
                current_element.value = value;
            }
        }

        private Element<T> first_element;
        //private Element last_element;

        private Element<T> current_element;

        //public T Current { get{return current_element.value; }}

        private int count;

        public int Count
        {
            get { return count; }
        }

        private bool isreadonly = false;

        public bool IsReadOnly
        {
            get { return isreadonly; }
        }
    }
}

