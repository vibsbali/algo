﻿using System;
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
        internal BinaryNode Head { get; set; }
        internal class BinaryNode
        {
            public T Value { get; set; }

            public BinaryNode Parent { get; set; }
            public BinaryNode LeftChild { get; set; }
            public BinaryNode RightChild { get; set; }
            public bool HasRightChild => this.RightChild != null;
            public bool HasLeftChild => this.LeftChild != null;

            public BinaryNode(T value, BinaryNode parent = null)
            {
                Value = value;
                Parent = parent;
            }
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
            var node = FindNode(item);

            if (node == null)
            {
                return false;
            }

            //check if item to remove is head
            if (object.ReferenceEquals(node, Head))
            {
                //check if only one item
                if (!node.HasLeftChild && !node.HasRightChild)
                {
                    Clear();
                    return true;
                }


                if (!node.HasRightChild)
                {
                    Head = null;
                    Head = node.LeftChild;
                    Head.Parent = null;
                    --Count;
                    return true;
                }

                //node to remove has a right child which doesn't have a left child
                if (!node.RightChild.HasLeftChild)
                {
                    //TODO Complete
                }
            }

            return false;
        }

        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public void Add(T value)
        {
            if (Head == null)
            {
                Head = new BinaryNode(value, null);
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
                            currentNode.LeftChild = new BinaryNode(value, currentNode);
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
                            currentNode.RightChild = new BinaryNode(value, currentNode);
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
            Head = null;
            Count = 0;
        }

        public bool Contains(T value)
        {
            return FindNode(value) != null;
        }

        private BinaryNode FindNode(T value)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return current;
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

            return null;
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
