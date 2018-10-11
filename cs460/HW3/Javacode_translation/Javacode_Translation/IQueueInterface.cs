using System;
using System.Collections.Generic;
using System.Text;

namespace Javacode_Translation
{
    /// <summary>
    /// A First in First Out queue interface.  This ADT is suitable for a singly
    /// linked queue.  
    /// </summary>
    /// <typeparam name="T">"T" can be of any data type.</typeparam>
    interface IQueueInterface<T>
    {/// <summary>
     /// Pushes an element to the rear of the queue, and updates references accodingly, 
     /// </summary>
     /// <param name="element">"T" for type of data and "element" for the value</param>
     /// <returns>Returns the element that was enqueued</returns>
        T Push(T element);
        /// <summary>
        /// Remove the front element within the queue.
        /// Will throw an exception if the queue is empty.
        /// </summary>
        /// <returns>Returns the element that was removed</returns>
        T Pop();
        /// <summary>
        /// Does a Check if the queue is empty.
        /// </summary>
        /// <returns>If Empty Returns true, otherwise false.</returns>
        Boolean IsEmpty();
    }
}
