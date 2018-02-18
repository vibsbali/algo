using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.LinkedList
{
    public class DoublyLinkedList<T> : ICollection<T>
    {
        public Node Head { get; private set; }
        public Node Tail { get; private set; }
        public class Node
        {
            public Node Next { get; set; }
            public Node Previous { get; set; }
            public T Value { get; private set; }
            public Node(T value)
            {
                Value = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = Head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            AddToBack(item);
        }

        public void AddToBack(T item)
        {
            var node = new Node(item);
            if (Tail == null)
            {
                AddToFront(item);
                return;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
                Tail = node;
            }

            ++Count;
        }

        public void AddToFront(T item)
        {
            var node = new Node(item);
            if (Head == null)
            {
                Head = Tail = node;
            }
            else
            {
                Head.Previous = node;
                node.Next = Head;
                Head = node;
            }

            ++Count;
        }

        public void Clear()
        {
            Head = Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            var node = Head;
            while (node != null)
            {
                if (node.Value.Equals(item))
                {
                    return true;
                }
                node = node.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var node = Head;
            while (node != null)
            {
                array[arrayIndex++] = node.Value;
                node = node.Next;
            }
        }

        public bool Remove(T item)
        {
            Node previous = null;
            var current = Head;

            while (current != null)
            {
                //We found the item
                if (current.Value.Equals(item))
                {
                    if (Count == 1)
                    {
                        Clear();
                        return true;
                    }

                    //If previous is null it means head
                    if (previous == null)
                    {
                        Head.Next.Previous = null;
                        Head = Head.Next;
                    } else if (current == Tail)
                    {
                        Tail = Tail.Previous;
                        Tail.Next = null;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                    }

                        --Count;
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public int Count { get; private set; }
        public bool IsReadOnly => false;
    }
}
