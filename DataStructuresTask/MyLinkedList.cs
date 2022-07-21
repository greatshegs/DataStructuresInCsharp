using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresTask
{

    class MyLinkedList<T> : ICollection<T>
    {
        public int Count { get; set; }


        Node<T> Head { get; set; }
        Node<T> Tail { get; set; }


        /// <summary>
        /// Adds a new node to the linkedlist
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int Add(T item)
        {
            var newNode = new Node<T>(item);

            // if head is null then the list must be empty
            if (Head == null)
            {
                Head = newNode;
                Tail = Head;
            }
            else
            {
                Tail.Next = newNode; // sets the newNode to the previous node Next pointer
                Tail = newNode;      // sets tail as new node;
            }
            Count++;
            return Count;
        }


        /// <summary>
        /// loop through all the nodes in the linked list and check for the node value that equal item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Check(T item)
        {
            Node<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }

            return false;

        }


        /// <summary>
        /// Removes a node from the linked list
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            Node<T> current = Head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (previous != null)
                    {

                        if (current.Next == null) // that means it is the tail that is going to be removed
                        {
                            Tail = previous; // so set tail to previous
                        }
                        // if before : 3 -> 5 -> 7 -> null to remove 5?
                        // after:  3 -> 7 -> null
                        previous.Next = current.Next; 

                    }
                    else  // the Head is the one to be removed
                    {
                        if(Head.Next == null) // check if Head is the only item
                        {
                            Tail = null; // set Tail to null
                        }
                       Head = Head.Next; // set Head to the next, will be null if Head is the last element;

                    }

                    Count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }


        /// <summary>
        /// returns index of the item
        /// </summary>
        /// <param name="item"></param>
        /// <returns>-1 if not found</returns>
        public int Index(T item)
        {
            int index = -1;
            Node<T> current = Head;
            while (current != null)
            {
                index++;
                if (current.Value.Equals(item))
                {
                    return index;
                }

                current = current.Next;
            }
            return -1;
        }


        /// <summary>
        /// supports iteration through MyLinkedList
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentNode = Head;

            while (currentNode != null)
            {

                yield return currentNode.Value;
                currentNode = currentNode.Next;

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #region NotImplementedSections
        public bool IsReadOnly { get; }

        void ICollection<T>.Add(T item)
        {
            throw new NotImplementedException();
        }

        void ICollection<T>.Clear()
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.Contains(T item)
        {
            throw new NotImplementedException();
        }

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }


        #endregion

    }
}

