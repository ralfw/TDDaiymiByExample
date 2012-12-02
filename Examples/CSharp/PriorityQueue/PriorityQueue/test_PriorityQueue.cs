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
        #region Enqueue
        [Test]
        public void Enqueue_into_empty_queue()
        {
            Enqueue("a", 10);
            Assert.That(_queue, Is.EqualTo(new[]{new Element("a", 10)}));
        }

        [Test]
        public void Enqueue_with_same_prio()
        {
            Enqueue("a", 5);
            Enqueue("b", 5);
            Enqueue("c", 5);
            Assert.That(_queue, Is.EqualTo(new[] { new Element("a", 5), new Element("b", 5), new Element("c", 5) }));            
        }

        [Test]
        public void Enqueue_with_different_priorities_in_reverse_order()
        {
            Enqueue("c", 1);
            Enqueue("b", 5);
            Enqueue("a", 10);
            Assert.That(_queue, Is.EqualTo(new[] { new Element("a", 10), new Element("b", 5), new Element("c", 1) }));    
        }

        [Test]
        public void Enqueue_with_different_priorities_in_no_order()
        {
            Enqueue("b", 5);
            Enqueue("c", 1);
            Enqueue("a", 10);
            Assert.That(_queue, Is.EqualTo(new[] { new Element("a", 10), new Element("b", 5), new Element("c", 1) })); 
        }
        #endregion

        #region Peek
        [Test]
        public void Peek_on_empty()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { var _ = _queue[0].Value; });
        }
        #endregion

        #region Dequeue
        #endregion

        #region Count
        #endregion

        #region Clear
        #endregion


        [SetUp]
        public void Initialize()
        {
            _queue = new List<Element>();
        }


        struct Element
        {
            public object Value;
            public int Priority;
            public Element(object value, int priority) { Value = value; Priority = priority; }
        }


        private List<Element> _queue;

        internal void Enqueue<T>(T value, int priority)
        {
            var indexOfLowerPrioElement = _queue.Where(e => e.Priority < priority)
                                                .Select((e, i) => i)
                                                .Take(1)
                                                .ToList();
            if (indexOfLowerPrioElement.Any())
                _queue.Insert(indexOfLowerPrioElement.First(), new Element(value, priority));
            else
                _queue.Add(new Element(value, priority));
        }
    }
}
