namespace EventsAndDelegateDemo.RealWorldScenarios
{
    public class PublisherSubscriberPattern
    {
        public class NewsPublisher
        {
            private List<ISubscriber> subscribers = new List<ISubscriber>();

            public void Subscribe(ISubscriber subscriber)
            {
                subscribers.Add(subscriber);
            }

            public void Unsubscribe(ISubscriber subscriber)
            {
                subscribers.Remove(subscriber);
            }

            public void PublishNews(string news)
            {
                foreach (var subscriber in subscribers)
                {
                    subscriber.ReceiveNews(news);
                }
            }
        }

        public interface ISubscriber
        {
            void ReceiveNews(string news);
        }

        public class EmailSubscriber : ISubscriber
        {
            public string Email { get; }
            public EmailSubscriber(string email) => Email = email;
            public void ReceiveNews(string news)
            {
                Console.WriteLine($"Sending news via email to {Email}: {news}");
            }
        }

        public class SMSSubscriber : ISubscriber
        {
            public string PhoneNumber { get; }
            public SMSSubscriber(string phoneNumber) => PhoneNumber = phoneNumber;
            public void ReceiveNews(string news)
            {
                Console.WriteLine($"Sending news via SMS to {PhoneNumber}: {news}");
            }
        }

        public static void Run()
        {
            Console.WriteLine("Publisher-Subscriber Pattern Example:");

            var publisher = new NewsPublisher();
            var emailSub = new EmailSubscriber("user@example.com");
            var smsSub = new SMSSubscriber("+1234567890");

            publisher.Subscribe(emailSub);
            publisher.Subscribe(smsSub);

            publisher.PublishNews("Breaking news: C# 9.0 released!");

            publisher.Unsubscribe(smsSub);
            publisher.PublishNews("Update: New features in C# 9.0");

            Console.WriteLine();
        }
    }
}