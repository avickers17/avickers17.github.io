using System;
using System.Collections.Generic;
using System.Text;

namespace Javacode_Translation
{/// <summary>
/// A Singly Linked First in First Out Queue.  
///From Dale, Joyce and Weems "Object-Oriented Data Structures Using Java"
///Modified for CS 460 HW#3 and for Using with C#
///See IQueueInterface.cs for documentation
/// </summary>
/// <typeparam name="T">Type T allows for any type to be stored within the list</typeparam>
    class LinkedQueue<T>
    {
        private Node<T> front;
        private Node<T> rear;

        public LinkedQueue()
        {
            front = null;
            rear = null;
        }
        public T Push(T element)
        {
            if(element == null)
            {
                throw new NullReferenceException();
            }
            if( IsEmpty() )
            {
                Node<T> tmp = new Node<T>(element, null);
                rear = front = tmp;
            }
            else
            {
                Node<T> tmp = new Node<T>(element, null);
                rear.next = tmp;
                rear = tmp;
            }
            return element;
        }

        public T Pop()
        {
            T tmp = default(T);
            if(IsEmpty() )
            {
                throw new QueueUnderflowException("The Queue was empty.");
            }
            else if(front == rear)
            {
                tmp = front.data;
                front = null;
                rear = null;
            }
            else
            {
                tmp = front.data;
                front = front.next;
            }
            return tmp;
        }

        public Boolean IsEmpty()
        {
            if(front == null && rear == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
