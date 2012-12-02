# Priority Queue
Implement a queue which keeps its elements not only in FIFO order, but groups them according to a priority.

Priorities are given as integer values. The higher the value, the higher the priority.

Example 1

* Elements added in this order: ("a", 5), ("b", 5), ("c", 5)
* Order in queue:  ("a", 5), ("b", 5), ("c", 5)

Example 2

* Elements added in this order: ("a", 10), ("b", 5), ("c", 1)
* Order in queue:  ("a", 10), ("b", 5), ("c", 1)

Example 3

* Elements added in this order:  ("c", 1), ("b", 5), ("a", 10)
* Order in queue:  ("a", 10), ("b", 5), ("c", 1)

Example 4

* Elements added in this order:  ("c", 1), ("b", 5), ("a", 10), ("d", 5)
* Order in queue:  ("a", 10), ("b", 5), ("d", 5), ("c", 1)

Example 5

* Elements added in this order:  ("c", 1), ("b", 5), ("a", 10), ("d", 3)
* Order in queue:  ("a", 10), ("b", 5), ("d", 3), ("c", 1)

The interface of the queue should look like this:

	interface PriorityQueue<T> {
		void Enqueue(T value, int priority);
		T Dequeue();
		int Count();
		T Peek();
		void Clear();
	}

The priority queue does not need to be thread-safe.

## Design
A priority queue could be build several ways. It could be a list of queues, where each queue represents a priority level. Or it could be a linked list into which new elements are inserted at the right place according to their priority. Or it could be a simple list which gets sorted anew for each new element (according to priority as well as element number (to keep the temporal order)).

The linked list approach seems to be the purest. But the sorted list approach seems to be easiest to implement - although not very performant.

For the sorting approach two aspects spring up: append new element, sort list.

For the linked list the approach seems to be: look for the first element with a lower priority. If found, insert new element right before it; if not found, append new element at end of list.

Does the linked list need to be linked? Probably not. A regular List<T> is sufficient. Inserting can easily be done on it.

In order to make the solution a tad more exciting and to reach higher performance the linked list approach is chosen.

## Test Cases

* Enqueue into empty queue
* Peek into empty queue = Exception!
* Peek into non-empty queue
* Dequeue single
* Dequeue from empty queue = Exception!
* Count single
* Enqueue with same priority
* Dequeue multiple
* Count multiple
* Clear
* Enqueue with different priorities but in reverse order
* Enqueue with different priorities but in no order
