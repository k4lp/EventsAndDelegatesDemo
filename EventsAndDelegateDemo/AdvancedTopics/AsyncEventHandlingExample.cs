namespace EventsAndDelegatesDemo.AdvancedTopics
{
    public class AsyncEventHandlingExample
    {
        public class AsyncOperationEventArgs : EventArgs
        {
            public int Result { get; }
            public AsyncOperationEventArgs(int result) => Result = result;
        }

        public class AsyncProcessor
        {
            public event EventHandler<AsyncOperationEventArgs>? OperationCompleted;

            public async Task ProcessAsync()
            {
                Console.WriteLine("Starting async operation...");
                await Task.Delay(2000); // Simulate async work
                int result = new Random().Next(1, 100);
                OnOperationCompleted(new AsyncOperationEventArgs(result));
            }

            protected virtual void OnOperationCompleted(AsyncOperationEventArgs e)
            {
                OperationCompleted?.Invoke(this, e);
            }
        }

        public static async Task RunAsync()
        {
            Console.WriteLine("Async Event Handling Example:");

            var processor = new AsyncProcessor();
            processor.OperationCompleted += async (sender, e) =>
            {
                await Task.Delay(1000); // Simulate async event handling
                Console.WriteLine($"Async operation completed with result: {e.Result}");
            };

            await processor.ProcessAsync();
            Console.WriteLine("Main thread continued...");
            await Task.Delay(2000); // Wait for event handler to complete
            Console.WriteLine();
        }
    }
}
