namespace WebMessenger.Events
{
    public class EventSubscriber
    {
        private static readonly Dictionary<IEvent, Action> subscribes = new Dictionary<IEvent, Action>();

        public void Subscribe(IEvent @event, Action action)
        {
            subscribes.Add(@event, action);
        }
    }
}
