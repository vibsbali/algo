using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("Algorithms.BinarySearchTreesTests")]

namespace Algorithms.BinarySearchTrees
{
    public class BinarySearchTree<T> : IEnumerable<T>
        where T : IComparable
    {
        protected internal class BinaryNode : IComparable<BinaryNode>
        {
            public BinaryNode(T value)
            {
                Value = value;
            }
            public BinaryNode LeftChild { get; set; }
            public BinaryNode RightChild { get; set; }

            public T Value { get; set; }

            public int CompareTo(BinaryNode other)
            {
                return this.Value.CompareTo(other.Value);
            }
        }

        internal BinaryNode Head { get; private set; }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Add(T item)
        {
            var node = new BinaryNode(item);
            if (Head == null)
            {
                Head = node;
            }
            else
            {
                var currentNode = Head;
                AddRecursively(currentNode, node);
            }

            ++Count;
        }

        private void AddRecursively(BinaryNode currentNode, BinaryNode newNode)
        {
            if (newNode.CompareTo(currentNode) >= 0)
            {
                if (currentNode.RightChild == null)
                {
                    currentNode.RightChild = newNode;
                    return;
                }

                AddRecursively(currentNode.RightChild, newNode);
            }
            else
            {
                if (currentNode.LeftChild == null)
                {
                    currentNode.LeftChild = newNode;
                    return;
                }

                AddRecursively(currentNode.LeftChild, newNode);
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            var resultOfFindWithParent = FindWithParent(item);
            return resultOfFindWithParent.Item1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        private Tuple<bool, BinaryNode> FindWithParent(T value)
        {
            BinaryNode parentNode = null;
            BinaryNode currentNode = Head;

            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(value) == 0)
                {
                    return new Tuple<bool, BinaryNode>(true, parentNode);
                }

                //Update parent node
                parentNode = currentNode;
                if (currentNode.Value.CompareTo(value) > 0)
                {
                    currentNode = currentNode.LeftChild;
                }
                else
                {
                    currentNode = currentNode.RightChild;
                }
            }


            return new Tuple<bool, BinaryNode>(false, parentNode);
        }

        public int Count { get; private set; }
        public bool IsReadOnly => false;
    }
}
