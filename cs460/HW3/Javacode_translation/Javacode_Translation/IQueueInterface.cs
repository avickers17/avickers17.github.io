using System;
using System.Collections.Generic;
using System.Text;

namespace Javacode_Translation
{
    interface IQueueInterface<T>
    {
        T Push(T element);
        T Pop();
        Boolean IsEmpty();
    }
}
