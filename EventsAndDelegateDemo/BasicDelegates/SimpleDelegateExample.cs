namespace EventsAndDelegatesDemo.BasicDelegates
{
    public class SimpleDelegateExample
    {
        // Define a delegate
        public delegate int MathOperation(int x, int y);

        public static void Run()
        {
            Console.WriteLine("Simple Delegate Example:");

            // Create delegate instances
            MathOperation add = Add;
            MathOperation subtract = Subtract;

            // Use the delegates
            Console.WriteLine($"10 + 5 = {add(10, 5)}");
            Console.WriteLine($"10 - 5 = {subtract(10, 5)}");

            // Use delegate as a parameter
            PerformOperation(15, 7, add);
            PerformOperation(20, 8, subtract);

            Console.WriteLine();
        }

        private static int Add(int x, int y) => x + y;
        private static int Subtract(int x, int y) => x - y;

        private static void PerformOperation(int x, int y, MathOperation operation)
        {
            int result = operation(x, y);
            Console.WriteLine($"Result of operation: {result}");
        }
    }
}