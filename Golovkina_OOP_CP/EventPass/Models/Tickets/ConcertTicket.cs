using System.Text.RegularExpressions;

namespace EventPass.Models.Tickets
{
    public class ConcertTicket : TicketBase
    {
        private static int Counter;
        public string Singer { get; }

        public ConcertTicket(int eventId, decimal price, string singer)
            : base(eventId, price)
        {
            if (string.IsNullOrWhiteSpace(singer) ||
                !Regex.IsMatch(singer, @"^([A-Za-z]{3,})(\s[A-Za-z]{3,})*$"))
                throw new ArgumentException("Each part of the singer's name must contain at least 3 Latin letters!");

            Singer = singer;
            Id = Interlocked.Increment(ref Counter);
        }
    }
}