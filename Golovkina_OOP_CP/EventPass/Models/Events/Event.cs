using EventPass.Models.Tickets;
using System.Collections;
using System.Text.RegularExpressions;

namespace EventPass.Models.Events
{
    public class Event : IEnumerable<TicketBase>, IComparable
    {
        private int id;
        private string? name;
        private DateTime dateAndTime;
        private string? city;
        private int countFreeTickets;

        private static int Counter = 0;

        public List<TicketBase> Tickets { get; set; } = [];

        public EventType EventType { get; set; }

        public string? ImagePath { get; set; }

        public int Id
        {
            get => id;
            private set => id = value;
        }

        public string? Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Event name cannot be empty");

                string lettersOnly = value.Replace(" ", "");

                if (lettersOnly.Length < 3 || !Regex.IsMatch(lettersOnly, @"^[A-Za-z]+$"))
                    throw new ArgumentException("At least 5 Latin letters; only letters and spaces allowed");

                name = value;
            }
        }

        public DateTime DateAndTime
        {
            get => dateAndTime;
            set
            {
                if (value < DateTime.Now)
                    throw new ArgumentException("Date must be in the future");
                dateAndTime = value;
            }
        }

        public string? City
        {
            get => city;
            set => city = !string.IsNullOrWhiteSpace(value) && Regex.IsMatch(value!, @"^[A-Za-z]{3,}$")
                ? value
                : throw new ArgumentException("City name must have at least 3 Latin letters");
        }

        public int CountFreeTickets
        {
            get => countFreeTickets;
            set
            {
                if (value < 5)
                    throw new ArgumentException("Count of free tickets must be over 5!");
                countFreeTickets = value;
            }
        }

        public Event(string? name, DateTime dateAndTime, decimal price, string? city, string? imagePath, int countFreeTickets, EventType eventType)
        {
            Id = ++Counter;
            Name = name;
            DateAndTime = dateAndTime;
            City = city;
            ImagePath = imagePath;
            CountFreeTickets = countFreeTickets;
            EventType = eventType;
        }

        public IEnumerator<TicketBase> GetEnumerator() => Tickets.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int CompareTo(object? obj) // Compares events by their scheduled date
        {
            if (obj is not Event other)
                throw new ArgumentException("Object is not an Event!");

            return DateAndTime.CompareTo(other.DateAndTime);
        }

    }
}
