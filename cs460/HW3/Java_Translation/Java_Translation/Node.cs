using System;
namespace Java_Translation
{
    /// <summary>
    /// Singly linked node class.  Stores data and a reference to the next node in a potential list.
    /// </summary>
    /// <typeparam name="T">Type T allows for any type to be stored within the list</typeparam>
    public class Node<T>
    {
        private T data;
        public T Data
        {
            get { return data; }
            set { data = value; }
        }
        private Node<T> next;
        public Node<T> Next
        {
            get { return next; }
            set { next = value; }
        }

        public Node(T Data, Node<T> Next)
        {
            this.data = Data;
            this.next = Next;
        }
    }
}
