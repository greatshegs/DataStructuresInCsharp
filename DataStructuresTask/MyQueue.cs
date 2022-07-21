using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresTask
{
    class MyQueue<T> : IEnumerable<T>
    {
        private int Count { get; set; }
        private Node<T> Head { get; set; }
        private Node<T> Tail { get; set; }

        /// <summary>
        /// checks if queue is empty 
        /// </summary>
        /// <returns>true if empty, false otherwise</returns>
        public bool IsEmpty()
        {
            return Count == 0;
        }

        public int Size()
        {
            return Count;
        }

        /// <summary>
        /// Adds a new item to the end of a queue
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            var newNode = new Node<T>(item);

            // if head is null then the queue must be empty
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
        }

        /// <summary>
        /// Removes an item from the top of a queue
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }
            else
            {
                Node<T> headToReturn = Head;
                if (Head.Next == null) // check if Head is the only item
                {
                    Tail = null; // set Tail to null
                }
                Head = Head.Next;
                Count--;
                return headToReturn.Value;

            }
        }


        /// <summary>
        /// Allows iteration over the queue
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
