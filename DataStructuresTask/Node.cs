namespace DataStructuresTask
{
    /// <summary>
    /// The Node class holds the value of the specified type and a reference to the next node
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Node<T>
    {
        public Node(T value)
        {
            Value = value;
        }

        public T Value { get; }
        public Node<T> Next { get; set; }
    }
}

