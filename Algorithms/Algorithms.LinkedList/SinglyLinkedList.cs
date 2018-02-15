using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.LinkedList
{
    public class SinglyLinkedList<T> : ICollection<T>
    {
        public class Node
        {
            public T Value { get; }
            public Node Next { get; internal set; }

            public Node(T value)
            {
                Value = value;
            }
        }

        public Node Head { get; set; }
        public Node Tail { get; set; }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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

        public void Add(T item)
        {
            AddLast(item);
        }

        public void AddFirst(T value)
        {
            var node = new Node(value);
            if (Count == 0)
            {
                Head = Tail = node;
            }
            else
            {
                node.Next = Head;
                Head = node;
            }

            ++Count;
        }

        public void AddLast(T value)
        {
            if (Count == 0)
            {
                AddFirst(value);
                return;
            }

            var node = new Node(value);
            Tail.Next = node;
            Tail = node;
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
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            if (Count == 0)
            {
                return false;
            }

            Node previous = null;
            var currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    if (previous == null)
                    {
                        //It is the head node if previous is null

                        //Is it only one item
                        if (Count == 1)
                        {
                            Clear();
                            return true;
                        }

                        var headsNext = Head.Next;
                        Head = null;
                        Head = headsNext;
                    }
                    else if (currentNode.Next == null)
                    {
                        //It is tail
                        Tail = null;
                        Tail = previous;
                    }
                    else
                    {
                        //Middle node
                        previous.Next = currentNode.Next;
                        currentNode = null; //Not required for managed code
                    }


                    --Count;
                    return true;
                }

                previous = currentNode;
                currentNode = currentNode.Next;
            }

            return false;
        }

        public int Count { get; private set; }
        public bool IsReadOnly => false;
    }
}
