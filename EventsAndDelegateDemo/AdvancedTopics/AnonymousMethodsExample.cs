namespace EventsAndDelegatesDemo.AdvancedTopics
{
    public class AnonymousMethodsExample
    {
        public delegate bool FilterDelegate(int number);

        public static void Run()
        {
            Console.WriteLine("Anonymous Methods Example:");

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Using an anonymous method with a delegate
            FilterDelegate evenFilter = delegate (int number)
            {
                return number % 2 == 0;
            };

            List<int> evenNumbers = FilterNumbers(numbers, evenFilter);
            Console.WriteLine($"Even numbers: {string.Join(", ", evenNumbers)}");

            // Using an anonymous method inline
            List<int> oddNumbers = FilterNumbers(numbers, delegate (int number)
            {
                return number % 2 != 0;
            });
            Console.WriteLine($"Odd numbers: {string.Join(", ", oddNumbers)}");

            // Using an anonymous method with event subscription
            Button button = new Button();
            button.Click += static delegate (object sender, EventArgs e)
            {
                Console.WriteLine("Button clicked!");
            }!;

            button.SimulateClick();

            Console.WriteLine();
        }

        private static List<T> FilterNumbers<T>(List<T> numbers, FilterDelegate filter)
        {
            List<T> result = new List<T>();
            foreach (T number in numbers)
            {
                if (filter((int)(object)number!))
                {
                    result.Add(number);
                }
            }
            return result;
        }

        private class Button
        {
            public event EventHandler? Click;

            public void SimulateClick()
            {
                OnClick(EventArgs.Empty);
            }

            protected virtual void OnClick(EventArgs e)
            {
                Click?.Invoke(this, e);
            }
        }
    }
}