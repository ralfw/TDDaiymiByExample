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

        struct Element
        {
            public object Value;
            public int Priority;
            public Element(object value, int priority) { Value = value; Priority = priority; }
        }
    }
}
