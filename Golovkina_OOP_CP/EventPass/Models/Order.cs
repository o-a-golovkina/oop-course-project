using EventPass.Models.Events;
using EventPass.Models.Tickets;

namespace EventPass.Models
{
    public class Order : IComparable
    {
        private int id;
        private string? userLogin;
        private Event? orderedEvent;
        private decimal price;
        private TicketBase? ticket;

        private static int Counter = 0;

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string UserLogin
        {
            get => userLogin!;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Login cannot be empty");
                userLogin = value;
            }
        }

        public Event OrderedEvent
        {
            get => orderedEvent!;
            set => orderedEvent = value ?? throw new ArgumentNullException(nameof(OrderedEvent));
        }

        public decimal Price
        {
            get => price;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Price must be positive");
                price = value;
            }
        }

        public TicketBase Ticket
        {
            get => ticket!;
            set => ticket = value ?? throw new ArgumentNullException(nameof(Ticket));
        }

        public Order(string? userLogin, Event? orderedEvent, decimal price, TicketBase? ticket)
        {
            Id = ++Counter;
            UserLogin = userLogin!;
            OrderedEvent = orderedEvent!;
            Price = price;
            Ticket = ticket!;
        }

        public int CompareTo(object? obj)
        {
            if (obj is not Order other)
                throw new ArgumentException("Object is not an Order");

            return Price.CompareTo(other.Price);
        }
    }
}
