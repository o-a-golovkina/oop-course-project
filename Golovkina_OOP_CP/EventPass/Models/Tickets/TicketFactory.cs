using EventPass.Models.Events;

namespace EventPass.Models.Tickets
{
    public static class TicketFactory
    {
        public static List<TicketBase> CreateTickets(
            Event ev,
            decimal price,
            string? singer = null,
            bool includeDrink = false,
            short numberOfActs = 1)
        {
            if (price <= 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Price must be positive!");

            var result = new List<TicketBase>();
            var count = ev?.CountFreeTickets ?? 0;

            switch (ev?.EventType)
            {
                case EventType.ConcertEvent:
                    if (singer is null)
                        throw new ArgumentException("Singer must be provided!");
                    result.AddRange(Enumerable.Range(0, count)
                        .Select(_ => new ConcertTicket(ev.Id, price, singer)));
                    break;

                case EventType.StandUpEvent:
                    result.AddRange(Enumerable.Range(0, count)
                        .Select(_ => new StandUpTicket(ev.Id, price, includeDrink)));
                    break;

                case EventType.TheaterEvent:
                    result.AddRange(Enumerable.Range(0, count)
                        .Select(_ => new TheaterTicket(ev.Id, price, numberOfActs)));
                    break;

                default:
                    throw new NotSupportedException("Unsupported event type.");
            }

            return result;
        }
    }
}
