using System;
namespace DataStructuresTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new MyStack<string>();
            var test2 = new MyQueue<int>();
            var test3 = new MyLinkedList<int>();

            test2.Enqueue(1);
            test2.Enqueue(2);
            test2.Enqueue(3);
            Console.WriteLine(test2.Dequeue());
            Console.WriteLine(test2.Dequeue());
            Console.WriteLine(test2.Dequeue());
            Console.WriteLine(test2.Size());
        }
    }
}
