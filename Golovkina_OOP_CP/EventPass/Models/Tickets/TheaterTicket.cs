namespace EventPass.Models.Tickets
{
    public class TheaterTicket : TicketBase
    {
        private static int Counter;
        public short NumberOfActs { get; }

        public TheaterTicket(int eventId, decimal price, short acts)
            : base(eventId, price)
        {
            if (acts < 1)
                throw new ArgumentException("Theater event must have at least 1 act!");

            NumberOfActs = acts;
            Id = Interlocked.Increment(ref Counter);
        }
    }
}