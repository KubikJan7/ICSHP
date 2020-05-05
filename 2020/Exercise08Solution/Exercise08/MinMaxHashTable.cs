using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise08
{
    public class MinMaxHashTable<K, V> where K : IComparable
    {
        private Element[] elements;
        private K minimum { get; set; }
        private K maximum { get; set; }
        public int Count { get; set; }
        private int capacity;

        public K Minimum
        {
            get
            {
                if (Count == 0)
                    throw new InvalidOperationException("The hash table does not contain any element.");
                return minimum;
            }
            private set { minimum = value; }
        }

        public K Maximum
        {
            get
            {
                if (Count == 0)
                    throw new InvalidOperationException("The hash table does not contain any element.");
                return maximum;
            }
            private set { maximum = value; }
        }

        public MinMaxHashTable()
        {
            capacity = 20;
            elements = new Element[capacity];
        }

        public MinMaxHashTable(int capacity)
        {
            this.capacity = capacity;
            elements = new Element[capacity];
        }

        public void Add(K key, V value)
        {
            if (Contains(key))
                throw new ArgumentException("Given key is already contained in this hash table.");

            if (Count == 0)
            {
                Minimum = key;
                Maximum = key;
            }
            else if (key.CompareTo(Minimum) < 0)
                Minimum = key;
            else if (key.CompareTo(Maximum) > 0)
                Maximum = key;

            Element el = new Element(key, value);
            int i = HashFunction(key); // Calculate index
            if (elements[i] != null) // Check for collision
                el.Next = elements[i];
            elements[i] = el;

            Count++;
        }

        public bool Contains(K key)
        {
            if (Count == 0)
                return false;

            int i = HashFunction(key);
            Element current = elements[i];
            while (current != null)
            {
                if (current.Key.CompareTo(key) == 0)
                    return true;
                current = current.Next;
            }
            return false;
        }

        public V Get(K key)
        {
            if (!Contains(key))
                throw new KeyNotFoundException("Element with given key was not found.");

            int i = HashFunction(key);
            Element current = elements[i];
            while (current.Key.CompareTo(key) != 0)
                current = current.Next;

            return current.Value;
        }

        public V Remove(K key)
        {
            if (!Contains(key))
                throw new KeyNotFoundException("Element with given key was not found.");

            int i = HashFunction(key);
            V value;
            // Check first element
            if (elements[i].Key.CompareTo(key) == 0)
            {
                value = elements[i].Value;
                elements[i] = elements[i].Next;
            }
            else
            // Check rest of the list
            {
                Element current = elements[i];
                while (current.Next.Key.CompareTo(key) != 0)
                    current = current.Next;
                // Remove the element

                value = current.Next.Value;
                current.Next = current.Next.Next;
            }
            Count--;
            return value;
        }

        public List<KeyValuePair<K, V>> this[K min, K max]
        {
            get
            {
                List<KeyValuePair<K, V>> list = new List<KeyValuePair<K, V>>();
                foreach (var item in elements)
                {
                    Element el = item;
                    while (el != null)
                    {
                        if (el.Key.CompareTo(min) >= 0 && el.Key.CompareTo(max) <= 0)
                            list.Add(new KeyValuePair<K, V>(el.Key, el.Value));
                        el = el.Next;
                    }
                }
                return list;
            }
        }

        public List<KeyValuePair<K, V>> Range(K min, K max)
        {
            return this[min, max];
        }

        public List<KeyValuePair<K, V>> SortedRange(K min, K max)
        {
            List<KeyValuePair<K, V>> l = this[min, max];
            l.Sort(Compare);
            return l;
        }

        private int Compare(KeyValuePair<K, V> a, KeyValuePair<K, V> b)
        {
            return a.Key.CompareTo(b.Key);
        }

        private int HashFunction(K key)
        {
            return Math.Abs(key.GetHashCode()) % capacity;
        }

        private class Element
        {
            public K Key { get; set; }
            public V Value { get; set; }

            public Element Next { get; set; }

            public Element(K key, V value)
            {
                this.Key = key;
                this.Value = value;
                Next = null;
            }
        }
    }
}
