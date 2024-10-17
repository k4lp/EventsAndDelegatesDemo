namespace EventsAndDelegatesDemo.Events
{
    public class BasicEventExample
    {
        public class Counter
        {
            private int threshold;
            private int total;

            public event EventHandler? ThresholdReached;

            public Counter(int threshold)
            {
                this.threshold = threshold;
            }

            public void Add(int x)
            {
                total += x;
                if (total >= threshold)
                {
                    OnThresholdReached(EventArgs.Empty);
                }
            }

            protected virtual void OnThresholdReached(EventArgs e)
            {
                ThresholdReached?.Invoke(this, e);
            }
        }

        public static void Run()
        {
            Console.WriteLine("Basic Event Example:");

            Counter counter = new Counter(10);
            counter.ThresholdReached += Counter_ThresholdReached!;

            Console.WriteLine("Adding numbers to the counter...");
            counter.Add(5);
            counter.Add(3);
            counter.Add(4);

            Console.WriteLine();
        }

        private static void Counter_ThresholdReached(object sender, EventArgs e)
        {
            Console.WriteLine("The threshold was reached!");
        }
    }
}