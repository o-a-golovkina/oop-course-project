using EventPass.Models.Events;
using EventPass.Models.Tickets;
using System.Globalization;

namespace UnitTests.Models.Events
{
    [TestClass]
    public class EventTests
    {
        [TestMethod]
        public void Constructor_ValidData_ShouldCreateEventWithTickets()
        {
            // Arrange
            string name = "ConcertEvent";
            DateTime futureDate = DateTime.Now.AddDays(1);
            string city = "Kyiv";
            string imagePath = @"C:\images\event.jpg";
            int count = 10;
            decimal price = 100;

            // Act
            var ev = new Event(name, futureDate, price, city, imagePath, count, EventType.ConcertEvent);
            var tickets = TicketFactory.CreateTickets(ev, price, singer: "ImagineDragons");
            ev.Tickets.AddRange(tickets);

            // Assert
            Assert.AreEqual(name, ev.Name);
            Assert.AreEqual(city, ev.City);
            Assert.AreEqual(count, ev.CountFreeTickets);
            Assert.AreEqual(EventType.ConcertEvent, ev.EventType);
            Assert.IsNotNull(ev.Tickets);
            Assert.AreEqual(count, ev.Tickets.Count);
        }

        [DataTestMethod]
        [DataRow("", "25-08-2025 14:00:00", 100.0, "Kyiv", @"C:\images\event.jpg", 100, EventType.TheaterEvent)]
        [DataRow("CusEvent", "25-08-2024 14:00:00", 100.0, "Kyiv", @"C:\images\event.jpg", 100, EventType.TheaterEvent)]
        [DataRow("CusEvent", "25-08-2025 14:00:00", 100.0, "", @"C:\images\event.jpg", 100, EventType.TheaterEvent)]
        [DataRow("CusEvent", "25-08-2025 14:00:00", 100.0, "Kyiv", @"C:\images\event.jpg", 1, EventType.TheaterEvent)]
        public void Constructor_InvalidData_ShouldThrowArgumentException(string name, string dateStr, double price, string city, string imagePath,
            int count, EventType type)
        {
            // Arrange
            DateTime date = DateTime.ParseExact(dateStr, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Event(name, date, (decimal)price, city, imagePath, count, type);
            });
        }
    }
}
