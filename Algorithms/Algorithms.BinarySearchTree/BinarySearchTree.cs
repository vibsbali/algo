using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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

            public override string ToString()
            {
                return Value.ToString();
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
            Head = null;
            Count = 0;
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
            var resultOfFindWithParent = FindWithParent(item);
            var isPresent = resultOfFindWithParent.Item1;
            var nodeToRemove = resultOfFindWithParent.Item2;
            var parentNode = resultOfFindWithParent.Item3;

            if (isPresent)
            {
                //Is it tail
                if (nodeToRemove.LeftChild == null && nodeToRemove.RightChild == null)
                {
                    //Is it Head
                    if (parentNode == null)
                    {
                        Clear();
                        return true;
                    }

                    //If not head
                    if (IsLeftOfParent(nodeToRemove, parentNode))
                    {
                        parentNode.LeftChild = null;
                    }
                    else
                    {
                        parentNode.RightChild = null;
                    }
                    --Count;
                    return true;
                }

                //If node to remove has no right child - promote left child
                if (nodeToRemove.RightChild == null)
                {
                    //is it head
                    if (parentNode == null)
                    {
                        Head = nodeToRemove.LeftChild;
                    }
                    else
                    {
                        if (IsLeftOfParent(nodeToRemove, parentNode))
                        {
                            parentNode.LeftChild = nodeToRemove.LeftChild;
                        }
                        else
                        {
                            parentNode.RightChild = nodeToRemove.LeftChild;
                        }
                    }
                    --Count;
                    return true;
                }

                //If node to remove has a right child which doesn't have a left child
                if (nodeToRemove.RightChild.LeftChild == null)
                {
                    //is it head
                    if (parentNode == null)
                    {
                        var currentLeftNode = Head.LeftChild;
                        Head = nodeToRemove.RightChild;
                        Head.LeftChild = currentLeftNode;
                    }
                    else
                    {
                        if (IsLeftOfParent(nodeToRemove, parentNode))
                        {
                            var currentLeftNode = nodeToRemove.LeftChild;
                            parentNode.LeftChild = nodeToRemove.RightChild;
                            parentNode.LeftChild.LeftChild = currentLeftNode;
                        }
                        else
                        {
                            var currentLeftNode = nodeToRemove.LeftChild;
                            parentNode.RightChild = nodeToRemove.RightChild;
                            parentNode.RightChild.LeftChild = currentLeftNode;
                        }
                    }


                    --Count;
                    return true;
                }

                //If node to remove has a right child which inturn has a left child
                if (nodeToRemove.RightChild.LeftChild != null)
                {
                    var leftMostNodeWithParent = GetLeftMostNodeWithParent(nodeToRemove.RightChild);
                    var leftMostNodesParent = leftMostNodeWithParent.Item2;
                    var leftMostNode = leftMostNodeWithParent.Item1;

                    //find the leftmost item and replace in the place where node is being removed    
                    //is it head node
                    if (parentNode == null)
                    {
                       
                        leftMostNodesParent.LeftChild = null;
                        leftMostNode.LeftChild = Head.LeftChild;
                        leftMostNode.RightChild = Head.RightChild;

                        Head = leftMostNode;
                    }
                    else
                    {
                        if (IsLeftOfParent(nodeToRemove, parentNode))
                        {
                            parentNode.LeftChild = leftMostNode;
                            leftMostNodesParent.LeftChild = null;
                            leftMostNode.LeftChild = nodeToRemove.LeftChild;
                            leftMostNode.RightChild = nodeToRemove.RightChild;
                        }
                        else
                        {
                            parentNode.RightChild = leftMostNode;
                            leftMostNodesParent.LeftChild = null;
                            leftMostNode.LeftChild = nodeToRemove.LeftChild;
                            leftMostNode.RightChild = nodeToRemove.RightChild;
                        }
                    }


                    --Count;
                    return true;
                }
            }

            return false;
        }

        private Tuple<BinaryNode, BinaryNode> GetLeftMostNodeWithParent(BinaryNode startingNode)
        {
            BinaryNode parent = null;
            var currentNode = startingNode;
            if (startingNode.LeftChild == null)
            {
                return new Tuple<BinaryNode, BinaryNode>(startingNode, parent);
            }

            while (currentNode.LeftChild != null)
            {
                parent = currentNode;
                currentNode = currentNode.LeftChild;
            }

            return new Tuple<BinaryNode, BinaryNode>(currentNode, parent);
        }

        private bool IsLeftOfParent(BinaryNode nodeToRemove, BinaryNode parentNode)
        {
            return nodeToRemove.CompareTo(parentNode) < 0;
        }

        private Tuple<bool, BinaryNode, BinaryNode> FindWithParent(T value)
        {
            BinaryNode parentNode = null;
            BinaryNode currentNode = Head;

            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(value) == 0)
                {
                    return new Tuple<bool, BinaryNode, BinaryNode>(true, currentNode, parentNode);
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


            return new Tuple<bool, BinaryNode, BinaryNode>(false, null, null);
        }

        public int Count { get; private set; }
        public bool IsReadOnly => false;
    }
}
