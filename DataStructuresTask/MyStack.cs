using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresTask
{
    class MyStack<T> : IEnumerable<T>
    {
        private int Count { get; set; }

        public Node<T> Head { get; set; }


        /// <summary>
        /// Checks if stack is empty 
        /// </summary>
        /// <returns>true if empty, false otherwise</returns>
        public bool IsEmpty()
        {
            return Count == 0;
        }

        /// <summary>
        ///  Adds an item to the top of the stack
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            var newNode = new Node<T>(item);

            if(Head == null)
            {
                Head = newNode;
            }
            else
            {
                Node<T> temp = Head; // first set head to a temporary value
                Head = newNode; // set head to the new node
                Head.Next = temp; // attach temp to the new head
            }

            Count++;
        }

        /// <summary>
        /// Removes an item from the top of the stack
        /// </summary>
        /// <returns> item of type T </returns>
        public T Pop()
        {
            if(IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }
            else
            {
                Node<T> headToReturn = Head;
                Head = Head.Next;
                Count--;
                return headToReturn.Value;
            }
           
        }

        /// <summary>
        /// returns the item in line to be dequeued
        /// </summary>
        /// <returns>item of type T</returns>
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }
            else
            {
            return Head.Value;

            }
        }

        /// <summary>
        /// returns the number of elements in a stack
        /// </summary>
        /// <returns>int</returns>
        public int Size()
        {
            return Count;
        }

        /// <summary>
        /// allows iteration over the stack
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;

            while(current != null)
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
