namespace EventsAndDelegatesDemo.BuiltInDelegates
{
    public class ActionDelegateExample
    {
        public static void Run()
        {
            Console.WriteLine("Action Delegate Example:");

            // Action with no parameters
            Action sayHello = () => Console.WriteLine("Hello!");
            sayHello();

            // Action with one parameter
            Action<string> greet = (name) => Console.WriteLine($"Hello, {name}!");
            greet("Alice");

            // Action with multiple parameters
            Action<string, int> introduce = (name, age) =>
                Console.WriteLine($"My name is {name} and I'm {age} years old.");
            introduce("Bob", 30);

            // Using Action as a parameter
            PerformAction("Charlie", 25, introduce);

            Console.WriteLine();
        }

        private static void PerformAction(string name, int age, Action<string, int> action)
        {
            Console.WriteLine("Performing action:");
            action(name, age);
        }
    }
}