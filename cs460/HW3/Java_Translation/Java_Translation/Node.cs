using System;
namespace Java_Translation
{
    /// <summary>
    /// Singly linked node class.  Stores data and a reference to the next node in a potential list.
    /// </summary>
    /// <typeparam name="T">Type T allows for any type to be stored within the list</typeparam>
    public class Node<T>
    {
        public T data;
        public Node<T> next;

        public Node(T data, Node<T> next)
        {
            this.data = data;
            this.next = next;
        }
    }
}
