using EventPass.Models.Events;
using EventPass.Models.Users;

namespace UnitTests.Models.Users
{
    [TestClass]
    public class AdminTests
    {
        [TestMethod]
        [DataRow("admin", "1234", "admin", "1234", true)]
        [DataRow("admin", "1234", "admin", "wrongpass", false)]
        [DataRow("admin", "1234", "wronglogin", "1234", false)]
        [DataRow("admin", "1234", null, null, false)]
        public void IsAuthenticated_ShouldReturnExpectedResult(string login, string password, string inputLogin, string inputPassword, bool expected)
        {
            // Arrange
            var admin = new Admin(login, password);

            // Act
            var result = admin.IsAuthenticated(inputLogin, inputPassword);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CreateEvent_ShouldAddEventSuccessfully_ForValidData()
        {
            // Arrange
            var admin = new Admin("admin", "1234");
            string message;

            // Act
            var result = admin.CreateEvent(
                name: "ConcertX",
                dateAndTime: DateTime.Now.AddDays(10),
                price: 50,
                city: "Paris",
                imagePath: "poster.jpg",
                countFreeTickets: 10,
                eventType: EventType.ConcertEvent,
                mes: out message,
                singer: "ArtistX"
            );

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, admin.CreatedEvents.Count);
            Assert.AreEqual(10, admin.CreatedEvents[0].Tickets.Count);
            Assert.AreEqual("", message);
        }

        [TestMethod]
        [DataRow("Short", "Paris", 3)] // мало квитків
        [DataRow("Ev", "Pa", 10)] // короткі назви
        public void CreateEvent_ShouldFail_OnInvalidData(string name, string city, int countTickets)
        {
            // Arrange
            var admin = new Admin("admin", "1234");

            // Act
            var result = admin.CreateEvent(
                name: name,
                dateAndTime: DateTime.Now.AddDays(10),
                price: 50,
                city: city,
                imagePath: null,
                countFreeTickets: countTickets,
                eventType: EventType.TheaterEvent,
                mes: out string message,
                numberOfActs: 2
            );

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(string.IsNullOrWhiteSpace(message));
            Assert.AreEqual(0, admin.CreatedEvents.Count);
        }

        [TestMethod]
        public void DeleteEvent_ShouldRemoveEvent_ById()
        {
            // Arrange
            var admin = new Admin("admin", "1234");
            admin.CreateEvent(
                name: "StandUp",
                dateAndTime: DateTime.Now.AddDays(5),
                price: 30,
                city: "Kyiv",
                imagePath: null,
                countFreeTickets: 8,
                eventType: EventType.StandUpEvent,
                mes: out string _,
                includeDrink: true
            );

            var createdEventId = admin.CreatedEvents[0].Id;

            // Act
            var result = admin.DeleteEvent(createdEventId);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, admin.CreatedEvents.Count);
        }

        [TestMethod]
        public void DeleteEvent_ShouldReturnFalse_IfNotFound()
        {
            // Arrange
            var admin = new Admin("admin", "1234");

            // Act
            var result = admin.DeleteEvent(999); // неіснуючий ID

            // Assert
            Assert.IsFalse(result);
        }
    }
}
