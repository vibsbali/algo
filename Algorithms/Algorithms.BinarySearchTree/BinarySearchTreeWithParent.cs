using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BinarySearchTrees
{
    public class BinarySearchTreeWithParent<T> : ICollection<T>
    where T : IComparable<T>
    {
        internal BinaryNode<T> Head { get; set; }
        internal class BinaryNode<T>
        {
            public T Value { get; set; }
            
            public BinaryNode<T> Parent { get; set; }
            public BinaryNode<T> LeftChild { get; set; }
            public BinaryNode<T> RightChild { get; set; }

            public BinaryNode(T value, BinaryNode<T> parent = null)
            {
                Value = value;
                Parent = parent;
            }
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public void Add(T value)
        {
            if (Head == null)
            {
                Head = new BinaryNode<T>(value, null);
            }
            else
            {
                var currentNode = Head;
                while (currentNode != null)
                {
                    if (currentNode.Value.CompareTo(value) > 0)
                    {
                        if (currentNode.LeftChild == null)
                        {
                            currentNode.LeftChild = new BinaryNode<T>(value, currentNode);
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.LeftChild;
                        }
                    }
                    else
                    {
                        if (currentNode.RightChild == null)
                        {
                            currentNode.RightChild = new BinaryNode<T>(value, currentNode);
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.RightChild;
                        }
                    }
                }
            }

            ++Count;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T value)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }

                if (current.Value.CompareTo(value) < 0)
                {
                    current = current.RightChild;
                }
                else
                {
                    current = current.LeftChild;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void PreOrderTraversal(Action<object> action)
        {
            throw new NotImplementedException();
        }

        public void PostOrderTraversal(Action<object> action)
        {
            throw new NotImplementedException();
        }

        public void InOrderTraversal(Action<object> action)
        {
            throw new NotImplementedException();
        }
    }
}
