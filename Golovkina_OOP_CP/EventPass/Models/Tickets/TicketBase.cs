namespace EventPass.Models.Tickets
{
    public abstract class TicketBase
    {
        public int Id { get; protected set; }
        public int EventId { get; }
        public decimal Price { get; }
        public virtual string? UserLogin { get; set; }

        protected TicketBase(int eventId, decimal price)
        {
            if (price <= 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Price must be positive!");

            EventId = eventId;
            Price = price;
        }

        public virtual decimal GetPrice() => Price;
    }
}