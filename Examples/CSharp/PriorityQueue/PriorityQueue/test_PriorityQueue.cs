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
            var queue = new List<PriorityQueue<string>.Element>();
            var sut = new PriorityQueue<string>(queue);
            sut.Enqueue("a", 10);
            Assert.That(queue, Is.EqualTo(new[]{new PriorityQueue<string>.Element("a", 10)}));
        }

        [Test]
        public void Enqueue_with_same_prio()
        {
            var queue = new List<PriorityQueue<string>.Element>();
            var sut = new PriorityQueue<string>(queue);
            sut.Enqueue("a", 5);
            sut.Enqueue("b", 5);
            sut.Enqueue("c", 5);
            Assert.That(queue, Is.EqualTo(new[] { new PriorityQueue<string>.Element("a", 5), new PriorityQueue<string>.Element("b", 5), new PriorityQueue<string>.Element("c", 5) }));            
        }

        [Test]
        public void Enqueue_with_different_priorities_in_reverse_order()
        {
            var queue = new List<PriorityQueue<string>.Element>();
            var sut = new PriorityQueue<string>(queue);
            sut.Enqueue("c", 1);
            sut.Enqueue("b", 5);
            sut.Enqueue("a", 10);
            Assert.That(queue, Is.EqualTo(new[] { new PriorityQueue<string>.Element("a", 10), new PriorityQueue<string>.Element("b", 5), new PriorityQueue<string>.Element("c", 1) }));    
        }

        [Test]
        public void Enqueue_with_different_priorities_in_no_order()
        {
            var queue = new List<PriorityQueue<string>.Element>();
            var sut = new PriorityQueue<string>(queue);
            sut.Enqueue("b", 5);
            sut.Enqueue("c", 1);
            sut.Enqueue("a", 10);
            Assert.That(queue, Is.EqualTo(new[] { new PriorityQueue<string>.Element("a", 10), new PriorityQueue<string>.Element("b", 5), new PriorityQueue<string>.Element("c", 1) })); 
        }
        #endregion

        #region Peek
        [Test]
        public void Peek_on_empty()
        {
            var sut = new PriorityQueue<string>();
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.Peek());
        }

        [Test]
        public void Peek_on_non_empty()
        {
            var sut = new PriorityQueue<string>();
            sut.Enqueue("a", 1);
            Assert.AreEqual("a", sut.Peek());
        }
        #endregion

        #region Dequeue

        [Test]
        public void Dequeue_on_non_empty()
        {
            var queue = new List<PriorityQueue<string>.Element>
                            {new PriorityQueue<string>.Element("a", 5), 
                             new PriorityQueue<string>.Element("b", 5)};
            var sut = new PriorityQueue<string>(queue);

            Assert.AreEqual("a", sut.Dequeue());
            Assert.AreEqual("b", queue[0].Value);
        }

        [Test]
        public void Dequeue_on_empty()
        {
            var sut = new PriorityQueue<string>();
            Assert.Throws<InvalidOperationException>(() => { var _ = sut.Dequeue(); });
        }
        #endregion

        #region Count
        [Test]
        public void Count_length_of_empty_queue()
        {
            var sut = new PriorityQueue<string>();
            Assert.AreEqual(0, sut.Count());
        }

        [Test]
        public void Count_length_of_non_empty_queue()
        {
            var sut = new PriorityQueue<string>();
            sut.Enqueue("a", 1);
            Assert.AreEqual(1, sut.Count());
        }
        #endregion

        #region Clear
        [Test]
        public void Clear_non_empty_queue()
        {
            var queue = new List<PriorityQueue<string>.Element> {new PriorityQueue<string>.Element("a", 1)};
            var sut = new PriorityQueue<string>(queue);

            sut.Clear();

            Assert.AreEqual(0, queue.Count());
        }
        #endregion
    }
}
