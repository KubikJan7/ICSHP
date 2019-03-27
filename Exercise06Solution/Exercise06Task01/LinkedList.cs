using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Exercise05Task01
{
    public class LinkedList<T> : IEnumerable<T>, ICollection<T>, IList<T>
    {
        private ListElement first;
        private ListElement last;
        private ListElement current;
        private int elementCount;
        private int elementIndex;

        T IList<T>.this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsReadOnly => false;

        public bool IsFixedSize => false;

        public int Count => throw new NotImplementedException();

        public object SyncRoot => this;

        public bool IsSynchronized => false;

        /// <summary>
        /// Add element to the last position
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            ListElement newEl = new ListElement(item);
            if (elementCount == 0)
                newEl.Previous = null;
            else
                newEl.Previous = last;
            newEl.Next = null;
            last = newEl;
            elementCount++;
        }

        public void Clear()
        {
            elementCount = 0;
            first = null;
            last = null;
            current = null;
            elementIndex = 0;
        }

        public bool Contains(T item)
        {
            IEnumerator e = GetEnumerator();
            while (e.MoveNext())
                if (item.Equals((T)e.Current))
                    return true;

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            IEnumerator e = GetEnumerator();
            while (e.MoveNext())
            {
                T data = (T)e.Current;
                if (elementIndex == arrayIndex)
                {
                    array[arrayIndex] = (T) e.Current;
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            ListElement current = first;
            elementIndex = 0;
            while (current != null)
            {
                this.current = current;
                yield return current.Data;
                current = current.Next;
                elementIndex++;
            }
        }

        public int IndexOf(T item)
        {
            IEnumerator e = GetEnumerator();
            while(e.MoveNext())
            {
                if (item.Equals(e.Current))
                    return elementIndex;
            }
            return 0;
        }
        /// <summary>
        /// Insert new element before element with given index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, T item)
        {
            //TODO insert as first
            //TODO insert as last
            IEnumerator e = GetEnumerator();
            while (e.MoveNext())
            {
                if(index == elementIndex)
                {
                    ListElement newEl = new ListElement(item,current,current.Previous);
                    current = newEl;

                }
            }
        }

        /// <summary>
        /// Removes element with data in parameter
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Returns true if the element is present</returns>
        public bool Remove(T item)
        {
            IEnumerator e = GetEnumerator();
            while (e.MoveNext())
            {
                T data = (T)e.Current;
                if (item.Equals((T)e.Current))
                {

                }
            }
            return false;

        }
        /// <summary>
        /// Removes element at the given index
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            // TODO - Remove first
            // TODO - Remove last
            // TODO - invalid index
            IEnumerator e = GetEnumerator();
            while (e.MoveNext())
            {
                if(index == elementIndex)
                {
                    ListElement el = current.Next;
                    current = current.Previous;
                    current.Next = el;
                    elementIndex--;
                }
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private class ListElement
        {
            public T Data { set; get; }
            public ListElement Next { set; get; }
            public ListElement Previous { set; get; }

            public ListElement(T data, ListElement next, ListElement previous)
            {
                Data = data;
                Next = next;
                Previous = previous;
            }

            public ListElement(ListElement next, ListElement previous)
            {
                Next = next;
                Previous = previous;
            }

            public ListElement(T data)
            {
                Data = data;
            }
        }
    }
}
