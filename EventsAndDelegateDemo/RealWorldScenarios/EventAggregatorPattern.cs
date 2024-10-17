namespace EventsAndDelegateDemo.RealWorldScenarios
{
    public class EventAggregatorPattern
    {
        public interface IEvent { }

        public class OrderPlacedEvent : IEvent
        {
            public string OrderId { get; }
            public OrderPlacedEvent(string orderId) => OrderId = orderId;
        }

        public class ShippingConfirmedEvent : IEvent
        {
            public string OrderId { get; }
            public string TrackingNumber { get; }
            public ShippingConfirmedEvent(string orderId, string trackingNumber)
            {
                OrderId = orderId;
                TrackingNumber = trackingNumber;
            }
        }

        public interface IEventAggregator
        {
            void Publish<TEvent>(TEvent eventToPublish) where TEvent : IEvent;
            void Subscribe<TEvent>(Action<TEvent> action) where TEvent : IEvent;
            void Unsubscribe<TEvent>(Action<TEvent> action) where TEvent : IEvent;
        }

        public class EventAggregator : IEventAggregator
        {
            private readonly Dictionary<Type, List<object>> subscribers = new Dictionary<Type, List<object>>();

            public void Publish<TEvent>(TEvent eventToPublish) where TEvent : IEvent
            {
                if (subscribers.TryGetValue(typeof(TEvent), out var actions))
                {
                    foreach (var action in actions.Cast<Action<TEvent>>())
                    {
                        action(eventToPublish);
                    }
                }
            }

            public void Subscribe<TEvent>(Action<TEvent> action) where TEvent : IEvent
            {
                if (!subscribers.ContainsKey(typeof(TEvent)))
                {
                    subscribers[typeof(TEvent)] = new List<object>();
                }
                subscribers[typeof(TEvent)].Add(action);
            }

            public void Unsubscribe<TEvent>(Action<TEvent> action) where TEvent : IEvent
            {
                if (subscribers.ContainsKey(typeof(TEvent)))
                {
                    subscribers[typeof(TEvent)].Remove(action);
                }
            }
        }

        public static void Run()
        {
            Console.WriteLine("Event Aggregator Pattern Example:");

            var eventAggregator = new EventAggregator();

            eventAggregator.Subscribe<OrderPlacedEvent>(e =>
                Console.WriteLine($"Order placed: {e.OrderId}"));

            eventAggregator.Subscribe<ShippingConfirmedEvent>(e =>
                Console.WriteLine($"Shipping confirmed for order {e.OrderId}. Tracking number: {e.TrackingNumber}"));

            eventAggregator.Publish(new OrderPlacedEvent("ORD-001"));
            eventAggregator.Publish(new ShippingConfirmedEvent("ORD-001", "TRK-123456"));

            Console.WriteLine();
        }
    }
}
