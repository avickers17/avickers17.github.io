using System;
using System.Collections.Generic;
using System.Text;

namespace Javacode_Translation
{
    /// <summary>
    /// A custom unchecked exception to represent situations where an illegal operation was performed on an empty queue.
    /// If the QueueUnderflowException is thrown, a custom message is returned to the user. 
    /// </summary>
    public class QueueUnderflowException : SystemException
    {
        public QueueUnderflowException() : base() { }
        public QueueUnderflowException(string message) : base(message) { }
    }
}
