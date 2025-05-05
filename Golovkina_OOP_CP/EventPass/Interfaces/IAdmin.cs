using EventPass.Models.Events;

namespace EventPass.Interfaces
{
    public interface IAdmin
    {
        string Login { get; set; }
        string Password { set; }

        bool IsAuthenticated(string? login, string? password);

        bool CreateEvent(
            string? name,
            DateTime dateAndTime,
            decimal price,
            string? city,
            string? imagePath,
            int countFreeTickets,
            EventType eventType,
            out string message,
            string? singer = null,
            bool includeDrink = false,
            short numberOfActs = 1);

        bool DeleteEvent(int id);
    }
}