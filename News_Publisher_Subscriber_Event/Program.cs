namespace News_Publisher_Subscriber_Event
{
    public class NewsArticle
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public NewsArticle(string title , string content)
        {
            Title = title; 
            Content = content;
        }
    }

    public class NewsPublisher
    {
        public event EventHandler<NewsArticle> newNewsPublished;

        public void PublishNews(string Title , string Content)
        {
            var Article = new NewsArticle(Title , Content);
            OnNewNewsPublished(Article);
        }
        protected virtual void OnNewNewsPublished(NewsArticle newsArticle)
        {
            newNewsPublished?.Invoke(this, newsArticle);
        }

    }

    public class NewsSubscriber
    {
        public string name { get; set; }
        public NewsSubscriber(string name)
        {
            this.name = name;
        }

        public void Subscribe(NewsPublisher newsPublisher)
        {
            newsPublisher.newNewsPublished += HandleTheNews;
        }
        public void unSubscribe(NewsPublisher newsPublisher)
        {
            newsPublisher.newNewsPublished -= HandleTheNews;
        }
        public void HandleTheNews(object sender , NewsArticle news)
        {
            Console.WriteLine($"\n\n{name} recives an article");
            Console.WriteLine($"The title is {news.Title}");
            Console.WriteLine($"The Content is {news.Content}");

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            NewsPublisher newsPublisher = new NewsPublisher();

            NewsSubscriber newsSubscriber = new NewsSubscriber("Mohamed Salah");
            NewsSubscriber newsSubscriber2 = new NewsSubscriber("Omar Salah");


            newsSubscriber.Subscribe(newsPublisher);

            newsSubscriber2.Subscribe(newsPublisher);

            newsPublisher.PublishNews("Weather Forest", "Expect a suuny day");
            newsSubscriber2.unSubscribe(newsPublisher);

            newsPublisher.PublishNews("Weather Forest", "Expect a Cloudy day");

        }
    }
}
