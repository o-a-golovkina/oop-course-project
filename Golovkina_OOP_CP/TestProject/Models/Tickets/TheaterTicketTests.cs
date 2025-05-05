using EventPass.Models.Tickets;

namespace UnitTests.Models.Tickets
{
    [TestClass]
    public class TheaterTicketTests
    {
        [TestMethod]
        public void Constructor_ValidData_ShouldCreateTicket()
        {
            // Arrange
            int eventId = 10;
            decimal price = 120.0m;
            short numberOfActs = 3;

            // Act
            var ticket = new TheaterTicket(eventId, price, numberOfActs);

            // Assert
            Assert.AreEqual(eventId, ticket.EventId);
            Assert.AreEqual(price, ticket.Price);
            Assert.AreEqual(numberOfActs, ticket.NumberOfActs);
            Assert.IsTrue(ticket.Id > 0);
            Assert.IsNull(ticket.UserLogin);
        }

        [TestMethod]
        public void Constructor_InvalidPrice_ShouldThrow()
        {
            // Act + Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                var ticket = new TheaterTicket(1, -10, 2);
            });
        }


        [TestMethod]
        public void Constructor_InvalidNumberOfActs_ShouldThrow()
        {
            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var ticket = new TheaterTicket(1, 100, 0);
            });
        }


        [TestMethod]
        public void GetPrice_ShouldReturnCorrectPrice()
        {
            // Arrange
            decimal price = 150.0m;
            var ticket = new TheaterTicket(13, price, 2);

            // Act
            var result = ticket.GetPrice();

            // Assert
            Assert.AreEqual(price, result);
        }

        [TestMethod]
        public void UserLogin_SetAndGet_ShouldWorkCorrectly()
        {
            // Arrange
            var ticket = new TheaterTicket(14, 70, 2);

            // Act
            ticket.UserLogin = "dramaFan456";

            // Assert
            Assert.AreEqual("dramaFan456", ticket.UserLogin);
        }
    }
}
