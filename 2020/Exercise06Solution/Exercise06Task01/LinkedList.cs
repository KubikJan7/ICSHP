using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Exercise06Task01
{
    public class LinkedList<T> : IEnumerable<T>, ICollection<T>, IList<T>
    {
        private ListElement first;
        private ListElement last;
        private ListElement current;
        private int elementIndex;

        T IList<T>.this[int index] { get => GetDataOf(index); set => throw new NotImplementedException(); }

        public bool IsReadOnly => false;

        public bool IsFixedSize => false;

        public int Count { set; get; }

        public object SyncRoot => this;

        public bool IsSynchronized => false;

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public LinkedList()
        {
            Clear();
        }

        /// <summary>
        /// Add element to the last position
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            ListElement newEl = new ListElement(item);
            if (IsEmpty())
            {
                first = newEl;
                last = first;
            }
            else
            {
                newEl.Previous = last;
                last.Next = newEl;
            }
            last = newEl;
            Count++;
        }

        public void Clear()
        {
            Count = 0;
            first = null;
            last = null;
            current = null;
            elementIndex = 0;
        }

        public bool Contains(T item)
        {
            IEnumerator e = GetEnumerator();
            while (e.MoveNext())
                if (item.Equals(e.Current))
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
                    array[arrayIndex] = (T)e.Current;
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
        /// <summary>
        /// Gets data of element with given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>returns data type T</returns>
        public T GetDataOf(int index)
        {
            IEnumerator e = GetEnumerator();
            while (e.MoveNext())
            {
                if (index.Equals(elementIndex))
                    return (T)e.Current;
            }
            try
            {
                throw new System.ArgumentException("This list does not contain element with given index");
            }
            catch (ArgumentException) { return default(T); }
        }

        public int IndexOf(T item)
        {
            IEnumerator e = GetEnumerator();
            while (e.MoveNext())
            {
                if (item.Equals(e.Current))
                    return elementIndex;
            }
            try
            {
                throw new System.ArgumentException("This list does not contain element with given data");
            }
            catch (ArgumentException) { return -1; }

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
                if (index == elementIndex)
                {
                    ListElement newEl = new ListElement(item, current, current.Previous);
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
            if (IsEmpty())
                throw new ArgumentNullException("The list does not contain any elements");
            IEnumerator e = GetEnumerator();
            while (e.MoveNext())
            {
                if (item.Equals((T)e.Current))
                {
                    DeleteElement();
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
                if (index == elementIndex)
                {
                    DeleteElement();
                }
            }
        }

        private void DeleteElement()
        {
            if (current.Equals(first))
            {

                if (Count == 1)
                {
                    Clear();
                    return;
                }

                first = first.Next;
                first.Previous = null;
                current = first;

            }
            else if (current.Equals(last))
            {
                if (Count == 1)
                {
                    Clear();
                    return;
                }

                last = last.Previous;
                last.Next = null;
                current = last;
                elementIndex--;
            }
            else
            {
                ListElement el = current.Previous;
                el.Next = current.Next;
                current = current.Next;
                current.Previous = el;
            }
            Count--;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
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
