namespace EventsAndDelegatesDemo.BasicDelegates
{
    public class MulticastDelegateExample
    {
        public delegate void Notifier(string message);

        public static void Run()
        {
            Console.WriteLine("Multicast Delegate Example:");

            // Create delegate instances
            Notifier? notifier = EmailNotification;
            notifier += SMSNotification;
            notifier += PushNotification;

            // Invoke the multicast delegate
            notifier("Hello, this is a test notification!");

            Console.WriteLine("\nRemoving SMS notification...");
            notifier -= SMSNotification;

            // Invoke the modified multicast delegate
            notifier!("This is another test notification!");

            Console.WriteLine();
        }

        private static void EmailNotification(string message)
        {
            Console.WriteLine($"Sending email: {message}");
        }

        private static void SMSNotification(string message)
        {
            Console.WriteLine($"Sending SMS: {message}");
        }

        private static void PushNotification(string message)
        {
            Console.WriteLine($"Sending push notification: {message}");
        }
    }
}