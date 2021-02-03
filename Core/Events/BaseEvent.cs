using System;
using System.Threading.Tasks;

namespace Core.Events
{
    public abstract class BaseEvent
    {
        public delegate Task ExceptionThrow(Exception exception);
        public event ExceptionThrow ExceptionThrowEvent;
        public void Raise(Exception exception)
        {
            ExceptionThrowEvent?.Invoke(exception);
        }
    }
}