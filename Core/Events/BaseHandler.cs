namespace Core.Events
{
    public class BaseHandler
    {
        protected readonly EventsFactory EventsFactory;
        
        public BaseHandler(EventsFactory eventsFactory)
        {
            EventsFactory = eventsFactory;
        }
    }
}