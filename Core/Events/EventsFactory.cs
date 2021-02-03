namespace Core.Events
{
    public class EventsFactory
    {
        public ExceptionThrow ExceptionThrow { get; set; }

        public EventsFactory()
        {
            ExceptionThrow = new ExceptionThrow();
        }
    }
}