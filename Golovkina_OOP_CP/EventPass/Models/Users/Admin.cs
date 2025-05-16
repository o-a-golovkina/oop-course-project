using EventPass.Interfaces;
using EventPass.Models.Events;
using EventPass.Models.Tickets;

namespace EventPass.Models.Users
{
    public class Admin : IAdmin
    {
        private string? login;
        private string? passwordHash;

        public static readonly Admin Instance = new("admin", "ItIs@dmin22");

        public List<Event> CreatedEvents { get; set; } = [];

        public string Login
        {
            get => login!;
            set => login = value;
        }

        public string Password
        {
            private get => passwordHash!;
            set => passwordHash = value?.GetHashCode().ToString();
        }

        private Admin(string? login, string? password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Login and password cannot be empty!");
            Login = login;
            Password = password;
        }

        public bool IsAuthenticated(string? login, string? password) =>
            login == Login && password?.GetHashCode().ToString() == Password;

        public bool CreateEvent(string? name, DateTime dateAndTime, decimal price, string? city, string? imagePath,
            int countFreeTickets, EventType eventType, out string mes,
            string? singer = null, bool includeDrink = false, short numberOfActs = 1)
        {
            try
            {
                var newEvent = new Event(name, dateAndTime, price, city, imagePath, countFreeTickets, eventType);
                AttachTickets(newEvent, price, singer, includeDrink, numberOfActs);
                CreatedEvents.Add(newEvent);
                mes = "";
                return true;
            }
            catch (Exception ex)
            {
                mes = ex.Message;
                return false;
            }
        }

        private void AttachTickets(Event ev, decimal price, string? singer, bool includeDrink, short numberOfActs)
        {
            var tickets = TicketFactory.CreateTickets(ev, price, singer, includeDrink, numberOfActs);
            ev.Tickets.AddRange(tickets);
        }

        public bool DeleteEvent(int id)
        {
            var ev = CreatedEvents.FirstOrDefault(e => e.Id == id);
            return ev != null && CreatedEvents.Remove(ev);
        }
    }

}
