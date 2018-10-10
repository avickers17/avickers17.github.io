using System;
using System.Collections.Generic;
using System.Text;

namespace Javacode_Translation
{
    public class QueueUnderflowException : SystemException
    {
        public QueueUnderflowException() : base() { }
        public QueueUnderflowException(string message) : base(message) { }
    }
}
