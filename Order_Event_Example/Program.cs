namespace Order_Event_Example
{
    internal class Program
    {

        public class OrderEventArgs:EventArgs
        {
            public int OrderID { get; set; }
            public double OrderPrice { get; set; }
            public string OrderEmail { get; set; }

            public OrderEventArgs(int OrderID , double OrderPrice, string OrderEmail)
            {
                this.OrderID = OrderID;
                this.OrderPrice = OrderPrice;
                this.OrderEmail = OrderEmail;
            }
        }

        public class Order
        {
            public event EventHandler<OrderEventArgs> OnOrderCreated;
             
            public void Create(int OrderID, double OrderPrice, string OrderEmail)
            {
                Console.WriteLine("New order created , now will notify a message by raising the event");

                OnOrderCreated?.Invoke(this, new OrderEventArgs(OrderID, OrderPrice, OrderEmail));
            }
        }

        public class EmailService
        {
            public void Subscribe(Order order)
            {
                order.OnOrderCreated += HandleTheOrder;
            }

            public void UnSubscribe(Order order)
            {
                order.OnOrderCreated -= HandleTheOrder;
            }
            public void HandleTheOrder(object sender , OrderEventArgs e)
            {
                Console.WriteLine("\n\n--------Email Service---------");
                Console.WriteLine("Email Service object recives a new order event");
                Console.WriteLine($"Order ID : {e.OrderID}");
                Console.WriteLine($"Order Price : {e.OrderPrice}");
                Console.WriteLine($"Email : {e.OrderEmail}\n");
                Console.WriteLine("Send an email");


            }
        }

        public class SMsService
        {
            public void Subscribe(Order order)
            {
                order.OnOrderCreated += HandleTheOrder;
            }

            public void UnSubscribe(Order order)
            {
                order.OnOrderCreated -= HandleTheOrder;
            }
            public void HandleTheOrder(object sender, OrderEventArgs e)
            {
                Console.WriteLine("\n\n--------SMS Service---------");
                Console.WriteLine("SMS Service object recives a new order event");
                Console.WriteLine($"Order ID : {e.OrderID}");
                Console.WriteLine($"Order Price : {e.OrderPrice}");
                Console.WriteLine($"Email : {e.OrderEmail}\n");
                Console.WriteLine("Send an SMS");


            }
        }
        public class ShippingService
        {
            public void Subscribe(Order order)
            {
                order.OnOrderCreated += HandleTheOrder;
            }

            public void UnSubscribe(Order order)
            {
                order.OnOrderCreated -= HandleTheOrder;
            }
            public void HandleTheOrder(object sender, OrderEventArgs e)
            {
                Console.WriteLine("\n\n--------Shipping Service---------");
                Console.WriteLine("Shipping Service object recives a new order event");
                Console.WriteLine($"Order ID : {e.OrderID}");
                Console.WriteLine($"Order Price : {e.OrderPrice}");
                Console.WriteLine($"Email : {e.OrderEmail}\n");
                Console.WriteLine("Handle Shipping");


            }
        }
        static void Main(string[] args)
        {
            Order order = new Order();
            EmailService emailService = new EmailService();
            SMsService sMsService = new SMsService();
            ShippingService shippingService = new ShippingService();

            emailService.Subscribe(order);
            sMsService.Subscribe(order);
            shippingService.Subscribe(order);

            order.Create(22, 250, "Mosalah22215@gmail.com");
        }
    }
}
