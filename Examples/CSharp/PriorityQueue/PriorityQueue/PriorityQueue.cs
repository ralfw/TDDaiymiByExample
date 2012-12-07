using System.Collections.Generic;
using System.Linq;

namespace Systen.Collections.Generic
{
    public class PriorityQueue<T>
    {
        internal struct Element
        {
            public readonly T Value;
            public readonly int Priority;
            public Element(T value, int priority) { Value = value; Priority = priority; }
        }


        private readonly List<Element> _queue;


        internal PriorityQueue(List<Element> queue) { _queue = queue; }
        public PriorityQueue() : this(new List<Element>()) {} 


        public void Enqueue(T value, int priority)
        {
            var insertionPoint = Find_insertion_point_before_first_element_with_lower_priority(priority);
            Insert_element(value, priority, insertionPoint);
        }

        private int[] Find_insertion_point_before_first_element_with_lower_priority(int priority)
        {
            return _queue.Where(e => e.Priority < priority)
                .Select((e, i) => i)
                .Take(1)
                .ToArray();
        }

        private void Insert_element(T value, int priority, int[] indexOfLowerPrioElement)
        {
            if (indexOfLowerPrioElement.Any())
                _queue.Insert(indexOfLowerPrioElement[0], new Element(value, priority));
            else
                _queue.Add(new Element(value, priority));
        }


        public T Dequeue()
        {
            var value = _queue.First().Value;
            _queue.RemoveAt(0);
            return value;
        }

        public T Peek()
        {
            return _queue[0].Value;
        }

        public int Count()
        {
            return _queue.Count();
        }

        public void Clear()
        {
            _queue.Clear();
        }
    }
}