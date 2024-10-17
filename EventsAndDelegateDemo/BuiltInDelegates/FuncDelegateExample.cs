namespace EventsAndDelegatesDemo.BuiltInDelegates
{
    public class FuncDelegateExample
    {
        public static void Run()
        {
            Console.WriteLine("Func Delegate Example:");

            // Func with no parameters and a return value
            Func<string> getCurrentTime = () => DateTime.Now.ToShortTimeString();
            Console.WriteLine($"Current time: {getCurrentTime()}");

            // Func with parameters and a return value
            Func<int, int, int> add = (a, b) => a + b;
            Console.WriteLine($"5 + 3 = {add(5, 3)}");

            // Func with multiple parameters and a return value
            Func<string, int, string> repeatString = (str, count) => string.Concat(Enumerable.Repeat(str, count));
            Console.WriteLine(repeatString("Ha", 3));

            // Using Func as a parameter
            int result = PerformOperation(10, 20, add);
            Console.WriteLine($"Result of operation: {result}");

            Console.WriteLine();
        }

        private static T PerformOperation<T>(T a, T b, Func<T, T, T> operation)
        {
            Console.WriteLine("Performing operation:");
            return operation(a, b);
        }
    }
}