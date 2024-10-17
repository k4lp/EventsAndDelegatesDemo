namespace EventsAndDelegatesDemo.BuiltInDelegates
{
    public class PredicateDelegateExample
    {
        public static void Run()
        {
            Console.WriteLine("Predicate Delegate Example:");

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Predicate to check if a number is even
            Predicate<int> isEven = num => num % 2 == 0;

            // Use the predicate with List<T>.FindAll method
            List<int> evenNumbers = numbers.FindAll(isEven);
            Console.WriteLine($"Even numbers: {string.Join(", ", evenNumbers)}");

            // Predicate to check if a number is greater than 5
            Predicate<int> isGreaterThanFive = num => num > 5;

            // Use the predicate with List<T>.Find method
            int firstNumberGreaterThanFive = numbers.Find(isGreaterThanFive);
            Console.WriteLine($"First number greater than 5: {firstNumberGreaterThanFive}");

            // Combine predicates
            Predicate<int> isEvenAndGreaterThanFive = num => isEven(num) && isGreaterThanFive(num);
            List<int> evenNumbersGreaterThanFive = numbers.FindAll(isEvenAndGreaterThanFive);
            Console.WriteLine($"Even numbers greater than 5: {string.Join(", ", evenNumbersGreaterThanFive)}");

            Console.WriteLine();
        }
    }
}