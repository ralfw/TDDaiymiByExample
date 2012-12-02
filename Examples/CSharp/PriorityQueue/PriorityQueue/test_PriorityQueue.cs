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
            var queue = new List<Element>();
            queue.Add(new Element("a", 10));
            Assert.That(queue, Is.EqualTo(new[]{new Element("a", 10)}));
        }

        [Test]
        public void Enqueue_with_same_prio()
        {
            var queue = new List<Element>();
            queue.Add(new Element("a", 5));
            queue.Add(new Element("b", 5));
            queue.Add(new Element("c", 5));
            Assert.That(queue, Is.EqualTo(new[] { new Element("a", 5), new Element("b", 5), new Element("c", 5) }));            
        }


        struct Element
        {
            public object Value;
            public int Priority;
            public Element(object value, int priority) { Value = value; Priority = priority; }
        }
    }
}
