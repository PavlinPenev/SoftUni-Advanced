using System;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        public class ListNode<T>
        {
            public ListNode(T value)
            {
                Value = value;
            }
            public T Value { get; set; }
            public ListNode<T> Previous { get; set; }
            public ListNode<T> Next { get; set; }
        }

        public ListNode<T> Head { get; set; }
        public ListNode<T> Tail { get; set; }
        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            if (Count == 0)
            {
                Head = Tail = new ListNode<T>(element);
            }
            else
            {
                ListNode<T> currentListNode = new ListNode<T>(element);
                currentListNode.Next = Head;
                Head.Previous = currentListNode;
                Head = currentListNode;
            }
            Count++;
        }

        public void AddLast(T element)
        {
            if (Count == 0)
            {
                Head = Tail = new ListNode<T>(element);
            }
            else
            {
                ListNode<T> currentListNode = new ListNode<T>(element);
                currentListNode.Previous = Tail;
                Tail.Next = currentListNode;
                Tail = currentListNode;
            }

            Count++;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T firstListNode = Head.Value;
            Head = Head.Next;
            if (Head != null)
            {
                Head.Previous = null;
            }
            else
            {
                Tail = null;
            }

            Count--;
            return firstListNode;
        }

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T lastListNode = Tail.Value;
            Tail = Tail.Previous;
            if (Tail != null)
            {
                Tail.Next = null;
            }
            else
            {
                Head = null; 
            }

            Count--;
            return lastListNode;
        }

        public void ForEach(Action<T> action)
        {
            ListNode<T> currentListNode = Head;
            while (currentListNode != null)
            {
                action(currentListNode.Value);
                currentListNode = currentListNode.Next;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            ListNode<T> currentListNode = Head;
            int counter = 0;
            while (currentListNode != null)
            {
                array[counter] = currentListNode.Value;
                currentListNode = currentListNode.Next;
                counter++;
            }

            return array;
        }
    }
}
