using EventsAndDelegatesDemo.BasicDelegates;
using EventsAndDelegatesDemo.BuiltInDelegates;
using EventsAndDelegatesDemo.Events;
using EventsAndDelegatesDemo.AdvancedTopics;
using EventsAndDelegateDemo.RealWorldScenarios;

namespace EventsAndDelegatesDemo
{
    class MainEntry
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Events and Delegates Demo");
            Console.WriteLine("=========================");

            // Basic Delegates
            Console.WriteLine("\n1. Basic Delegates:");
            SimpleDelegateExample.Run();
            MulticastDelegateExample.Run();

            // Built-in Delegates
            Console.WriteLine("\n2. Built-in Delegates:");
            ActionDelegateExample.Run();
            FuncDelegateExample.Run();
            PredicateDelegateExample.Run();

            // Events
            Console.WriteLine("\n3. Events:");
            BasicEventExample.Run();
            CustomEventArgsExample.Run();
            EventHandlerDelegateExample.Run();

            // Advanced Topics
            Console.WriteLine("\n4. Advanced Topics:");
            AnonymousMethodsExample.Run();
            LambdaExpressionsExample.Run();
            AsyncEventHandlingExample.RunAsync().Wait();

            // Real World Scenarios
            Console.WriteLine("\n5. Real World Scenarios:");
            PublisherSubscriberPattern.Run();
            EventAggregatorPattern.Run();

            Console.WriteLine("\nDemo completed. Press any key to exit.");
            Console.ReadKey();
        }
    }
}