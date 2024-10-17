namespace EventsAndDelegatesDemo.Events
{
    public class EventHandlerDelegateExample
    {
        public class Order
        {
            public event EventHandler<OrderEventArgs>? OrderProcessed;

            public void Process(string orderId)
            {
                Console.WriteLine($"Processing order: {orderId}");
                // Simulating order processing
                OnOrderProcessed(new OrderEventArgs(orderId, DateTime.Now));
            }

            protected virtual void OnOrderProcessed(OrderEventArgs e)
            {
                OrderProcessed?.Invoke(this, e);
            }
        }

        public class OrderEventArgs : EventArgs
        {
            public string OrderId { get; }
            public DateTime ProcessedTime { get; }

            public OrderEventArgs(string orderId, DateTime processedTime)
            {
                OrderId = orderId;
                ProcessedTime = processedTime;
            }
        }

        public static void Run()
        {
            Console.WriteLine("EventHandler Delegate Example:");

            Order order = new Order();
            order.OrderProcessed += Order_OrderProcessed;

            order.Process("ORD-001");
            order.Process("ORD-002");

            Console.WriteLine();
        }

        private static void Order_OrderProcessed(object sender, OrderEventArgs e)
        {
            Console.WriteLine($"Order {e.OrderId} was processed at {e.ProcessedTime}");
        }
    }
}