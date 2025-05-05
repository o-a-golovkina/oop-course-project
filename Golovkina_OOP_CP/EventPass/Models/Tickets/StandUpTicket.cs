namespace EventPass.Models.Tickets
{
    public class StandUpTicket : TicketBase
    {
        private static int Counter;
        public bool IsDrinkIncluded { get; }

        public StandUpTicket(int eventId, decimal price, bool drinks)
            : base(eventId, price)
        {
            IsDrinkIncluded = drinks;
            Id = Interlocked.Increment(ref Counter);
        }
    }
}