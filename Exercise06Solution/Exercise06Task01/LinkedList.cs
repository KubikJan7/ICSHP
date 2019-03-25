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
        private int elementCount;

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
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            ListElement current = first;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the chosen element
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Returns true if the element is present</returns>
        public bool Remove(T item)
        {
            IEnumerator e = GetEnumerator();
            while (e.MoveNext())
                if (item.Equals((T) e.Current))
                {

                }
            return false;

        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
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
