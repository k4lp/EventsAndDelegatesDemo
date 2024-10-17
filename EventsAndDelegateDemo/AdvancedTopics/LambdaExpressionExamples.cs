namespace EventsAndDelegatesDemo.AdvancedTopics
{
    public class LambdaExpressionsExample
    {
        public static void Run()
        {
            Console.WriteLine("Lambda Expressions Example:");

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Using lambda expression with Func<T, TResult>
            Func<int, bool> isEven = n => n % 2 == 0;
            List<int> evenNumbers = numbers.Where(isEven).ToList();
            Console.WriteLine($"Even numbers: {string.Join(", ", evenNumbers)}");

            // Using lambda expression inline with LINQ
            var oddNumbers = numbers.Where(n => n % 2 != 0).ToList();
            Console.WriteLine($"Odd numbers: {string.Join(", ", oddNumbers)}");

            // Using lambda expression with Action<T>
            Action<int> printSquare = n => Console.WriteLine($"Square of {n} is {n * n}");
            numbers.ForEach(printSquare);

            // Using lambda expression with custom delegate
            Calculator calc = new Calculator();
            calc.Operation = (x, y) => x + y;
            Console.WriteLine($"5 + 3 = {calc.Calculate(5, 3)}");

            calc.Operation = (x, y) => x * y;
            Console.WriteLine($"5 * 3 = {calc.Calculate(5, 3)}");

            Console.WriteLine();
        }

        private class Calculator
        {
            public Func<int, int, int>? Operation { get; set; }

            public int Calculate(int x, int y)
            {
                return Operation!(x, y);
            }
        }
    }
}