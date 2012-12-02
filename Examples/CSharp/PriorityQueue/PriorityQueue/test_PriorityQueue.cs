using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Systen.Collections.Generic
{
    [TestFixture]
    public class test_PriorityQueue
    {
        [Test]
        public void Enqueue_into_empty_queue()
        {
            Enqueue<string>("a", 10);
            Assert.That(_queue, Is.EqualTo(new[]{new Element("a", 10)}));
        }

        [Test]
        public void Enqueue_with_same_prio()
        {
            Enqueue<string>("a", 5);
            Enqueue<string>("b", 5);
            Enqueue<string>("c", 5);
            Assert.That(_queue, Is.EqualTo(new[] { new Element("a", 5), new Element("b", 5), new Element("c", 5) }));            
        }

        [Test]
        public void Enqueue_with_different_priority_but_in_reverse_order()
        {
            Enqueue<string>("c", 1);
            Enqueue<string>("b", 5);
            Enqueue<string>("a", 10);
            Assert.That(_queue, Is.EqualTo(new[] { new Element("a", 10), new Element("b", 5), new Element("c", 1) }));    
        }


        struct Element
        {
            public object Value;
            public int Priority;
            public Element(object value, int priority) { Value = value; Priority = priority; }
        }


        [SetUp]
        public void Initialize()
        {
            _queue = new List<Element>();
        }

        private List<Element> _queue;

        internal void Enqueue<T>(T value, int priority)
        {
            _queue.Add(new Element(value, priority));
        }
    }
}
