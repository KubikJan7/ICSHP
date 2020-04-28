// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Exercise06Task01;
using System;

namespace Exercise06Task01.Test
{
    [TestFixture]
    public class LinkedListTest
    {
        [Test]
        public void Add()
        {

            LinkedList<int> list = new LinkedList<int>();
            Assert.AreEqual(0, list.Count);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.AreEqual(3, list.Count);
            list.Add(4);
            list.Add(5);
            Assert.AreEqual(5, list.Count);

            Assert.AreEqual(0, list.IndexOf(1));
            Assert.AreEqual(1, list.IndexOf(2));
            Assert.AreEqual(2, list.IndexOf(3));
            Assert.AreEqual(3, list.IndexOf(4));
            Assert.AreEqual(4, list.IndexOf(5));

        }

        [Test]
        public void Remove()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.Remove(3);
            Assert.AreEqual(2, list.IndexOf(4));
            Assert.AreEqual(3, list.IndexOf(5));
            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(-1, list.IndexOf(3));

            list.Remove(1);
            Assert.AreEqual(0, list.IndexOf(2));
            Assert.AreEqual(-1, list.IndexOf(1));

            list.Remove(5);
            Assert.AreEqual(1, list.IndexOf(4));
            Assert.AreEqual(-1, list.IndexOf(5));

            Assert.AreEqual(false, list.Remove(6));
        }
        [Test]
        public void RemoveAt()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.RemoveAt(2);
            Assert.AreEqual(2, list.IndexOf(4));
            Assert.AreEqual(3, list.IndexOf(5));
            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(-1, list.IndexOf(3));

            list.RemoveAt(0);
            Assert.AreEqual(0, list.IndexOf(2));
            Assert.AreEqual(-1, list.IndexOf(1));

            list.RemoveAt(2);
            Assert.AreEqual(1, list.IndexOf(4));
            Assert.AreEqual(-1, list.IndexOf(5));

            Assert.AreEqual(false, list.Remove(6));
        }

        [Test]
        public void GetDataOf()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            Assert.AreEqual(1, list.GetDataOf(0));
            Assert.AreEqual(5, list.GetDataOf(4));

            list.Remove(3);

            Assert.AreEqual(4, list.GetDataOf(2));
        }

    }
}
